using System;
using System.Threading.Tasks;

namespace Hydrax.Functional
{
    public static class EitherExtensions
    {
        /// <summary>
        /// Create a Left Either from a value.
        /// </summary>
        /// <param name="value">Value for Left.</param>
        /// <returns>Left with value.</returns>
        public static Either<TLeft, TRight> Left<TLeft, TRight>(this TLeft value)
        {
            return Either.Left<TLeft, TRight>(value);
        }

        /// <summary>
        /// Create a Right Either from a value.
        /// </summary>
        /// <param name="value">Value for Right</param>
        /// <returns>Right with value.</returns>
        public static Either<TLeft, TRight> Right<TLeft, TRight>(this TRight value)
        {
            return Either.Right<TLeft, TRight>(value);
        }

        /// <summary>
        /// Call an action depending on the type of Either. If it is a Left 
        /// then the left action will be called, if it is a Right the right
        /// action will be called.
        /// </summary>
        /// <param name="either">Either to call actions for.</param>
        /// <param name="left">Action to call in case of Left.</param>
        /// <param name="right">Action to call in case of Right.</param>
        public static void Match<TLeft, TRight>(
          this Either<TLeft, TRight> either, 
          Action<TLeft> left, 
          Action<TRight> right)
        {
            if(either.IsLeft) 
            {
                left(either.LeftValue);
                return;
            }
            
            if(either.IsRight)
            {
                right(either.RightValue);
                return;
            }

            throw new Exception("Either is in unknown state.");
        }

        /// <summary>
        /// Call a function depending on the type of Either. If it is a Left 
        /// then the left function will be called, if it is a Right the right
        /// function will be called.
        /// </summary>
        /// <param name="either">Either to call functions for.</param>
        /// <param name="left">Function to call in case of Left.</param>
        /// <param name="right">Function to call in case of Right.</param>
        public static T Match<TLeft, TRight, T>(
            this Either<TLeft, TRight> either, 
            Func<TLeft, T> left, 
            Func<TRight, T> right)
        {
            if(either.IsLeft) 
            {
                return left(either.LeftValue);
            }
            
            if(either.IsRight)
            {
                return right(either.RightValue);
            }

            throw new Exception("Either is in unknown state.");
        }

        /// <summary>
        /// Call a function depending on the type of Either. If it is a Left 
        /// then the left async function will be called, if it is a Right 
        /// the right async function will be called.
        /// </summary>
        /// <param name="either">Either to call functions for.</param>
        /// <param name="left">Async function to call in case of Left.</param>
        /// <param name="right">Async function to call in case of Right.</param>
        public static Task<T> MatchAsync<TLeft, TRight, T>(
            this Either<TLeft, TRight> either, 
            Func<TLeft, Task<T>> left, 
            Func<TRight, Task<T>> right)
        {
            return either.Match(left, right);
        }

        /// <summary>
        /// Call a function depending on the type of Either. If it is a Left 
        /// then the left async function will be called, if it is a Right 
        /// the right async function will be called.
        /// </summary>
        /// <param name="either">Either to call functions for.</param>
        /// <param name="left">Async function to call in case of Left.</param>
        /// <param name="right">Async function to call in case of Right.</param>
        public static async Task<T> MatchAsync<TLeft, TRight, T>(
            this Task<Either<TLeft, TRight>> either, 
            Func<TLeft, Task<T>> left, 
            Func<TRight, Task<T>> right)
        {
            return await (await either).Match(left, right);
        }

        /// <summary>
        /// Map an either if it is a Left.
        /// </summary>
        /// <param name="either">Either to map.</param>
        /// <param name="left">Map function for Left.</param>
        /// <returns>Either with the Left mapped or Right.</returns>
        public static Either<T, TRight> MapLeft<TLeft, TRight, T>(
            this Either<TLeft, TRight> either, 
            Func<TLeft, T> left)
        {
            return either.Match(
                lv => left(lv).Left<T, TRight>(), 
                rv => rv.Right<T, TRight>()
            );
        }

        /// <summary>
        /// Map an either if it is a Right.
        /// </summary>
        /// <param name="either">Either to map.</param>
        /// <param name="right">Map function for Right.</param>
        /// <returns>Either with the Right mapped or Left.</returns>
        public static Either<TLeft, T> MapRight<TLeft, TRight, T>(
            this Either<TLeft, TRight> either, 
            Func<TRight, T> right)
        {
            return either.Match(
                lv => lv.Left<TLeft, T>(), 
                rv => right(rv).Right<TLeft, T>()
            );
        }

        /// <summary>
        /// Async map an either if it is a Left.
        /// </summary>
        /// <param name="either">Either to map.</param>
        /// <param name="left">Async map function for Left.</param>
        /// <returns>Either with the Left mapped or Right.</returns>
        public static async Task<Either<T, TRight>> MapLeftAsync<TLeft, TRight, T>(
            this Either<TLeft, TRight> either, 
            Func<TLeft, Task<T>> left)
        {
            return await either.MatchAsync(
                async lv => (await left(lv)).Left<T, TRight>(), 
                rv => Task.FromResult(rv.Right<T, TRight>())
            );
        }

        /// <summary>
        /// Async map an either if it is a Right.
        /// </summary>
        /// <param name="either">Either to map.</param>
        /// <param name="right">Async map function for Right.</param>
        /// <returns>Either with the Right mapped or left.</returns>
        public static async Task<Either<TLeft, T>> MapRightAsync<TLeft, TRight, T>(
            this Either<TLeft, TRight> either, 
            Func<TRight, Task<T>> right)
        {
            return await either.MatchAsync(
                lv => Task.FromResult(lv.Left<TLeft, T>()),
                async rv => (await right(rv)).Right<TLeft, T>()
            );
        }

        /// <summary>
        /// Async map an either if it is a Left.
        /// 
        /// Used for chaining.
        /// </summary>
        /// <param name="either">Either to map.</param>
        /// <param name="left">Async map function for Left.</param>
        /// <returns>Either with the Left mapped or Right.</returns>
        public static async Task<Either<T, TRight>> MapLeftAsync<TLeft, TRight, T>(
            this Task<Either<TLeft, TRight>> either, 
            Func<TLeft, Task<T>> left)
        {
            return await either.MatchAsync(
                async lv => (await left(lv)).Left<T, TRight>(), 
                rv => Task.FromResult(rv.Right<T, TRight>())
            );
        }

        /// <summary>
        /// Async map an either if it is a Right.
        /// 
        /// Used for chaining.
        /// </summary>
        /// <param name="either">Either to map.</param>
        /// <param name="right">Async map function for Right.</param>
        /// <returns>Either with the Right mapped or left.</returns>
        public static async Task<Either<TLeft, T>> MapRightAsync<TLeft, TRight, T>(
            this Task<Either<TLeft, TRight>> either, 
            Func<TRight, Task<T>> right)
        {
            return await either.MatchAsync(
                lv => Task.FromResult(lv.Left<TLeft, T>()),
                async rv => (await right(rv)).Right<TLeft, T>()
            );
        }

        /// <summary>
        /// Flat map a Left either. 
        /// </summary>
        /// <param name="either">Either to be mapped.</param>
        /// <param name="left">Left function to do the mapping.</param>
        /// <returns>Flat mapped either.</returns>
        public static Either<T, TRight> FlatMapLeft<TLeft, TRight, T>(
            this Either<TLeft, TRight> either, 
            Func<TLeft, Either<T, TRight>> left)
        {
            return either.Match(
                lv => left(lv),
                rv => Either.Right<T, TRight>(rv)
            );
        }

        /// <summary>
        /// Flat map a Right either. 
        /// </summary>
        /// <param name="either">Either to be mapped.</param>
        /// <param name="right">Right function to do the mapping.</param>
        /// <returns>Flat mapped either.</returns>
        public static Either<TLeft, T> FlatMapRight<TLeft, TRight, T>(
            this Either<TLeft, TRight> either, 
            Func<TRight, Either<TLeft, T>> right)
        {
            return either.Match(
                lv => Either.Left<TLeft, T>(lv),
                rv => right(rv)
            );
        }

        /// <summary>
        /// Flat map a Left either with async mapper.
        /// </summary>
        /// <param name="either">Either to be mapped.</param>
        /// <param name="left">Async left function to do the mapping.</param>
        /// <returns>Flat mapped either.</returns>
        public static Task<Either<T, TRight>> FlatMapLeftAsync<TLeft, TRight, T>(
            this Either<TLeft, TRight> either, 
            Func<TLeft, Task<Either<T, TRight>>> left)
        {
            return either.Match(
                lv => left(lv),
                rv => Task.FromResult(Either.Right<T, TRight>(rv))
            );
        }

        /// <summary>
        /// Flat map a Right either with an async mapper.
        /// </summary>
        /// <param name="either">Either to be mapped.</param>
        /// <param name="right">Async right function to do the mapping.</param>
        /// <returns>Flat mapped either.</returns>
        public static Task<Either<TLeft, T>> FlatMapRightAsync<TLeft, TRight, T>(
            this Either<TLeft, TRight> either, 
            Func<TRight, Task<Either<TLeft, T>>> right)
        {
            return either.Match(
                lv => Task.FromResult(Either.Left<TLeft, T>(lv)),
                rv => right(rv)
            );
        }

        /// <summary>
        /// Flat map a Left either with async mapper.
        /// 
        /// Used for chaining.
        /// </summary>
        /// <param name="either">Either to be mapped.</param>
        /// <param name="left">Async left function to do the mapping.</param>
        /// <returns>Flat mapped either.</returns>
        public static async Task<Either<T, TRight>> FlatMapLeftAsync<TLeft, TRight, T>(
            this Task<Either<TLeft, TRight>> either, 
            Func<TLeft, Task<Either<T, TRight>>> left)
        {
            return await (await either)
                .FlatMapLeftAsync(left);
        }

        /// <summary>
        /// Flat map a Right either with an async mapper.
        /// 
        /// Used for chaining.
        /// </summary>
        /// <param name="either">Either to be mapped.</param>
        /// <param name="right">Async right function to do the mapping.</param>
        /// <returns>Flat mapped either.</returns>
        public static async Task<Either<TLeft, T>> FlatMapRightAsync<TLeft, TRight, T>(
            this Task<Either<TLeft, TRight>> either, 
            Func<TRight, Task<Either<TLeft, T>>> right)
        {
            return await (await either)
                .FlatMapRightAsync(right);
        }

        /// <summary>
        /// Get the Left value or use a default value.
        /// </summary>
        /// <param name="either">Either to get Left from.</param>
        /// <param name="orValue">Default value if it is not a Left.</param>
        /// <returns>Left value or default.</returns>
        public static TLeft ValueLeftOr<TLeft, TRight>(
            this Either<TLeft, TRight> either, 
            TLeft orValue)
        {
            return either.Match(left => left, _ => orValue);
        }

        /// <summary>
        /// Get the Left value or use a default value factory.
        /// </summary>
        /// <param name="either">Either to get Left from.</param>
        /// <param name="orValue">Default value factory if it is not a Left.</param>
        /// <returns>Left value or default.</returns>
        public static TLeft ValueLeftOr<TLeft, TRight>(
            this Either<TLeft, TRight> either, 
            Func<TLeft> orValue)
        {
            return either.Match(left => left, _ => orValue());
        }

        /// <summary>
        /// Get the Right value or use a default value.
        /// </summary>
        /// <param name="either">Either to get Right from.</param>
        /// <param name="orValue">Default value if it is not a Right.</param>
        /// <returns>Right value or default.</returns>
        public static TRight ValueRightOr<TLeft, TRight>(
            this Either<TLeft, TRight> either, 
            TRight orValue)
        {
            return either.Match(_ => orValue, right => right);
        }

        /// <summary>
        /// Get the Right value or use a default value factory.
        /// </summary>
        /// <param name="either">Either to get Right from.</param>
        /// <param name="orValue">Default value factory if it is not a Right.</param>
        /// <returns>Right value or default.</returns>
        public static TRight ValueRightOr<TLeft, TRight>(
            this Either<TLeft, TRight> either, 
            Func<TRight> orValue)
        {
            return either.Match(_ => orValue(), right => right);
        }

        /// <summary>
        /// Convert an Either to an Optional. If it is a Left then it will 
        /// be a Some with the value of Left or None.
        /// </summary>
        /// <param name="either">Either to convert.</param>
        /// <returns>Optional from Either.</returns>
        public static Optional<TLeft> ToLeftOptional<TLeft, TRight>(this Either<TLeft, TRight> either)
        {
            return either.Match(
              left => Optional.Some(left), 
              right => Optional.None<TLeft>());
        }

         /// <summary>
        /// Convert an Either to an Optional. If it is a Right then it will 
        /// be a Some with the value of Right or None.
        /// </summary>
        /// <param name="either">Either to convert.</param>
        /// <returns>Optional from Either.</returns>
        public static Optional<TRight> ToRightOptional<TLeft, TRight>(this Either<TLeft, TRight> either)
        {
            return either.Match(
              left => Optional.None<TRight>(), 
              right => Optional.Some<TRight>(right));
        }

         /// <summary>
        /// Convert an Either to an Result. If it is a Left then it will 
        /// be a Success, otherwise a Failure with the error value of Right.
        /// </summary>
        /// <param name="either">Either to convert.</param>
        /// <returns>Optional from Either.</returns>
        public static Result<TRight> ToLeftResult<TLeft, TRight>(this Either<TLeft, TRight> either)
        {
            return either.Match(
              left => Result.Success<TRight>(), 
              right => Result.Failure<TRight>(right));
        }

        /// <summary>
        /// Convert an Either to an Result. If it is a Right then it will 
        /// be a Success, otherwise a Failure with the error value of Left.
        /// </summary>
        /// <param name="either">Either to convert.</param>
        /// <returns>Optional from Either.</returns>
        public static Result<TLeft> ToRightResult<TLeft, TRight>(this Either<TLeft, TRight> either)
        {
            return either.Match(
              left => Result.Failure<TLeft>(left), 
              right => Result.Success<TLeft>());
        }

        /// <summary>
        /// Return the value from left or right of the Either. The either
        /// Left and Right must have the same types.
        /// </summary>
        /// <param name="either">Either to return.</param>
        /// <returns>Value of Left or Right</returns>
        public static TValue UnifyToValue<TValue>(this Either<TValue, TValue> either)
        {
            return either.Match(l => l, r => r);
        }
    }
}
