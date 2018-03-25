using System;
using System.Threading.Tasks;
using Hydrax.Functional.Unsafe;
using Xunit;

namespace Hydrax.Functional.Tests.Run
{
    public class ResultExtensionsTests
    {
        /// <summary>
        /// Test that a value is converted to a Failure.
        /// </summary>
        [Fact]
        public void Failure_WithValue_CreatesFailure()
        {
            var failure = "test".Failure();

            Assert.Equal("test", failure.FailureValueOrThrow());
        }

        /// <summary>
        /// Test that when calling match on a success result that
        /// the success action is called.
        /// </summary>
        [Fact]
        public void Match_SuccessAction_SuccessIsCalled() 
        {
            var success = false;

            Result.Success().Match(
              success: () => { success = true; },
              failure: () => throw new Exception("Failure should not be called.")
            );

            Assert.True(success, "Success was not called.");
        }

        /// <summary>
        /// Test that when calling match on a failure result that
        /// the failure action is called.
        /// </summary>
        [Fact]
        public void Match_FailureAction_FailureIsCalled() 
        {
            var failure = false;

            Result.Failure().Match(
              success: () => throw new Exception("Success should not be called."),
              failure: () => { failure = true; }
            );

            Assert.True(failure, "Failure was not called.");
        }

        /// <summary>
        /// Test that when calling match on a success result that
        /// the success func is called.
        /// </summary>
        [Fact]
        public void Match_SuccessFunc_SuccessIsCalled() 
        {
            var result = Result.Success().Match(
              success: () => true,
              failure: () => false
            );

            Assert.True(result, "Success was not called.");
        }

        /// <summary>
        /// Test that when calling match on a failure result that
        /// the failure func is called.
        /// </summary>
        [Fact]
        public void Match_FailureFunc_FailureIsCalled() 
        {
            var result = Result.Failure().Match(
              success: () => false,
              failure: () => true
            );

            Assert.True(result, "Failure was not called.");
        }

        /// <summary>
        /// Test that when calling match on a success result with failure
        /// value that the success action is called.
        /// </summary>
        [Fact]
        public void Match_SuccessWithFailureType_SuccessIsCalled() 
        {
            var success = false;

            Result.Success<string>().Match(
              success: () => { success = true; },
              failure: str => throw new Exception("Failure should not be called.")
            );

            Assert.True(success, "Success was not called.");
        }

        /// <summary>
        /// Test that when calling match on a failure result with value that
        /// the failure action is called.
        /// </summary>
        [Fact]
        public void Match_FailureWithValue_FailureIsCalled() 
        {
            string failure = null;

            Result.Failure<string>("error").Match(
              success: () => throw new Exception("Success should not be called."),
              failure: str => { failure = str; }
            );

            Assert.Equal("error", failure);
        }

        /// <summary>
        /// Test that when calling match on a success result with failure
        /// type that the success func is called.
        /// </summary>
        [Fact]
        public void Match_SuccessFuncWithFailureType_SuccessIsCalled() 
        {
            var result = Result.Success<string>().Match(
              success: () => true,
              failure: str => false
            );

            Assert.True(result, "Success was not called.");
        }

        /// <summary>
        /// Test that when calling match on a failure result with value that
        /// the failure func is called.
        /// </summary>
        [Fact]
        public void Match_FailureFuncWithValue_FailureIsCalled() 
        {
            var result = Result.Failure<string>("error").Match(
              success: () => "fail",
              failure: err => err
            );

            Assert.Equal("error", result);
        }

        /// <summary>
        /// Test that when calling async match on a Success that the 
        /// success action is called.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async void MatchAsync_SuccessAction_SuccessCalled() 
        {
            var called = false;

            await Result.Success().MatchAsync(
                success: async () => { called = true; },
                failure: async () => throw new Exception("Failure should not be called.")
            );

            Assert.True(called);
        }

        /// <summary>
        /// Test that when calling async match on a Failure with a value 
        /// that the failure function is called.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async void MatchAsync_FailureAction_FailureCalled() 
        {
            var called = false;
            
            await Result.Failure().MatchAsync(
                success: async () => throw new Exception("Success should not be called"),
                failure: async () => { called = true; }
            );

            Assert.True(called);
        }

        /// <summary>
        /// Test that when calling async match on a Success that the 
        /// success function is called.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async void MatchAsync_SuccessFunction_SuccessCalled() 
        {
          var result = await Result.Success().MatchAsync(
              success: async () => "test",
              failure: async () => "fail"
          );

          Assert.Equal("test", result);
        }

        /// <summary>
        /// Test that when calling async match on a Failure with a value 
        /// that the failure function is called.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async void MatchAsync_FailureFunction_FailureCalled() 
        {
          var result = await Result.Failure().MatchAsync(
              success: async () => "fail",
              failure: async () => "test"
          );

          Assert.Equal("test", result);
        }

        /// <summary>
        /// Test that when calling async match on a Success that the 
        /// success function is called.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async void MatchAsync_SuccessWithFailureType_SuccessCalled() 
        {
          var result = await Result.Success<string>().MatchAsync(
              success: async () => "test",
              failure: async err => "fail"
          );

          Assert.Equal("test", result);
        }

        /// <summary>
        /// Test that when calling async match on a Failure with a value 
        /// that the failure function is called.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async void MatchAsync_FailureFuncValue_FailureCalled() 
        {
          var result = await Result.Failure<string>("error").MatchAsync(
              success: async () => "fail",
              failure: async err => err
          );

          Assert.Equal("error", result);
        }

        /// <summary>
        /// Test that when calling map failure on a Success map is not called.
        /// </summary>
        [Fact]
        public void MapFailure_Success_MapNotCalled()
        {
            Result.Success()
                .MapFailure<string>(() => throw new Exception("Map should not be called."));
        }

        /// <summary>
        /// Test that when calling map failure on a Failure map is called.
        /// </summary>
        [Fact]
        public void MapFailure_Failure_MapCalled()
        {
            var result = Result.Failure()
                .MapFailure<string>(() => "test");

            Assert.Equal("test", result.FailureValueOrThrow());
        }

        /// <summary>
        /// Test that when calling map failure on a Success map is not called.
        /// </summary>
        [Fact]
        public void MapFailure_SuccessWithFailureType_MapNotCalled()
        {
            Result.Success<string>()
                .MapFailure<string>(() => throw new Exception("Map should not be called."));
        }

        /// <summary>
        /// Test that when calling map failure on a Failure map is called.
        /// </summary>
        [Fact]
        public void MapFailure_FailureWithValue_MapCalled()
        {
            var result = Result.Failure<string>("test")
                .MapFailure(str => str + "_mapped");

            Assert.Equal("test_mapped", result.FailureValueOrThrow());
        }

        /// <summary>
        /// Test that when calling map failure on a Success map is not called.
        /// </summary>
        [Fact]
        public async void MapFailureAsync_Success_MapNotCalled()
        {
            await Result.Success()
                .MapFailureAsync<string>(() => throw new Exception("Map should not be called."));
        }

        /// <summary>
        /// Test that when calling map failure on a Failure map is called.
        /// </summary>
        [Fact]
        public async void MapFailureAsync_Failure_MapCalled()
        {
            var result = await Result.Failure()
                .MapFailureAsync<string>(async () => "test");

            Assert.Equal("test", result.FailureValueOrThrow());
        }

        /// <summary>
        /// Test that when calling map failure on a Success map is not called.
        /// </summary>
        [Fact]
        public async void MapFailureAsync_SuccessWithFailureType_MapNotCalled()
        {
            await Result.Success<string>()
                .MapFailureAsync<string>(() => throw new Exception("Map should not be called."));
        }

        /// <summary>
        /// Test that when calling map failure on a Failure map is called.
        /// </summary>
        [Fact]
        public async void MapFailureAsync_FailureWithValue_MapCalled()
        {
            var result = await Result.Failure("test")
                .MapFailureAsync(async str => str + "_mapped");

            Assert.Equal("test_mapped", result.FailureValueOrThrow());
        }

        /// <summary>
        /// Test that when calling map failure on a Failure map is called.
        /// </summary>
        [Fact]
        public async void MapFailureAsync_Chained_CallsTransformations()
        {
            var result = await Task.FromResult(Result.Failure())
                .MapFailureAsync<string>(async () => "test")
                .MapFailureAsync(async str => str + "_mapped");

            Assert.Equal("test_mapped", result.FailureValueOrThrow());
        }

        /// <summary>
        /// Test that when calling map failure on a Failure map is called.
        /// </summary>
        [Fact]
        public async void MapFailureAsync_ChainedWithType_CallsTransformations()
        {
            var result = await Result.Failure("test")
                .MapFailureAsync(async str => str + "_mapped")
                .MapFailureAsync(async str => str + "_mapped");

            Assert.Equal("test_mapped_mapped", result.FailureValueOrThrow());
        }

        /// <summary>
        /// Test that when calling flat map failure on a Success map 
        /// is not called.
        /// </summary>
        [Fact]
        public void FlatMapFailure_Success_MapNotCalled()
        {
            Result.Success()
                .FlatMapFailure<string>(() => throw new Exception("Map should not be called."));
        }

        /// <summary>
        /// Test that when calling flat map failure on a Failure map is called.
        /// </summary>
        [Fact]
        public void FlatMapFailure_Failure_MapCalled()
        {
            var result = Result.Failure()
                .FlatMapFailure<string>(() => "test".Failure());

            Assert.Equal("test", result.FailureValueOrThrow());
        }

        /// <summary>
        /// Test that when calling flat map failure on a Success map is not called.
        /// </summary>
        [Fact]
        public void FlatMapFailure_SuccessWithFailureType_MapNotCalled()
        {
            Result.Success<string>()
                .FlatMapFailure<string>(() => throw new Exception("Map should not be called."));
        }

        /// <summary>
        /// Test that when calling flat map failure on a Failure map is called.
        /// </summary>
        [Fact]
        public void FlatMapFailure_FailureWithValue_MapCalled()
        {
            var result = Result.Failure<string>("test")
                .FlatMapFailure(str => (str + "_mapped").Failure());

            Assert.Equal("test_mapped", result.FailureValueOrThrow());
        }

        /// <summary>
        /// Test that when calling flat map failure on a Success map is not called.
        /// </summary>
        [Fact]
        public async void FlatMapFailureAsync_Success_MapNotCalled()
        {
            await Result.Success()
                .FlatMapFailureAsync<string>(() => throw new Exception("Map should not be called."));
        }

        /// <summary>
        /// Test that when calling flat map failure on a Failure map is called.
        /// </summary>
        [Fact]
        public async void FlatMapFailureAsync_Failure_MapCalled()
        {
            var result = await Result.Failure()
                .FlatMapFailureAsync<string>(async () => "test".Failure());

            Assert.Equal("test", result.FailureValueOrThrow());
        }

        /// <summary>
        /// Test that when calling flat map failure on a Success map is not called.
        /// </summary>
        [Fact]
        public async void FlatMapFailureAsync_SuccessWithFailureType_MapNotCalled()
        {
            await Result.Success<string>()
                .FlatMapFailureAsync<string>(() => throw new Exception("Map should not be called."));
        }

        /// <summary>
        /// Test that when calling flat map failure on a Failure map is called.
        /// </summary>
        [Fact]
        public async void FlatMapFailureAsync_FailureWithValue_MapCalled()
        {
            var result = await Result.Failure("test")
                .FlatMapFailureAsync(async str => (str + "_mapped").Failure());

            Assert.Equal("test_mapped", result.FailureValueOrThrow());
        }

        /// <summary>
        /// Test that when calling flat map failure on a Failure map is called.
        /// </summary>
        [Fact]
        public async void FlatMapFailureAsync_Chained_CallsTransformations()
        {
            var result = await Task.FromResult(Result.Failure())
                .FlatMapFailureAsync<string>(async () => "test".Failure())
                .FlatMapFailureAsync(async str => (str + "_mapped").Failure());

            Assert.Equal("test_mapped", result.FailureValueOrThrow());
        }

        /// <summary>
        /// Test that when calling flat map failure on a Failure map is called.
        /// </summary>
        [Fact]
        public async void FlatMapFailureAsync_ChainedWithType_CallsTransformations()
        {
            var result = await Result.Failure("test")
                .FlatMapFailureAsync(async str => (str + "_mapped").Failure())
                .FlatMapFailureAsync(async str => (str + "_mapped").Failure());

            Assert.Equal("test_mapped_mapped", result.FailureValueOrThrow());
        }
    }
}