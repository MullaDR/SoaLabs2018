using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Labs.src.Serialization.Core.Interfaces;

namespace Labs.src.Serialization.Core.Classes
{
    public class XMLSerializer : ISerializable
    {
        public T Deserialize<T>(string deserializeObject)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var stringReader = new StringReader(deserializeObject))
            {
                using (var xmlReader = XmlReader.Create(stringReader))
                {
                    return (T)xmlSerializer.Deserialize(xmlReader);
                }
            }
        }

        public string Serialize<T>(T serializeObject)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
                {
                    xmlSerializer.Serialize(xmlWriter, serializeObject, emptyNamespaces);
                    return stringWriter.ToString();
                }
            }
        }
    }
}