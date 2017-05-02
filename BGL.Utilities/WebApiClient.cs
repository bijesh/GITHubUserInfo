
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using BGL.Services.Interface.Utilities;

namespace BGL.Utilities
{
   public class WebApiClient : IWebApiClient
    {
        private HttpClient client;

        public WebApiClient()
        {
            client = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string url)
        {
            AddHttpHeader();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<T>();
        }

        private void AddHttpHeader()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue("Mozilla", "5.0")));
        }
    }
}
