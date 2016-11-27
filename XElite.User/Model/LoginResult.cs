using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSmadio.XElite.User.Model
{
    public class LoginResult
    {
        private bool? isSuccess;
        public bool IsSuccess
        {
            get { return isSuccess ?? true; }
            set { isSuccess = value; }
        }
    }
}
