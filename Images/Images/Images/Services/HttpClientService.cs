using Images.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Images.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient client;

        public HttpClientService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<string> GetDataAsync(Uri uri)
        {
            return await client.GetStringAsync(uri);
        }
    }
}
