using System;

namespace Labs.src
{
    public class Runner
    {
        static void Main(string[] args)
        {
            var port = Console.ReadLine();
            new HttpServer.Core.Classes.HttpServer("http://localhost", port).Start();
        }
    }
}