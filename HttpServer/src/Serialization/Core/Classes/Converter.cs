using System.Collections.Generic;
using Labs.src.Serialization.Core.Interfaces;

namespace Labs.src.Serialization.Core.Classes
{
    public class Converter
    {
        public Dictionary<string, ISerializable> Converters { get; set; }

        public Converter()
        {
            Converters = new Dictionary<string, ISerializable>
            {
                { "Json", new JsonSerializer() },
                { "Xml", new XMLSerializer() }
            };
        }
    }
}