using System;
using Xunit;
using Hydrax.Functional;

namespace Hydrax.Functional.Tests.Run
{
    public class FuncExtensionsCurryingTests
    { 
        /// <summary>
        /// Test that a 2 argument function can be curried.
        /// </summary>
        [Fact]
        public void Curry_Arg2_Curries()
        {
            Func<string, string, string> arg2 = (a, b) => a + b;

            var result = arg2.Curry()("a")("b");

            Assert.Equal("ab", result);
        }

        /// <summary>
        /// Test that a 3 argument function can be curried.
        /// </summary>
        [Fact]
        public void Curry_Arg3_Curries()
        {
            Func<string, string, string, string> arg2 = (a, b, c) => a + b + c;

            var result = arg2.Curry()("a")("b")("c");

            Assert.Equal("abc", result);
        }

        /// <summary>
        /// Test that a 4 argument function can be curried.
        /// </summary>
        [Fact]
        public void Curry_Arg4_Curries()
        {
            Func<string, string, string, string, string> arg2 = (a, b, c, d) => a + b + c + d;

            var result = arg2.Curry()("a")("b")("c")("d");

            Assert.Equal("abcd", result);
        }
    }
}