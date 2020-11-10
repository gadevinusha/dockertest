using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularMongo
{
    public class SecurityService
    {

        public async Task<bool>  Authenticate(string userName, string Password)
        {
            bool result = false;
            if (userName == Password)
                result = true;
            await Task.Yield();
            return result;
        }
    }
}
