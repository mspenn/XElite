using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSmadio.XElite.User
{
    public class LoginViewModel
    {
        private string userAccount = "";
        private string password = "";

        public string UserAccount
        {
            get { return userAccount; }
            private set { userAccount = value; }
        }

        public string Password
        {
            get { return password; }
            private set { password = value; }
        }

        public LoginViewModel(string userAccount, string password)
        {
            this.UserAccount = userAccount;
            this.Password = password;
        }
        
        public LoginViewModel()
        {
            InitData();
        }
        
        private void InitData()
        {
            UserAccount = "121250014";
            Password = "MS123456";
        }
    }
}
