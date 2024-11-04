using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatt.Stores
{
    public class AuthenticationStore
    {
        public bool IsSignedIn { get; private set; }

        public void SignIn()
        {
            IsSignedIn = true;
        }

        public void SignOut()
        {
            IsSignedIn = false;
        }
    }
}
