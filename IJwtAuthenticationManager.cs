using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Case
{
    public interface IJwtAuthenticationManager
    {

        //Overrideable Authentication string method For the JwtAuthenticationManager class
        string Authenticate(string username);
    }
}
