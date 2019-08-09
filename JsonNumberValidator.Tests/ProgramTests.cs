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
    }
}
