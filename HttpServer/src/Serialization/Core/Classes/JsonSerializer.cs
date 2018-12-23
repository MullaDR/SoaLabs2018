using Labs.src.Serialization.Core.Interfaces;
using Newtonsoft.Json;

namespace Labs.src.Serialization.Core.Classes
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