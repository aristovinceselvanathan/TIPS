using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TimerApp
{
    static class Validator
    {
        public static bool ValidateUserName(string userEnteredValue)
        {
            if(string.IsNullOrEmpty(userEnteredValue))
            {
                return false;
            }
            return true;
        }
        public static bool ValidateEmail(string userEnteredValue)
        {
            Regex regex = new Regex("^[a-zA-Z0-9_!#$%&'*+/=?`{|}~^.-]+@[a-zA-Z0-9.-]+$");
            if (regex.IsMatch(userEnteredValue))
            {
                return true;
            }
            return false;
        }
        public static bool ValidatePassword(string userEnteredValue)
        {
            if (userEnteredValue.Count() > 8)
            {
                return true;
            }
            return false;
        }
    }
}
