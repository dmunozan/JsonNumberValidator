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
    }
}
