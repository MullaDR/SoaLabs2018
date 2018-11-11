using System.Linq;
using Serialization.src.Core.Classes;
using Serialization.src.Data;

namespace Serialization.src
{
    public class Runner
    {
        static public Output Transformation(Input inputData)
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

        static void Main(string[] args)
        {
            var serializationType = System.Console.ReadLine();
            var data = System.Console.ReadLine();
            var converter =  new Converter();
            var serializeData = converter.Converters[serializationType].Deserialize<Input>(data);
            var output = Transformation(serializeData);
            var deserializeData = converter.Converters[serializationType].Serialize(output);
            System.Console.WriteLine(deserializeData);
        }
    }
}