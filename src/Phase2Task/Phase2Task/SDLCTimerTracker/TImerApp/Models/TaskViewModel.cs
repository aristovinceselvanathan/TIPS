using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TImerApp.Models
{
    class TaskViewModel
    {
        public ObservableCollection<UserTask> Tasks { get; set; }
    }
}
