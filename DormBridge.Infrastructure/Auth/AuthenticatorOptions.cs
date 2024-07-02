using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormBridge.Infrastructure.Auth
{
    public class AuthenticatorOptions
    {
        public string JwtIssuer { get; set; }
        public string JwtAudience { get; set; }
        public string JwtKey { get; set; }
        public TimeSpan? JwtExpiry { get; set; }
    }
}
