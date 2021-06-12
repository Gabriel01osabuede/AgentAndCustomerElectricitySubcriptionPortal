using ElectricityDigitalSystem.Constant;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ElectricityDigitalSystem.Data
{
    public class JsonFileService
    {
        private string jsonFileName = "SBSCDigitalElectricDb.json";
        public DbContext database { get; set; }

        public JsonFileService()
        {
            this.OnInit();
        }

        private void OnInit()
        {
            if(!Directory.Exists(FileConstant.DBFOLDER))
            {
                Directory.CreateDirectory(FileConstant.DBFOLDER);
            }

            if (!File.Exists(Path.Combine(FileConstant.DBFOLDER, jsonFileName))) 
            {
                //File.Create(Path.Combine(FileConstant.DBFOLDER, jsonFileName));
                this.database = new DbContext();
  
            }

            else 
            {
                //if file exist then read the file from the directory
                using StreamReader reader = new StreamReader(Path.Combine(FileConstant.DBFOLDER, jsonFileName));
                {
                    try
                    {
                        //Read all filecontent from the json file
                        string jsonFileContent = reader.ReadToEnd();
                        this.database = JsonSerializer.Deserialize<DbContext>(jsonFileContent);
                        
                    }
                    catch(Exception)
                    {
                        //If the databse is empty instead of throwing an error just create an instance of the database
                        database = new DbContext();
                    }
                }
            }
        }
        public void SaveChanges()
        {
            //This will covert the database object in a json and write to a file
            try
            {
                string newJson = JsonSerializer.Serialize(database);
                File.WriteAllText(Path.Combine(FileConstant.DBFOLDER, jsonFileName), newJson);
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Occured please register again.\n{e.Message}");
            }
            
        }
    }
}
