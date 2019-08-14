using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UserApiWpf.Infrastructure
{
    public class ConnectionHandler
    {
        protected HttpClient client = new HttpClient();

        protected AuthHeaderHandler _header;

        public ConnectionHandler(AuthHeaderHandler header)
        {
            _header = header;
            UpdateHeaders();
        }

        public void UpdateHeaders()
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = _header.GetAuthenticationHeader();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void SetDefaulthApiPath(string apiPath)
        {
            client.BaseAddress = new Uri(apiPath);
        }

        public HttpClient GetClient()
        {
            return client;
        }

        public async Task<HttpResponseMessage> Request(HttpMethod method, string path, string content = "")
        {
            HttpRequestMessage request = new HttpRequestMessage(method, path)
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };
            return await client.SendAsync(request);
        }
        public void RestartClient()
        {
            client.Dispose();
            client = new HttpClient();
            UpdateHeaders();
        }

        public void Logout()
        {
            _header.ClearHeaderData();
            UpdateHeaders();
        }
    }
}
