using System;

namespace Labs.src
{
    public class Runner
    {
        static void Main(string[] args)
        {
            var port = Console.ReadLine();
            var httpClient = new Labs.HttpClient.Core.Classes.HttpClient("http://91.245.227.5", port);
            httpClient.GetData("study/Ping", "");
            var data = httpClient.GetData("study/GetInputData", "");
            
            httpClient.PostData("WriteAnswer", Serialization.Serialization.Serialize("Json", data));
        }
    }
}