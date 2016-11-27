using MicroSmadio.XElite.User.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSmadio.XElite.User.Controller
{
    public class LoginController : ILoginController
    {
        public LoginResult Login(string userAccount, string password, bool? rememberMe)
        {
            LoginResult loginResut = new LoginResult();
            for (int i = 0; i < 10000000; i++) ;
            string user = "121250014";
            string pw = "MS1234567";
            loginResut.IsSuccess = userAccount == user && pw == password;
            return loginResut;
        }
    }
}
