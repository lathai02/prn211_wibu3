using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CinemeSystemWF.Requests
{
    public class HttpRequest
    {
        public static HttpRequest Instance { get; } = new();

        public async Task<T?> Get<T>(string url)
        {
            using HttpClient client = new HttpClient();

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(json);
            }
            return default(T);
        }

        public async Task<T?> Post<T>(string url, HttpContent? content = null)
        {
            using HttpClient client = new HttpClient();

            client.Timeout = TimeSpan.FromSeconds(5);

            var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(json);
            }
            return default(T);
        }
    }
}
