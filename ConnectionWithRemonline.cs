using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace remsklad_C_
{
    public class ConnectionWithRemonline
    {
        protected static string responseToken;


        public static async Task PostRequestAsync()
        {
            WebRequest request = WebRequest.Create("https://api.remonline.ru/token/new");
            request.Method = "POST"; // для отправки используется метод Post
                                     // данные для отправки
            string data = "api_key=a49d338c1466430e9568ca6ea77c5cda";
            // преобразуем данные в массив байтов
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            // устанавливаем тип содержимого - параметр ContentType
            request.ContentType = "application/x-www-form-urlencoded";
            // Устанавливаем заголовок Content-Length запроса - свойство ContentLength
            request.ContentLength = byteArray.Length;

            //записываем данные в поток запроса
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string token = reader.ReadToEnd();
                    ConnectionWithRemonline.responseToken = token;
                }
            }
            response.Close();
            Console.WriteLine("Запрос выполнен...");
        }

        public static async Task<string> getToken()
        {
            await PostRequestAsync();
            var jsonResponceToken =  ConnectionWithRemonline.responseToken;
            ResponceToken responceToken = JsonConvert.DeserializeObject<ResponceToken>(jsonResponceToken);
            return responceToken.token;
            

        }

        public static string getPageFromRemonline(string token,int page)
        {
            // Адрес ресурса, к которому выполняется запрос
            string url = $"https://api.remonline.ru/warehouse/goods/28208?page={page}&token={token}";

            // Создаём объект WebClient
            using  (var webClient = new WebClient())
            {
                // Выполняем запрос по адресу и получаем ответ в виде строки
                var response =  webClient.DownloadString(url);
                
                return response;
            }
            
        }




    }
}
