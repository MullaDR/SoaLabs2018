using System.Collections.Generic;
using Serialization.src.Core.Interfaces;

namespace Serialization.src.Core.Classes
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