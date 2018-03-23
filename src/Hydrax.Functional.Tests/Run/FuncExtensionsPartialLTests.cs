using System;
using Xunit;
using Hydrax.Functional;

namespace Hydrax.Functional.Tests.Run
{
    public class FuncExtensionsPartialLTests
    { 
        /// <summary>
        /// Test that a 2 argument function can be partially applied to left.
        /// </summary>
        [Fact]
        public void PartialL_Arg2_AppliesLeft()
        {
            Func<string, string, string> arg2 = (a, b) => a + b;

            var result = arg2.PartialL("a")("b");

            Assert.Equal("ab", result);
        }

        /// <summary>
        /// Test that a 3 argument function can be partially applied to left.
        /// </summary>
        [Fact]
        public void PartialL_Arg3_AppliesLeft()
        {
            Func<string, string, string, string> arg2 = (a, b, c) => a + b + c;

            var result = arg2.PartialL("a", "b")("c");

            Assert.Equal("abc", result);
        }

        /// <summary>
        /// Test that a 4 argument function can be partially applied to left.
        /// </summary>
        [Fact]
        public void PartialL_Arg4_AppliesLeft()
        {
            Func<string, string, string, string, string> arg2 = (a, b, c, d) => a + b + c + d;

            var result = arg2.PartialL("a", "b", "c")("d");

            Assert.Equal("abcd", result);
        }

        /// <summary>
        /// Test that a 5 argument function can be partially applied to left.
        /// </summary>
        [Fact]
        public void PartialL_Arg5_AppliesLeft()
        {
            Func<string, string, string, string, string, string> arg2 = 
                (a, b, c, d, e) => a + b + c + d + e;

            var result = arg2.PartialL("a", "b", "c", "d")("e");

            Assert.Equal("abcde", result);
        }

        /// <summary>
        /// Test that a 6 argument function can be partially applied to left.
        /// </summary>
        [Fact]
        public void PartialL_Arg6_AppliesLeft()
        {
            Func<string, string, string, string, string, string, string> arg2 = 
                (a, b, c, d, e, f) => a + b + c + d + e + f;

            var result = arg2.PartialL("a", "b", "c", "d", "e")("f");

            Assert.Equal("abcdef", result);
        }

        /// <summary>
        /// Test that a 7 argument function can be partially applied to left.
        /// </summary>
        [Fact]
        public void PartialL_Arg7_AppliesLeft()
        {
            Func<string, string, string, string, string, string, string, string> arg2 = 
                (a, b, c, d, e, f, g) => a + b + c + d + e + f + g;

            var result = arg2.PartialL("a", "b", "c", "d", "e", "f")("g");

            Assert.Equal("abcdefg", result);
        }

        /// <summary>
        /// Test that a 8 argument function can be partially applied to left.
        /// </summary>
        [Fact]
        public void PartialL_Arg8_AppliesLeft()
        {
            Func<string, string, string, string, string, string, string, string, string> arg2 = 
                (a, b, c, d, e, f, g, h) => a + b + c + d + e + f + g + h;

            var result = arg2.PartialL("a", "b", "c", "d", "e", "f", "g")("h");

            Assert.Equal("abcdefgh", result);
        }

        /// <summary>
        /// Test that a 9 argument function can be partially applied to left.
        /// </summary>
        [Fact]
        public void PartialL_Arg9_AppliesLeft()
        {
            Func<string, string, string, string, string, string, string, string, string, string> arg2 = 
                (a, b, c, d, e, f, g, h, i) => a + b + c + d + e + f + g + h + i;

            var result = arg2.PartialL("a", "b", "c", "d", "e", "f", "g", "h")("i");

            Assert.Equal("abcdefghi", result);
        }
    }
}