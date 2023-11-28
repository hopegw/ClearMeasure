
namespace ClearMeasureLib
{
    /// <summary>
    /// Provides methods for converting numbers to strings based on specified rules.
    /// </summary>
    public class NumberConverter
    {
        /// <summary>
        /// Generates a list of strings based on the provided input and conversion rules.
        /// </summary>
        /// <param name="input">The input value. Any input value less than 1 will return an empty list.</param>
        /// <param name="rules">The list of conversion rules to apply.</param>
        /// <returns>An enumerable of strings representing the converted values.</returns>
        public IEnumerable<string> GenerateList(int input, List<ConversionRule> rules)
        {
            if (input <= 0)
            {
                // Invalid input.
                yield break;
            }

            for (int i = 1; i <= input; i++)
            {
                yield return ConvertValue(i, rules);
            }
        }

        /// <summary>
        /// Converts a numeric value based on the provided conversion rules.
        /// </summary>
        /// <param name="value">The numeric value to convert.</param>
        /// <param name="rules">The list of conversion rules to apply.</param>
        /// <returns>The converted string representation of the value.</returns>
        public string ConvertValue(int value, List<ConversionRule> rules)
        {
            string replacement = string.Empty;

            foreach (var rule in rules)
            {
                if (value % rule.DivisibleBy == 0)
                {
                    replacement += rule.ReplacementText;
                }
            }

            // Return the replacement text if one or more of the rules are hit,
            // otherwise return the original numeric value as a string.
            return replacement == string.Empty ? value.ToString() : replacement;
        }
    }

    /// <summary>
    /// Represents a conversion rule for the NumberConverter class.
    /// </summary>
    public class ConversionRule
    {
        /// <summary>
        /// Gets or sets the divisor for the conversion rule.
        /// </summary>
        public int DivisibleBy { get; set; }

        /// <summary>
        /// Gets or sets the replacement text for the conversion rule.
        /// </summary>
        public string ReplacementText { get; set; }

        public ConversionRule()
        {
            ReplacementText = string.Empty;
        }

        public ConversionRule(int divsibleBy, string replacementText)
        {
            DivisibleBy = divsibleBy;
            ReplacementText = replacementText;
        }
    }
}
