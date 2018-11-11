namespace Serialization.src.Core.Interfaces
{
    public interface ISerializable
    {
        string Serialize<T> (T serializeObject);
        T Deserialize<T> (string deserializeObject); 
    }
}