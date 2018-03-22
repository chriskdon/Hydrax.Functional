using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Hydrax.Functional.Unsafe;

namespace Hydrax.Functional.Tests.Run
{
    public class OptionalExtensionsTests
    {
        /// <summary>
        /// Test that when using some the extension on a value that
        /// a Some Optional is created.
        /// </summary>
        [Fact]
        public void Some_WithValue_CreatesSome() 
        {
            var result = "test".Some();

            Assert.True(result.HasValue);
            Assert.Equal("test", result.ValueOrThrow());
        }

        /// <summary>
        /// Test that when using some the extension on a null value that
        /// a Some Optional is created. 
        /// 
        /// Calling Some should always create a Some even if it's called on
        /// null.
        /// </summary>
        [Fact]
        public void Some_WithNull_CreatesSome() 
        {
            var result = ((string) null).Some();

            Assert.True(result.HasValue);
            Assert.Null(result.ValueOrThrow());
        }

        /// <summary>
        /// Test that a Some Optional is created from an async task.
        /// </summary>
        [Fact]
        public async void SomeAsync_WithTaskValue_CreatesSome()
        {
            var result = await Task.FromResult("test").SomeAsync();

            Assert.True(result.HasValue);
            Assert.Equal("test", result.ValueOrThrow());
        }

        /// <summary>
        /// Test that a Some Optional is created if the value is not null.
        /// </summary>
        [Fact]
        public void SomeNotNull_WithValue_CreatesSome()
        {
            var result = "test".SomeNotNull();

            Assert.Equal("test", result.ValueOrThrow());
        }

        /// <summary>
        /// Test that a None Optional is created if the value is null.
        /// </summary>
        [Fact]
        public void SomeNotNull_WithNullValue_CreatesNone()
        {
            var result = ((string) null).SomeNotNull();

            Assert.False(result.HasValue);
        }

        /// <summary>
        /// Test that when calling Match on Some optional that
        /// the some action is called.
        /// </summary>
        [Fact]
        public void Match_SomeAction_SomeIsCalledWithValue() 
        {
            string some = null;

            Optional.Some<string>("test").Match(
              some: str => { some = str; },
              none: () => throw new Exception("None should not be called.")
            );

            Assert.Equal("test", some);
        }

        /// <summary>
        /// Test that when calling Match on None optional that
        /// the none action is called.
        /// </summary>
        [Fact]
        public void Match_NoneAction_NoneIsCalled() 
        {
            bool none = false;

            Optional.None<string>().Match(
              some: str => throw new Exception("Some should not be called."),
              none: () => { none = true; }
            );

            Assert.True(none, "None should have been called.");
        }

        /// <summary>
        /// Test that when calling Match on Some optional that
        /// the some func is called.
        /// </summary>
        [Fact]
        public void Match_SomeFunc_SomeIsCalledWithValue() 
        {
            var result = Optional.Some<string>("some").Match(
              some: str => str + "_called",
              none: () => throw new Exception("None should not be called.")
            );

            Assert.Equal("some_called", result);
        }

        /// <summary>
        /// Test that when calling Match on None optional that
        /// the none func is called.
        /// </summary>
        [Fact]
        public void Match_NoneFunc_NoneIsCalled() 
        {
            var result = Optional.None<string>().Match(
              some: str => throw new Exception("Some should not be called."),
              none: () => "none_called"
            );

            Assert.Equal("none_called", result);
        }

        /// <summary>
        /// Test that when calling MatchAsync on Some optional that
        /// the some action is called.
        /// </summary>
        [Fact]
        public async void MatchAsync_SomeAction_SomeIsCalledWithValue() 
        {
            string some = null;

            await Optional.Some<string>("test").MatchAsync(
              some: async str => { some = str; },
              none: async () => throw new Exception("None should not be called.")
            );

            Assert.Equal("test", some);
        }

        /// <summary>
        /// Test that when calling MatchAsync on None optional that
        /// the none action is called.
        /// </summary>
        [Fact]
        public async void MatchAsync_NoneAction_NoneIsCalled() 
        {
            bool none = false;

            await Optional.None<string>().MatchAsync(
              some: async str => throw new Exception("Some should not be called."),
              none: async () => { none = true; }
            );

            Assert.True(none, "None should have been called.");
        }

        /// <summary>
        /// Test that when calling MatchAsync on Some optional that
        /// the some func is called.
        /// </summary>
        [Fact]
        public async void MatchAsync_SomeFunc_SomeIsCalledWithValue() 
        {
            var result = await Optional.Some<string>("some").MatchAsync(
              some: async str => str + "_called",
              none: async () => throw new Exception("None should not be called.")
            );

            Assert.Equal("some_called", result);
        }

        /// <summary>
        /// Test that when calling MatchAsync on None optional that
        /// the none func is called.
        /// </summary>
        [Fact]
        public async void MatchAsync_NoneFunc_NoneIsCalled() 
        {
            var result = await Optional.None<string>().MatchAsync(
              some: async str => throw new Exception("Some should not be called."),
              none: async () => "none_called"
            );

            Assert.Equal("none_called", result);
        }

        /// <summary>
        /// Test that when calling Map on a Some that a new optional
        /// is created with the value of the original mapped.
        /// </summary>
        [Fact]
        public void Map_Some_MapsToNewValue()
        {
            var result = Optional.Some("test")
              .Map(p => p + "_mapped");

            Assert.Equal("test_mapped", result.ValueOrThrow());
        }

        /// <summary>
        /// Test that when calling Map on a None that a new optional
        /// is created with the new type.
        /// </summary>
        [Fact]
        public void Map_None_ChangesType()
        {
            // We're checking the type so if this compiles the test passed.
            Optional<int> result = Optional.None<string>()
              .Map(p => 100);
        }

        /// <summary>
        /// Test that when calling Map on a None that the map function is 
        /// not called.
        /// </summary>
        [Fact]
        public void Map_None_SomeNotCalled()
        {
            var ran = false;

            // We're checking the type so if this compiles the test passed.
            var result = Optional.None<string>()
              .Map(p => {
                  ran = true;
                  return 100;
              });

              Assert.False(ran);
        }

        /// <summary>
        /// Test that when calling MapAsync on a Some that a new optional
        /// is created with the value of the original mapped.
        /// </summary>
        [Fact]
        public async void MapAsync_Some_MapsToNewValue()
        {
            var result = await Optional.Some("test")
              .MapAsync(async p => p + "_mapped");

            Assert.Equal("test_mapped", result.ValueOrThrow());
        }

        /// <summary>
        /// Test that when calling MapAsync on a None that a new optional
        /// is created with the new type.
        /// </summary>
        [Fact]
        public async void MapAsync_None_ChangesType()
        {
            // We're checking the type so if this compiles the test passed.
            Optional<int> result = await Optional.None<string>()
              .MapAsync(async p => 100);
        }

        /// <summary>
        /// Test that when calling MapAsync on a None that the map function is 
        /// not called.
        /// </summary>
        [Fact]
        public async void MapAsync_None_SomeNotCalled()
        {
            var ran = false;

            // We're checking the type so if this compiles the test passed.
            var result = await Optional.None<string>()
              .MapAsync(async p => {
                  ran = true;
                  return 100;
              });

              Assert.False(ran);
        }

        /// <summary>
        /// Test that MapAsync can be chained.
        /// </summary>
        [Fact]
        public async void MapAsync_Chained_TransformationsAreCalled()
        {
            var result = await Optional.Some("some")
              .MapAsync(async str => str + "_1")
              .MapAsync(async str => str + "_2");

            Assert.Equal("some_1_2", result.ValueOrThrow());
        }

        /// <summary>
        /// Test that when a Some Optional is retuend in the FlatMap that
        /// the value is flattened.
        /// </summary>
        [Fact]
        public void FlatMap_SomeReturned_IsFlattened() 
        {
            var result = Optional.Some("test")
              .FlatMap(p => (p + "_flat").Some());

            Assert.Equal("test_flat", result.ValueOrThrow());
        }

        /// <summary>
        /// Test that when a None Optional is retuend in the FlatMap that
        /// the value is flattened.
        /// </summary>
        [Fact]
        public void FlatMap_NoneReturned_IsFlattened() 
        {
            // Check type
            Optional<string> result = Optional.Some("test")
              .FlatMap(p => Optional.None<string>());

            Assert.False(result.HasValue);
        }

        /// <summary>
        /// Test that when a Some Optional is retuend in the FlatMapAsync that
        /// the value is flattened.
        /// </summary>
        [Fact]
        public async void FlatMapAsync_SomeReturned_IsFlattened() 
        {
            var result = await Optional.Some("test")
              .FlatMapAsync(async p => (p + "_flat").Some());

            Assert.Equal("test_flat", result.ValueOrThrow());
        }

        /// <summary>
        /// Test that when a None Optional is retuend in the FlatMapAsync that
        /// the value is flattened.
        /// </summary>
        [Fact]
        public async void FlatMapAsync_NoneReturned_IsFlattened() 
        {
            // Check type
            Optional<string> result = await Optional.Some("test")
              .FlatMapAsync(async p => Optional.None<string>());

            Assert.False(result.HasValue);
        }

        /// <summary>
        /// Test that FlatMapAsync can be chanined.
        /// </summary>
        [Fact]
        public async void FlatMapAsync_Chaining_TransformationsAreCalled()
        {
            var result = await Optional.Some("test")
                .FlatMapAsync(async p => (p + "_mapped").Some())
                .FlatMapAsync(async p => (p + "_mapped").Some());

            Assert.Equal("test_mapped_mapped", result.ValueOrThrow());
        }

        /// <summary>
        /// Test that when calling ValueOr on a Some that the value stored in
        /// the Some is returned.
        /// </summary>
        [Fact]
        public void ValueOr_Some_ReturnsValueFromSome()
        {
            var value = Optional.Some("test").ValueOr("fail");

            Assert.Equal("test", value);
        }

        /// <summary>
        /// Test that when calling ValueOr on a None that the "or" value passed
        /// in is used.
        /// </summary>
        [Fact]
        public void ValueOr_None_ReturnsOrValue()
        {
            var value = Optional.None<string>().ValueOr("test");

            Assert.Equal("test", value);
        }

        /// <summary>
        /// Test that when calling ValueOr on a Some that the value stored in
        /// the Some is returned and the or function is not called.
        /// </summary>
        [Fact]
        public void ValueOr_SomeLazy_ReturnsValueFromSome()
        {
            var value = Optional.Some("test").ValueOr(() => {
                throw new Exception("This should not be called.");
            });

            Assert.Equal("test", value);
        }

        /// <summary>
        /// Test that when creating a Result from a Some Optional that it is
        /// a Success Result.
        /// </summary>
        [Fact]
        public void ToResult_Some_CreatesSuccessResult()
        {
            var result = Optional.Some("test").ToResult();

            Assert.True(result.IsSuccess);
        }

        /// <summary>
        /// Test that when creating a Result from a None Optional that it is
        /// a Failure Result.
        /// </summary>
        [Fact]
        public void ToResult_None_CreatesFailureResult()
        {
            var result = Optional.None<string>().ToResult();

            Assert.True(result.IsFailure);
        }

        /// <summary>
        /// Test that when the predicate returns true that a None optional
        /// is returned from a Some.
        /// </summary>
        [Fact]
        public void NoneWhen_TruePredicate_CreatesNoneFromSome()
        {
            var result = 100.Some().NoneWhen(p => p > 50);

            Assert.False(result.HasValue);
        }

        /// <summary>
        /// Test that when the predicate returns false that a Some optional
        /// is returned from a Some.
        /// </summary>
        [Fact]
        public void NoneWhen_FalsePredicate_CreatesSomeFromSome()
        {
            var result = 100.Some().NoneWhen(p => p < 50);

            Assert.Equal(100, result.ValueOrThrow());
        }

        /// <summary>
        /// Test that a None optional is returned from a None.
        /// </summary>
        [Fact]
        public void NoneWhen_Predicate_CreatesNoneFromNone()
        {
            var result = Optional.None<int>().NoneWhen(p => p > 50);

            Assert.False(result.HasValue);
        }

        /// <summary>
        /// Test that when the predicate returns true that a Some optional
        /// is returned from a Some.
        /// </summary>
        [Fact]
        public void SomeWhen_TruePredicate_CreatesSomeFromSome()
        {
            var result = 100.Some().SomeWhen(p => p > 50);

            Assert.Equal(100, result.ValueOrThrow());
        }

        /// <summary>
        /// Test that when the predicate returns false that a None optional
        /// is returned from a Some.
        /// </summary>
        [Fact]
        public void SomeWhen_FalsePredicate_CreatesNoneFromSome()
        {
            var result = 100.Some().SomeWhen(p => p < 50);

            Assert.False(result.HasValue);
        }

        /// <summary>
        /// Test that a None optional is returned from a None.
        /// </summary>
        [Fact]
        public void SomeWhen_Predicate_CreatesNoneFromNone()
        {
            var result = Optional.None<int>().SomeWhen(p => p > 50);

            Assert.False(result.HasValue);
        }
    }
}