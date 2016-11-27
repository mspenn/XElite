using MicroSmadio.XElite.User.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSmadio.XElite.User.Controller
{
    public interface ILoginController
    {
        LoginResult Login(string userAccount, string password, bool? rememberMe);
    }
}
