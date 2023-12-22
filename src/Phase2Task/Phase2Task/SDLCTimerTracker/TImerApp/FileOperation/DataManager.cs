using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace TimerApp.FileOperation
{
    class DataManager<T>: IDataManager<T>
    {
        public List<T> LoadDataFromFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string json = sr.ReadToEnd();
                    List<T> users = JsonConvert.DeserializeObject<List<T>>(json);
                    if (users == null)
                    {
                        return new List<T>();
                    }
                    return users;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("File not found");
                return new List<T>();
            }
        }

        public void SaveDataToFile(List<T> Users, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    string json = JsonConvert.SerializeObject(Users);
                    sw.Write(json);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("File not found");
            }
        }
    }
}
