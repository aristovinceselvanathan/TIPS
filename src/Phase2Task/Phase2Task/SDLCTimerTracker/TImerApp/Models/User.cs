using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerApp.Models
{
    public class User
    {
        public User(string userName, string email, string hashedpassword)
        {
            this.userName = userName;
            Email = email;
            Hashedpassword = hashedpassword;
        }

        public string userName {  get;set; }
        public string Email { get; set; }
        public string Hashedpassword { get;set; }
    }
}
