using Cinema.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cinema.Requests
{
    public class Rutube
    {
        public static Uri baseAddress = new Uri("http://rutube.ru/api");
        public static async Task<string> GetTV(GetRutubeTV getRutubeTV)
        {
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {

                using (var response = await httpClient.GetAsync("metainfo/tv"))
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    return responseData;
                }
            }
        }
    }
}
