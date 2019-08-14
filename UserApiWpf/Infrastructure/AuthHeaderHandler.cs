using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UserApiWpf.Model;

namespace UserApiWpf.Infrastructure
{
    public class AuthHeaderHandler
    {
        protected UserProperties _user;
        public AuthHeaderHandler(UserProperties user)
        {
            _user = user;
        }

        public AuthenticationHeaderValue GetAuthenticationHeader()
        {
            return new AuthenticationHeaderValue("Bearer", _user.Token);
        }
        public void ClearHeaderData()
        {
            _user.ClearData();
        }
    }
}
