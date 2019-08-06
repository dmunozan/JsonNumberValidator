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
    }
}
