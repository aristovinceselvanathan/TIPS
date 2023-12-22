using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TimerApp.FileOperation
{
    public interface IDataManager<T>
    {
        List<T> LoadDataFromFile(string path);

        void SaveDataToFile(List<T> Users, string path);
    }
}
