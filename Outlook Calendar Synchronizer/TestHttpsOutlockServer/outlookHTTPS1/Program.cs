using System;
using System.Net;
using System.Text;

namespace outlookHTTPS1
{
    internal class Program
    {
        static void Main()
        {
            using (HttpListener listener = new HttpListener())
            {
                Console.WriteLine("Введите префикс для сервера (например, https://+:8080/ | https://localhost:8080/):");
                string prefix = Console.ReadLine();

                listener.Prefixes.Add(prefix);
                listener.Start();
                Console.WriteLine("Сервер запущен. Ожидание запросов...");

                while (true)
                {
                    HttpListenerContext context = listener.GetContext();
                    string requestBody;

                    // Чтение данных из запроса
                    using (var reader = new System.IO.StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
                    {
                        requestBody = reader.ReadToEnd();
                    }

                    Console.WriteLine($"Получен запрос: {requestBody}");

                    //// Формирование ответа
                    //byte[] responseBuffer = Encoding.UTF8.GetBytes("Привет от сервера!");
                    //context.Response.ContentLength64 = responseBuffer.Length;
                    //context.Response.OutputStream.Write(responseBuffer, 0, responseBuffer.Length);
                    //context.Response.OutputStream.Close();

                    // Отправка пустого ответа
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Response.Close();
                }
            }
        }
    }
}
