using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _20_11_23_Examen_C_Sharp
{
    public enum FileType
    {
        JSON,
        XML,
        TXT
    }
    public class FileManager
    {
        //public void SaveToFile(User users, string filePath, FileType type)
        //{            
        //    switch (type)
        //    {
        //        case FileType.TXT: SaveToFileTXT(users, filePath); break;
        //        case FileType.JSON: SaveToFileJSON(users, filePath); break;
        //        case FileType.XML: SaveToFileXML(users, filePath); break;                
        //    }          
        //}

        public void SaveToFile(List<User> users, string filePath)
        {
            string extension = Path.GetExtension(filePath);
            if (extension == ".json")
            {
                // Save to JSON
                string json = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            else if (extension == ".xml")
            {
                // Save to XML
                XmlSerializer xml = new XmlSerializer(users.GetType());
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    xml.Serialize(fileStream, users);
                }
            }
            else
            {
                // Save to TXT
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (var user in users)
                    {
                        sw.WriteLine($"Id: {user.Id}, Username: {user.Username}, Email: {user.Email}");
                    }
                }
                            
            }
        }

        public List<User> LoadFromFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            if (extension == ".json")
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<User>>(json);
            }
            else if (extension == ".xml")
            {
                // Load from XML
                return new List<User>();
            }
            else
            {
                // Load from TXT file
                return new List<User>();
            }
        }
        private void SaveToFileJSON(User users, string filePath)
        {
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(filePath, json);
        }
        private void SaveToFileXML(User users, string filePath)
        {
            XmlSerializer xml = new XmlSerializer(users.GetType());
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                xml.Serialize(fileStream, users);
            }
        }

        private void SaveToFileTXT(User users, string filePath)
        {
            using(StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"ID: {users.Id}");
                writer.WriteLine($"Username: {users.Username}");
                writer.WriteLine($"Email: {users.Email}");
            }
        }

    }

}

