using System.Linq;
using Labs.src.Serialization.Core.Classes;
using Labs.src.Serialization.Data;

namespace Labs.src.Serialization
{
    static class Serialization
    {
        private static Output Transformation(Input inputData)
        {
            var sumResults = inputData.Sums.Sum() * inputData.K;
            var mulResults = inputData.Muls.Aggregate((x, y) => x * y);
            var sortedInputs = inputData.Sums.Concat(inputData.Muls.Select(e => (decimal)e)).OrderBy(e => e).ToArray();
            return new Output()
            {
                SumResult = sumResults,
                MulResult = mulResults,
                SortedInputs = sortedInputs
            };
        }

        public static string Serialize(string serializationType, string data)
        {
            var converter = new Converter();
            var serializeData = converter.Converters[serializationType].Deserialize<Input>(data);
            var output = Transformation(serializeData);
            var deserializeData = converter.Converters[serializationType].Serialize(output);
            return deserializeData;
        }
    }
}
