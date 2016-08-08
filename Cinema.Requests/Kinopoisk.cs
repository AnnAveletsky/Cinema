using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cinema.Requests
{
    public class Kinopoisk
    {
        Uri baseAddress = new Uri("http://api.kinopoisk.cf/");
        public  async Task<string> GetGenres()
        {
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {

                using (var response = await httpClient.GetAsync("getGenres"))
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    return responseData;
                }
            }
        }
    }
}


