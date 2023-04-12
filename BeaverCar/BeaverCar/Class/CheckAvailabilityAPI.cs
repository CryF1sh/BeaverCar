using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeaverCar.Class
{
    public static class CheckAvailabilityAPI
    {
        /// <summary>
        /// Проверяет доступность подключения к указаному API
        /// </summary>
        /// <param name="apiUrl"></param>
        /// <returns>
        /// True, если доступно подключение или False, если не удалось подключиться
        /// </returns>
        public static bool CheckApiAvailability(string apiUrl)
        {
            var httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }
    }
}
