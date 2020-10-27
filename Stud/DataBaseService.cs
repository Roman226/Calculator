using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Stud
{
    public static class DataBaseService
    {
        public static DataBase dbContext { get; set; }


        static DataBaseService()
        {
           
            Load();
        }

        public static void Save()
        {
            File.WriteAllText(@"C:\temp\DataBase.json", System.Text.Json.JsonSerializer.Serialize(dbContext));
        }

        public static void Load()
        {
            if (File.Exists(@"C:\temp\DataBase.json"))
            {
                var str = File.ReadAllText(@"C:\temp\DataBase.json");
                dbContext = System.Text.Json.JsonSerializer.Deserialize<DataBase>(str);
            }
            else
            {
                dbContext = new DataBase();
            }
        }

    }
}
