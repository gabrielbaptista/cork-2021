using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebAppSample.Helper
{
    /// <summary>
    /// Sample class to help sending data
    /// </summary>
    public class WebHelper
    {
        private static HttpClient _httpClient;
        private static string _apiUrl;


        private static HttpClient GetHttpClient()
        {
            if (_httpClient == null)
                _httpClient = new HttpClient();
            return _httpClient;
        }

        public static async Task<HttpResponseMessage> CallApi(HttpMethod method, string api, object objectToSend = null)
        {
            var client = GetHttpClient();
            using (HttpRequestMessage request = new HttpRequestMessage(method, _apiUrl + api))
            {
                if (objectToSend != null)
                {
                    string contentToSend = JsonConvert.SerializeObject(objectToSend);
                    request.Content = new StringContent(contentToSend, Encoding.UTF8, "application/json");
                }
                return await client.SendAsync(request);
            }
        }

        internal static void SetApiUrl(string apiUrl)
        {
            _apiUrl = apiUrl;
        }
    }
}
