using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdinLib.Helpers
{
    public abstract class EdinHelperBase
    {
        protected string Login { get; private set; }
        protected string Password { get; private set; }
        public EdinHelperBase(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }
    }
}
