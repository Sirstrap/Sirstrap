using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sirstrap.Services
{
    public class HttpService(HttpClient httpClient)
    {
        private HttpClient _httpClient = httpClient;

        public async Task<string> GetStringAsync(string url, int attempts)
        {
            foreach (var attempt in Enumerable.Range(1, attempts))
                try
                {
                    return await _httpClient.GetStringAsync(url);
                }
                catch (Exception)
                {
                    await Task.Delay(1000);
                }

            return string.Empty;
        }

        public async Task<byte[]> GetByteArrayAsync(string url, int attempts)
        {
            foreach (var attempt in Enumerable.Range(1, attempts))
                try
                {
                    return await _httpClient.GetByteArrayAsync(url);
                }
                catch (Exception)
                {
                    await Task.Delay(1000);
                }

            return [];
        }
    }
}
