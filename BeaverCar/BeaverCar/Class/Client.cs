using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace BeaverCar.Class
{
    public static class Client
    {
        public static string Url = "http://192.168.43.65:65226/api"; // Url Api
        /// <summary>
        /// Отправка POST запроса
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="option"></param>
        /// <param name="Body"></param>
        public static void SendRequest<T>(string option, object Body)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    T body = (T)Body;
                    var ser = JsonConvert.SerializeObject(body);
                    client.Headers.Add("Content-Type", "application/json");
                    client.UploadString($"{Url}/{option}", ser);
                }
            }
            catch { }
        }
        /// <summary>
        /// Получение GET ответа
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public static object GetResponse(string option)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("Content-Type", "application/json");
                    return client.DownloadString($"{Url}/{option}");
                }
            }
            catch { return null; }
        }
    }
}
