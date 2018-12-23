using System.IO;
using System.Net;
using Labs.src.HttpClient.Core.Interfaces;

namespace Labs.HttpClient.Core.Classes
{
    class HttpClient : IHttpClient
    {
        private readonly string url;
        private readonly string port;

        public HttpClient(string url, string port)
        {
            this.url = url;
            this.port = port;
        }

        public string GetData(string method, string content)
        {
            var request = (HttpWebRequest)WebRequest.Create(url+':'+port+'/'+method + (content != "" ? '?' + content : ""));
            string data;
            while (true)
            {
                try
                {
                    using (var response = (HttpWebResponse)request.GetResponse())
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                data = reader.ReadToEnd();
                                break;
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    
                }
            }

            return data;
        }

        public void PostData(string method, string content)
        {
            var request = (HttpWebRequest)WebRequest.Create(url + ':' + port + '/' + method);
            request.Method = "POST";
            var byteArray = System.Text.Encoding.UTF8.GetBytes(content);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            using (var dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {

                    }
                }
            }
        }
    }
}
