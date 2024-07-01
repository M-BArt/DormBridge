using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormBridge.Infrastructure.Authenticator
{
    public class AuthenticatorOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SigninKey { get; set; }
        public TimeSpan? Expiry { get; set; }
    }
}
