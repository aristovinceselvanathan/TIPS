using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TImerApp.Models
{
    class UserTask
    {
        public string title {  get; set; }
        public string description { get; set; }

        public List<Time> tasks { get; set; }
    }
}
