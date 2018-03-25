using System;
using System.Linq;
using Hydrax.Functional.Unsafe;
using Xunit;

namespace Hydrax.Functional.Tests.Run
{
    public class EitherExtensionsTests
    {   
        /// <summary>
        /// Test that a Left Either is created.
        /// </summary>
        [Fact]
        public void Left_WithValue_CreatesLeftEither() 
        {
            var result = "test".Left<string, int>();

            Assert.True(result.IsLeft);
            Assert.Equal("test", result.LeftValueOrThrow());
        }

        /// <summary>
        /// Test that a Right Either is created.
        /// </summary>
        [Fact]
        public void Right_WithValue_CreatesRightEither() 
        {
            var result = "test".Right<int, string>();

            Assert.True(result.IsRight);
            Assert.Equal("test", result.RightValueOrThrow());
        }

        /// <summary>
        /// Test that when calling match on a Left Either that the left
        /// action is called.
        /// </summary>
        [Fact]
        public void Match_LeftAction_CallsLeftAction() 
        {
            string value = null;

            Either.Left<string, string>("left").Match(
              left => { value = left; },
              right => throw new Exception("Right should not be called."));

            Assert.Equal("left", value);
        }

        /// <summary>
        /// Test that when calling match on a Right Either that the right
        /// action is called.
        /// </summary>
        [Fact]
        public void Match_RightAction_CallsRightAction() 
        {
            string value = null;

            Either.Right<string, string>("right").Match(
              left => throw new Exception("Right should not be called."),
              right => { value = right; });

            Assert.Equal("right", value);
        }

        /// <summary>
        /// Test that when calling match on a Left Either that the left
        /// function is called.
        /// </summary>
        [Fact]
        public void Match_LeftFunction_CallsLeftFunction() 
        {
            var value = Either.Left<string, string>("left").Match(
              left => left,
              right => throw new Exception("Right should not be called."));

            Assert.Equal("left", value);
        }

        /// <summary>
        /// Test that when calling match on a Right Either that the right
        /// function is called.
        /// </summary>
        [Fact]
        public void Match_RightFunction_CallsRightFunction() 
        {
            var value = Either.Right<string, string>("right").Match(
              left => throw new Exception("Right should not be called."),
              right => right);

            Assert.Equal("right", value);
        }

        /// <summary>
        /// Test that when calling match on a Left Either that the left
        /// async function is called.
        /// </summary>
        [Fact]
        public async void MatchAsync_LeftFunction_CallsLeftFunction() 
        {
            var value = await Either.Left<string, string>("left").MatchAsync(
              async left => left,
              async right => throw new Exception("Right should not be called."));

            Assert.Equal("left", value);
        }

        /// <summary>
        /// Test that when calling match on a Right Either that the right
        /// async function is called.
        /// </summary>
        [Fact]
        public async void MatchAsync_RightFunction_CallsRightFunction() 
        {
            var value = await Either.Right<string, string>("right").Match(
              async left => throw new Exception("Right should not be called."),
              async right => right);

            Assert.Equal("right", value);
        }
        
        /// <summary>
        /// Test that when the Either is a Left the value is mapped.
        /// </summary>
        [Fact]
        public void MapLeft_WithLeft_MapsValue()
        {
            var value = Either.Left<string, string>("test")
                .MapLeft(str => str + "_mapped");

            Assert.Equal("test_mapped", value.LeftValueOrThrow());
        }

        /// <summary>
        /// Test that when the Either is a Right nothing is mapped.
        /// </summary>
        [Fact]
        public void MapLeft_WithRight_DoesNothing()
        {
            var value = Either.Right<string, string>("test")
                .MapLeft(str => str + "_mapped");

            Assert.Equal("test", value.RightValueOrThrow());
        }

        /// <summary>
        /// Test that when the Either is a Right the value is mapped.
        /// </summary>
        [Fact]
        public void MapRight_WithRight_MapsValue()
        {
            var value = Either.Right<string, string>("test")
                .MapRight(str => str + "_mapped");

            Assert.Equal("test_mapped", value.RightValueOrThrow());
        }

        /// <summary>
        /// Test that when the Either is a Left nothing is mapped.
        /// </summary>
        [Fact]
        public void MapRight_WithLeft_DoesNothing()
        {
            var value = Either.Left<string, string>("test")
                .MapRight(str => str + "_mapped");

            Assert.Equal("test", value.LeftValueOrThrow());
        }

        /// <summary>
        /// Test that when the Either is a Left the value is async mapped.
        /// </summary>
        [Fact]
        public async void MapLeftAsync_WithLeft_MapsValue()
        {
            var value = await Either.Left<string, string>("test")
                .MapLeftAsync(async str => str + "_mapped");

            Assert.Equal("test_mapped", value.LeftValueOrThrow());
        }

        /// <summary>
        /// Test that when the Either is a Right nothing is async mapped.
        /// </summary>
        [Fact]
        public async void MapLeftAsync_WithRight_DoesNothing()
        {
            var value = await Either.Right<string, string>("test")
                .MapLeftAsync(async str => str + "_mapped");

            Assert.Equal("test", value.RightValueOrThrow());
        }

        /// <summary>
        /// Test that when the Either is a Right the value is async mapped.
        /// </summary>
        [Fact]
        public async void MapRightAsync_WithRight_MapsValue()
        {
            var value = await Either.Right<string, string>("test")
                .MapRightAsync(async str => str + "_mapped");

            Assert.Equal("test_mapped", value.RightValueOrThrow());
        }

        /// <summary>
        /// Test that when the Either is a Left nothing is async mapped.
        /// </summary>
        [Fact]
        public async void MapRightAsync_WithLeft_DoesNothing()
        {
            var value = await Either.Left<string, string>("test")
                .MapRightAsync(async str => str + "_mapped");

            Assert.Equal("test", value.LeftValueOrThrow());
        }

        /// <summary>
        /// Test that map left async can be chained.
        /// </summary>
        [Fact]
        public async void MapLeftAsync_Chained_CallsTransformations()
        {
            var value = await Either.Left<string, string>("test")
                .MapLeftAsync(async str => str + "_mapped")
                .MapLeftAsync(async str => str + "_mapped");

            Assert.Equal("test_mapped_mapped", value.LeftValueOrThrow());
        }

        /// <summary>
        /// Test that map right async can be chained.
        /// </summary>
        [Fact]
        public async void MapRightAsync_Chained_CallsTransformations()
        {
            var value = await Either.Right<string, string>("test")
                .MapRightAsync(async str => str + "_mapped")
                .MapRightAsync(async str => str + "_mapped");

            Assert.Equal("test_mapped_mapped", value.RightValueOrThrow());
        }

        /// <summary>
        /// Test that if the Either is a Left and Left is returned from map
        /// then a Left is returned.
        /// </summary>
        [Fact]
        public void FlatMapLeft_LeftReturnLeft_MapReturnsLeft()
        {
            var result = Either.Left<string, int>("test")
                .FlatMapLeft(str => (str + "_mapped").Left<string, int>());

            Assert.Equal("test_mapped", result.LeftValueOrThrow());
        }

        /// <summary>
        /// Test that if the Either is a Left and Right is returned from map
        /// then a Right is returned.
        /// </summary>
        [Fact]
        public void FlatMapLeft_LeftReturnRight_MapReturnsRight()
        {
            var result = Either.Left<string, int>("test")
                .FlatMapLeft(str => 100.Right<int, int>());

            Assert.Equal(100, result.RightValueOrThrow());
        }

        /// <summary>
        /// Test that if the Either is a Right and Right is returned from map
        /// then a Right is returned.
        /// </summary>
        [Fact]
        public void FlatMapRight_RightReturnRight_MapReturnsRight()
        {
            var result = Either.Right<int, string>("test")
                .FlatMapRight(str => (str + "_mapped").Right<int, string>());

            Assert.Equal("test_mapped", result.RightValueOrThrow());
        }

        /// <summary>
        /// Test that if the Either is a Right and Left is returned from map
        /// then a Left is returned.
        /// </summary>
        [Fact]
        public void FlatMapRight_RightReturnLeft_MapReturnsLeft()
        {
            var result = Either.Right<int, string>("test")
                .FlatMapRight(str => 100.Left<int, int>());

            Assert.Equal(100, result.LeftValueOrThrow());
        }

        /// <summary>
        /// Test that FlatMapLeftAsync can be chained.
        /// </summary>
        [Fact]
        public async void FlatMapLeftAsync_Chaining_TransformationsCalled()
        {
            var result = await Either.Left<string, int>("test")
                .FlatMapLeftAsync(async left => (left + "_mapped").Left<string, int>())
                .FlatMapLeftAsync(async left => (left + "_mapped").Left<string, int>());

            Assert.Equal("test_mapped_mapped", result.LeftValueOrThrow());
        }

        /// <summary>
        /// Test that FlatMapRightAsync can be chained.
        /// </summary>
        [Fact]
        public async void FlatMapRightAsync_Chaining_TransformationsCalled()
        {
            var result = await Either.Right<int, string>("test")
                .FlatMapRightAsync(async left => (left + "_mapped").Right<int, string>())
                .FlatMapRightAsync(async left => (left + "_mapped").Right<int, string>());

            Assert.Equal("test_mapped_mapped", result.RightValueOrThrow());
        }

        /// <summary>
        /// Test that the left value is returned when it is a Left.
        /// </summary>
        [Fact]
        public void ValueLeftOr_Left_ReturnsLeft()
        {
            var value = "test".Left<string, string>()
                .ValueLeftOr("fail");

            Assert.Equal("test", value);
        }

        /// <summary>
        /// Test that the or value is returned when it is a Right.
        /// </summary>
        [Fact]
        public void ValueLeftOr_Right_ReturnsOr()
        {
            var value = "fail".Right<string, string>()
                .ValueLeftOr("test");

            Assert.Equal("test", value);
        }

        /// <summary>
        /// Test that the left value is returned used when it is a Left.
        /// </summary>
        [Fact]
        public void ValueLeftOr_LeftFactory_ReturnsLeft()
        {
            var value = "test".Left<string, string>()
                .ValueLeftOr(() => throw new Exception("Factory should not be called."));

            Assert.Equal("test", value);
        }

        /// <summary>
        /// Test that the right value factory is used when it is a Right.
        /// </summary>
        [Fact]
        public void ValueLeftOr_RightFactory_ReturnsOr()
        {
            var value = "fail".Right<string, string>()
                .ValueLeftOr(() => "test");

            Assert.Equal("test", value);
        }

        /// <summary>
        /// Test that the right value is returned when it is a Right.
        /// </summary>
        [Fact]
        public void ValueRightOr_Right_ReturnsRight()
        {
            var value = "test".Right<string, string>()
                .ValueRightOr("fail");

            Assert.Equal("test", value);
        }

        /// <summary>
        /// Test that the or value is returned when it is a Left.
        /// </summary>
        [Fact]
        public void ValueRightOr_Left_ReturnsOr()
        {
            var value = "fail".Left<string, string>()
                .ValueRightOr("test");

            Assert.Equal("test", value);
        }

        /// <summary>
        /// Test that the right value is returned used when it is a Right.
        /// </summary>
        [Fact]
        public void ValueRightOr_RightFactory_ReturnsLeft()
        {
            var value = "test".Right<string, string>()
                .ValueRightOr(() => throw new Exception("Factory should not be called."));

            Assert.Equal("test", value);
        }

        /// <summary>
        /// Test that the left value factory is used when it is a Left.
        /// </summary>
        [Fact]
        public void ValueRightOr_RightFactory_ReturnsOr()
        {
            var value = "fail".Left<string, string>()
                .ValueRightOr(() => "test");

            Assert.Equal("test", value);
        }

        /// <summary>
        /// Test that a Left is converted into a Some.
        /// </summary>
        [Fact]
        public void ToLeftOptional_Left_ReturnsSome()
        {
            var result = Either.Left<string, string>("test")
                .ToLeftOptional();

            Assert.Equal("test", result.ValueOrThrow());
        }

        /// <summary>
        /// Test that a Right is converted into a None.
        /// </summary>
        [Fact]
        public void ToLeftOptional_Right_ReturnsNone()
        {
            var result = Either.Right<string, string>("test")
                .ToLeftOptional();

            Assert.False(result.HasValue);
        }

        /// <summary>
        /// Test that a Right is converted into a Some.
        /// </summary>
        [Fact]
        public void ToRightOptional_Right_ReturnsSome()
        {
            var result = Either.Right<string, string>("test")
                .ToRightOptional();

            Assert.Equal("test", result.ValueOrThrow());
        }

        /// <summary>
        /// Test that a Left is converted into a None.
        /// </summary>
        [Fact]
        public void ToRightOptional_Left_ReturnsNone()
        {
            var result = Either.Left<string, string>("test")
                .ToRightOptional();

            Assert.False(result.HasValue);
        }

        /// <summary>
        /// Test that a Left is converted into a Success
        /// </summary>
        [Fact]
        public void ToLeftResult_Left_ReturnsSuccess() 
        {
            var result = Either.Left<string, string>("test")
                .ToLeftResult();

            Assert.True(result.IsSuccess);
        }

        /// <summary>
        /// Test that a Right is converted into a Failure.
        /// </summary>
        [Fact]
        public void ToLeftResult_Right_ReturnsFailure() 
        {
            var result = Either.Right<string, string>("test")
                .ToLeftResult();

            Assert.True(result.IsFailure);
            Assert.Equal("test", result.FailureValueOrThrow());
        }

        /// <summary>
        /// Test that a Right is converted into a Success
        /// </summary>
        [Fact]
        public void ToRightResult_Right_ReturnsSuccess() 
        {
            var result = Either.Right<string, string>("test")
                .ToRightResult();

            Assert.True(result.IsSuccess);
        }

        /// <summary>
        /// Test that a Left is converted into a Failure.
        /// </summary>
        [Fact]
        public void ToRightResult_Left_ReturnsFailure() 
        {
            var result = Either.Left<string, string>("test")
                .ToRightResult();

            Assert.True(result.IsFailure);
            Assert.Equal("test", result.FailureValueOrThrow());
        }

        /// <summary>
        /// Test that the value is returned.
        /// </summary>
        [Fact]
        public void Unify_Left_ReturnsValue()
        {
            var value = Either.Left<string, string>("test").UnifyToValue();

            Assert.Equal("test", value);
        }

        /// <summary>
        /// Test that the value is returned.
        /// </summary>
        [Fact]
        public void Unify_Right_ReturnsValue()
        {
            var value = Either.Right<string, string>("test").UnifyToValue();

            Assert.Equal("test", value);
        }
    }
}