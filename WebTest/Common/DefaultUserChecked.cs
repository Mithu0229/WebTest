using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System.Linq;
using System.Threading.Tasks;

namespace WebTest.Common
{
    public class DefaultUserChecked : IAuthorizationRequirement
    {
        private readonly IConfiguration _configuration;
        
        public DefaultUserChecked(string user,string pass, IConfiguration configuration)
        {
            _configuration = configuration;
            this.Login(user, pass);
        }
        bool Login(string username, string password)
        {
            string user = _configuration.GetValue<string>("user");
            string pass = _configuration.GetValue<string>("pass");

            if (user == username && pass == password)
            {
                return true;
            }

            return false;
        }
    }


   
}
