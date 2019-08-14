using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApiWpf.Model
{
    public class UserProperties
    {
        public string Name { get; private set; }
        public string Token { get; private set; }
        public string ApiPath { get; private set; }

        public bool IsAuthenticated {
            get {
                return Token.Any();
            }
        }

        public void SetUserData(string name, string token)
        {
            Name = name;
            Token = token;
        }
        public void SetApi(string apiPath)
        {
            ApiPath = apiPath;
        }

        public void ClearData()
        {
            Name = "";
            Token = "";
            ApiPath = "";
        }
    }
}
