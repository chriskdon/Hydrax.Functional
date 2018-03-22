using System;
using Xunit;

namespace Hydrax.Functional.Tests.Run
{
    public class OptionalTests
    { 
        /// <summary>
        /// Test that when creating a optional with Some() that the HasValue
        /// property is set correctly.
        /// </summary>
        [Fact]
        public void Some_WithValue_HasValueIsTrue()
        {
            var opt = Optional.Some<string>("test");

            Assert.True(opt.HasValue);
        }

        /// <summary>
        /// Test that when creating a optional with Mpme() that the HasValue
        /// property is set correctly.
        /// </summary>
        [Fact]
        public void None_Call_HasValueIsFalue()
        {
            var opt = Optional.None<string>();

            Assert.False(opt.HasValue);
        }

        /// <summary>
        /// Test that when ToString is called on Some a formatted string with
        /// the internal value is printed.
        /// </summary>
        [Fact]
        public void ToString_Some_ReturnsFormattedString()
        {
            var opt = "test".Some();

            Assert.Equal("Some(test)", opt.ToString());
        }

        /// <summary>
        /// Test that when ToString is called on None a "None" message is 
        /// returned.
        /// </summary>
        [Fact]
        public void ToString_None_ReturnsNoneString()
        {
            var opt = Optional.None<string>();

            Assert.Equal("None", opt.ToString());
        }
    }
}