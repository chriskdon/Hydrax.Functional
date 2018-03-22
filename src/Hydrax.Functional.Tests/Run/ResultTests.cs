using System;
using Xunit;

namespace Hydrax.Functional.Tests.Run
{
    public class ResultTests
    {
        /// <summary>
        /// Test that when creating a success result the correct
        /// properties are set.
        /// </summary>
        [Fact]
        public void Success_Called_HasCorrectProperties()
        {
            var result = Result.Success();
            
            Assert.True(result.IsSuccess);
            Assert.False(result.IsFailure);
        }

        /// <summary>
        /// Test that when creating a failure result the correct
        /// properties are set.
        /// </summary>
        [Fact]
        public void Failure_Called_HasCorrectProperties()
        {
            var result = Result.Failure();
            
            Assert.False(result.IsSuccess);
            Assert.True(result.IsFailure);
        }

        /// <summary>
        /// Test that when ToString is called on Success the success message
        /// is returned.
        /// </summary>
        [Fact]
        public void ToString_Success_ReturnsSuccess()
        {
            var result = Result.Success();

            Assert.Equal("Success", result.ToString());
        }

        /// <summary>
        /// Test that when ToString is called on Failure the failure message
        /// is returned.
        /// </summary>
        [Fact]
        public void ToString_Failure_ReturnsFailure()
        {
            var result = Result.Failure();

            Assert.Equal("Failure", result.ToString());
        }

        /// <summary>
        /// Test that when ToString is called on Failure the failure message
        /// with the value is returned.
        /// </summary>
        [Fact]
        public void ToString_FailureWithValue_ReturnsFailureWithValue()
        {
            var result = Result.Failure("test");

            Assert.Equal("Failure(test)", result.ToString());
        }
    }
}
