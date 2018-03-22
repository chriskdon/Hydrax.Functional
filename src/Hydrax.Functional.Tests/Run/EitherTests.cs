using System;
using Xunit;

namespace Hydrax.Functional.Tests.Run
{
    public class EitherTests
    { 
        /// <summary>
        /// Test that when ToString is called on Left a formatted string with
        /// the internal value of left is printed.
        /// </summary>
        [Fact]
        public void ToString_Left_ReturnsFormattedString()
        {
            var either = "test".Left<string, string>();

            Assert.Equal("Left(test)", either.ToString());
        }

        /// <summary>
        /// Test that when ToString is called on Right a formatted string with
        /// the internal value of left is printed.
        /// </summary>
        [Fact]
        public void ToString_Right_ReturnsFormattedString()
        {
            var either = "test".Right<string, string>();

            Assert.Equal("Right(test)", either.ToString());
        }
    }
}