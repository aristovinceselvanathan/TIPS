using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TimerApp.FileOperation;
using TimerApp.Models;

namespace TimerApp.AuthenticationServer
{
    class Authenticator : IAuthenticator
    {
        public int Authenticate(string userName, string password)
        {
            DataManager<User> dataManager = new DataManager<User>();
            List<User> users = dataManager.LoadDataFromFile("..\\..\\..\\Data\\LoginData.json");
            User LoginUser = users.FirstOrDefault(x => x.userName.Equals(userName));
            if (LoginUser != null) 
            {
                if(GenerateHash(password).Equals(LoginUser.Hashedpassword))
                {
                    return tokenizer(userName);
                }
            }
            return 0;
        }

        public bool Register(string userName, string email, string password) 
        {
            DataManager<User> dataManager = new DataManager<User>();
            List<User> users = dataManager.LoadDataFromFile("..\\..\\..\\Data\\LoginData.json");
            if (users.FirstOrDefault(x => x.Equals(userName)) == null)
            {
                users.Add(new User(userName, email, GenerateHash(password)));
                dataManager.SaveDataToFile(users, "Data\\LoginData.json");
                return true;
            }
            return false;
        }
        public string GenerateHash(string password)
        {
            using(SHA256  sha256 = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

        public int tokenizer(string username)
        {
            int token = username.GetHashCode();
            return token;
        }
    }
}
