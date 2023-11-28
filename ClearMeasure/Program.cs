using ClearMeasureLib;

namespace ClearMeasure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberConverter numberConverter = new NumberConverter();
            var rules = new List<ConversionRule>
            {
                new ConversionRule { DivisibleBy = 3, ReplacementText = "Gary" },
                new ConversionRule { DivisibleBy = 5, ReplacementText = "Hope" }
            };

            var result = numberConverter.GenerateList(100, rules);
            foreach (var value in result)
            {
                Console.WriteLine(value);
            }
        }
    }
}