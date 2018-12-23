
namespace Labs.src.HttpClient.Core.Interfaces
{
    public interface IHttpClient
    {
        string GetData(string method, string content);
        void PostData(string method, string content);
    }
}