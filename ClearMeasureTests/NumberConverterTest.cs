using ClearMeasureLib;

namespace ClearMeasureTests
{

    [TestClass]
    public class NumberConverterTests
    {
        [TestMethod]
        public void GenerateList_ValidInput_ReturnsCorrectList()
        {
            // Arrange
            var converter = new NumberConverter();
            var input = 15;
            var rules = new List<ConversionRule>
            {
                new ConversionRule { DivisibleBy = 3, ReplacementText = "TextFor3" },
                new ConversionRule { DivisibleBy = 5, ReplacementText = "TextFor5" }
            };

            // Act
            var result = converter.GenerateList(input, rules);

            // Assert
            CollectionAssert.AreEqual(new[] { "1", "2", "TextFor3", "4", "TextFor5","TextFor3","7", "8", "TextFor3", "TextFor5", "11", "TextFor3", "13", "14", "TextFor3TextFor5" }, result.ToArray());
        }

        [TestMethod]
        public void GenerateList_InvalidInput_ReturnsEmptyList()
        {
            // Arrange
            var converter = new NumberConverter();
            var input = 0;
            var rules = new List<ConversionRule>();

            // Act
            var result = converter.GenerateList(input, rules);

            // Assert
            Assert.IsTrue(result.Count() == 0);
        }

        [TestMethod]
        public void GenerateList_NullRules_ReturnsOriginalValues()
        {
            // Arrange
            var converter = new NumberConverter();
            var input = 1;
            List<ConversionRule> rules = null!;

            // Act
            var result = converter.GenerateList(input, rules);

            // Assert
            CollectionAssert.AreEqual(new[] { "1", }, result.ToArray());
        }

        [TestMethod]
        public void ConvertValue_NoRules_ReturnsOriginalValue()
        {
            // Arrange
            var converter = new NumberConverter();
            var value = 9;
            var rules = new List<ConversionRule>();

            // Act
            var result = converter.ConvertValue(value, rules);

            // Assert
            Assert.AreEqual(value.ToString(), result);
        }

        [TestMethod]
        public void ConvertValue_WithRules_ReturnsCorrectValue()
        {
            // Arrange
            var converter = new NumberConverter();
            var value = 15;
            var rules = new List<ConversionRule>
            {
                new ConversionRule { DivisibleBy = 3, ReplacementText = "TextFor3" },
                new ConversionRule { DivisibleBy = 5, ReplacementText = "TextFor5" }
            };

            // Act
            var result = converter.ConvertValue(value, rules);

            // Assert
            Assert.AreEqual("TextFor3TextFor5", result);
        }

        [TestMethod]
        public void ConvertValue_DuplicateDivisibleBy_AppendsReplacementText()
        {
            // Arrange
            var converter = new NumberConverter();
            var value = 15;
            var rules = new List<ConversionRule>
            {
                new ConversionRule { DivisibleBy = 3, ReplacementText = "TextFor3" },
                new ConversionRule { DivisibleBy = 5, ReplacementText = "TextFor5" },
                new ConversionRule { DivisibleBy = 3, ReplacementText = "AdditionalTextFor3" }
            };

            // Act
            var result = converter.ConvertValue(value, rules);

            // Assert
            Assert.AreEqual("TextFor3TextFor5AdditionalTextFor3", result);
        }
    }
}