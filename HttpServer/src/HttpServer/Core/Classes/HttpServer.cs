using System;
using System.Net;
using Labs.src.HttpServer.Core.Interfaces;

namespace Labs.src.HttpServer.Core.Classes
{
    class HttpServer : HttpServerMethods, IHttpServer
    {
        private readonly string url;
        private readonly string port;
        private string data;

        public HttpServer(string url, string port)
        {
            this.url = url;
            this.port = port;
        }

        public void Start()
        {
            var listener = new HttpListener();
            var prefix = String.Format("{0}:{1}/", url, port);
            listener.Prefixes.Add(prefix);
            listener.Start();
            Console.WriteLine("Ожидание подключений...");

            while (listener.IsListening)
            {
                var context = listener.GetContext();
                var request = context.Request;
                var response = context.Response;

                try
                {
                    switch (request.HttpMethod)
                    {
                        case "POST":
                            var methodPost = (MethodPost)Delegate.CreateDelegate(typeof(MethodPost), this, request.RawUrl.Trim('/'));
                            data = methodPost(request, response, listener);
                            break;
                        case "GET":
                            var method = (MethodGet)Delegate.CreateDelegate(typeof(MethodGet), this, request.RawUrl.Trim('/'));
                            method(request, response, listener, data);
                            break;
                        default:
                            break;
                    }

                }
                catch (WebException ex)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    using (var stream = response.OutputStream) { }
                }
                catch (ArgumentException ex)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    using (var stream = response.OutputStream) { }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ex");
                }
            }
        }
    }
}
