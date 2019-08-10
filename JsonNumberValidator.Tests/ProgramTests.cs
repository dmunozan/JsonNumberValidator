using System;
using Xunit;

namespace JsonNumberValidator.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void IsValidJsonNumberWhenNullShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.IsValidJsonNumber(null));
        }

        [Fact]
        public void IsValidJsonNumberWhenEmptyShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.IsValidJsonNumber(""));
        }

        [Fact]
        public void IsValidJsonNumberWhen0ShouldReturnValid()
        {
            Assert.Equal("Valid", Program.IsValidJsonNumber("0"));
        }

        [Fact]
        public void IsValidJsonNumberWhenAShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.IsValidJsonNumber("A"));
        }

        [Fact]
        public void IsValidJsonNumberWhen123AShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.IsValidJsonNumber("123A"));
        }

        [Fact]
        public void IsValidJsonNumberWhen1B35ShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.IsValidJsonNumber("1B35"));
        }

        [Fact]
        public void IsValidJsonNumberWhenNegative0ShouldReturnValid()
        {
            Assert.Equal("Valid", Program.IsValidJsonNumber("-0"));
        }

        [Fact]
        public void IsValidJsonNumberWhenNegativeShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.IsValidJsonNumber("-"));
        }

        [Fact]
        public void IsValidJsonNumberWhenNegativePointShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.IsValidJsonNumber("-."));
        }

        [Fact]
        public void IsValidJsonNumberWhen0point2ShouldReturnValid()
        {
            Assert.Equal("Valid", Program.IsValidJsonNumber("0.2"));
        }

        [Fact]
        public void IsValidJsonNumberWhen012ShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.IsValidJsonNumber("012"));
        }

        [Fact]
        public void IsValidJsonNumberWhen0pointpoint2ShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.IsValidJsonNumber("0..2"));
        }

        [Fact]
        public void IsValidJsonNumberWhen0point2pointShouldReturnInvalid()
        {
            Assert.Equal("Invalid", Program.IsValidJsonNumber("0.2."));
        }

        [Fact]
        public void IsValidJsonNumberWhen1e0ShouldReturnValid()
        {
            Assert.Equal("Valid", Program.IsValidJsonNumber("1e0"));
        }

        [Fact]
        public void IsValidJsonNumberWhen1E0ShouldReturnValid()
        {
            Assert.Equal("Valid", Program.IsValidJsonNumber("1E0"));
        }

        [Fact]
        public void IsValidJsonNumberWhen1EPositive2ShouldReturnValid()
        {
            Assert.Equal("Valid", Program.IsValidJsonNumber("1E+2"));
        }

        [Fact]
        public void IsValidPointFormatWhen1point02ShouldReturnTrue()
        {
            Assert.True(Program.IsValidPointFormat("1.02", 1, out int incrementIndex));
        }

        [Fact]
        public void IsValidPointFormatWhen0pointpoint2ShouldReturnFalse()
        {
            Assert.False(Program.IsValidPointFormat("0..2", 1, out int incrementIndex));
        }

        [Fact]
        public void IsValidPointFormatWhenpoint2ShouldReturnFalse()
        {
            Assert.False(Program.IsValidPointFormat(".2", 0, out int incrementIndex));
        }

        [Fact]
        public void IsValidPointFormatWhen2pointShouldReturnFalse()
        {
            Assert.False(Program.IsValidPointFormat("2.", 1, out int incrementIndex));
        }

        [Fact]
        public void IsValidPointFormatWhenNegative0point2pointShouldReturnFalse()
        {
            Assert.False(Program.IsValidPointFormat("-0.2.", 2, out int incrementIndex));
        }

        [Fact]
        public void IsValidZeroFormatWhen0ShouldReturnTrue()
        {
            Assert.True(Program.IsValidZeroFormat("0", 0, out int newIndex));
        }

        [Fact]
        public void IsValidZeroFormatWhenNegative0ShouldReturnTrue()
        {
            Assert.True(Program.IsValidZeroFormat("-0", 1, out int newIndex));
        }

        [Fact]
        public void IsValidZeroFormatWhen01ShouldReturnFalse()
        {
            Assert.False(Program.IsValidZeroFormat("01", 0, out int newIndex));
        }

        [Fact]
        public void IsValidZeroFormatWhen0Point1ShouldReturnTrue()
        {
            Assert.True(Program.IsValidZeroFormat("0.1", 0, out int newIndex));
        }

        [Fact]
        public void IsValidZeroFormatWhen0LetterShouldReturnFalse()
        {
            Assert.False(Program.IsValidZeroFormat("0R", 0, out int newIndex));
        }

        [Fact]
        public void IsValidZeroFormatWhen0eNegative1ShouldReturnTrue()
        {
            Assert.True(Program.IsValidZeroFormat("0e-1", 0, out int newIndex));
        }

        [Fact]
        public void IsValidMinusSignFormatWhenNegativeShouldReturnFalse()
        {
            Assert.False(Program.IsValidMinusSignFormat("-", 0, out int newIndex));
        }

        [Fact]
        public void IsValidMinusSignFormatWhenNegative0ShouldReturnTrue()
        {
            Assert.True(Program.IsValidMinusSignFormat("-0", 0, out int newIndex));
        }

        [Fact]
        public void IsValidMinusSignFormatWhenNegativePointShouldReturnFalse()
        {
            Assert.False(Program.IsValidMinusSignFormat("-.", 0, out int newIndex));
        }

        [Fact]
        public void IsValidMinusSignFormatWhenNegativeEShouldReturnFalse()
        {
            Assert.False(Program.IsValidMinusSignFormat("-e", 0, out int newIndex));
        }

        [Fact]
        public void IsValidMinusSignFormatWhenNegativeLetterShouldReturnFalse()
        {
            Assert.False(Program.IsValidMinusSignFormat("-r", 0, out int newIndex));
        }

        [Fact]
        public void IsValidMinusSignFormatWhenNegativePositiveShouldReturnFalse()
        {
            Assert.False(Program.IsValidMinusSignFormat("-+", 0, out int newIndex));
        }

        [Fact]
        public void IsValidEFormatWheneShouldReturnFalse()
        {
            Assert.False(Program.IsValidEFormat("e", 0, out int newIndex));
        }

        [Fact]
        public void IsValidEFormatWhene0ShouldReturnFalse()
        {
            Assert.False(Program.IsValidEFormat("e0", 0, out int newIndex));
        }

        [Fact]
        public void IsValidEFormatWhen1e0ShouldReturnTrue()
        {
            Assert.True(Program.IsValidEFormat("1e0", 1, out int newIndex));
        }

        [Fact]
        public void IsValidEFormatWhen1eLetterShouldReturnFalse()
        {
            Assert.False(Program.IsValidEFormat("1ef", 1, out int newIndex));
        }

        [Fact]
        public void IsValidEFormatWhen1eNegativeShouldReturnFalse()
        {
            Assert.False(Program.IsValidEFormat("1e-", 1, out int newIndex));
        }
    }
}
