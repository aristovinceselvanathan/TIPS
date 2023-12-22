using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerApp.AuthenticationServer
{
    interface IAuthenticator
    {
        int Authenticate(string userName, string password);
    }
}
