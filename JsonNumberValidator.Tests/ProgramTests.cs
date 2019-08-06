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
    }
}
