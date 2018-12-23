using System.IO;
using System.Net;
using System.Threading;

namespace Labs.src.HttpServer.Core.Classes
{
    abstract class HttpServerMethods
    {
        protected delegate void MethodGet(HttpListenerRequest request, HttpListenerResponse response, HttpListener listener, string data);
        protected delegate string MethodPost(HttpListenerRequest request, HttpListenerResponse response, HttpListener listener);

        protected void Ping(HttpListenerRequest request, HttpListenerResponse response, HttpListener listener, string data)
        {
            response.StatusCode = (int)HttpStatusCode.OK;
            using (var stream = response.OutputStream) { }
        }

        protected void Stop(HttpListenerRequest request, HttpListenerResponse response, HttpListener listener, string data)
        {
            response.StatusCode = (int)HttpStatusCode.OK;
            using (var stream = response.OutputStream) { }

            Thread.Sleep(2000);
            listener.Stop();
            listener.Close();
        }

        protected void GetAnswer(HttpListenerRequest request, HttpListenerResponse response, HttpListener listener, string data)
        {
            var buffer = System.Text.Encoding.UTF8.GetBytes(Serialization.Serialization.Serialize("Json", data));
            response.ContentLength64 = buffer.Length;
            using (var writer = response.OutputStream)
            {
                writer.Write(buffer, 0, buffer.Length);
            }
        }

        protected string PostInputData(HttpListenerRequest request, HttpListenerResponse response,
            HttpListener listener)
        {
            string data;
            using (var stream = request.InputStream)
            {
                using (var reader = new StreamReader(stream))
                {
                    data = reader.ReadToEnd();
                }
            }
            response.StatusCode = (int)HttpStatusCode.Accepted;
            using (var stream = response.OutputStream) { }

            return data;
        }
    }
}
