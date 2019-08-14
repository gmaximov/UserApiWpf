using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using UserApiWpf.Dto;
using UserApiWpf.Infrastructure;
using UserApiWpf.Model;

namespace UserApiWpf.Service
{
    public class AuthService
    {
        private UserProperties _user;
        private ConnectionHandler _conn;
        public AuthService(UserProperties user, ConnectionHandler conn)
        {
            _user = user;
            _conn = conn;
        }

        public async Task<bool> Authenticate(string login, string password, string apiPath)
        {
            _conn.RestartClient();
            _conn.SetDefaulthApiPath(apiPath);
            var client = _conn.GetClient();
            var loginDto = new LoginUserDto() { Login = login, Password = password };


            var json = new JavaScriptSerializer().Serialize(loginDto);

            var response = await _conn.Request(HttpMethod.Post ,"api/auth/token", json);

            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }
            string responseBody = await response.Content.ReadAsStringAsync();

            var dto = new JavaScriptSerializer().Deserialize<AuthUserDto>(responseBody);

            _user.SetUserData(dto.Name, dto.Token);
            return true;
        }
    }
}
