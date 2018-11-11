using Newtonsoft.Json;
using Serialization.src.Core.Interfaces;

namespace Serialization.src.Core.Classes
{
    public class JsonSerializer : ISerializable
    {
        public T Deserialize<T> (string deserializeObject)
        {
            return JsonConvert.DeserializeObject<T>(deserializeObject);
        }

        public string Serialize<T> (T serializeObject)
        {
            return JsonConvert.SerializeObject(serializeObject);
        }
    }
}