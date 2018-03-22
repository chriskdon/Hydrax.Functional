using System;
using System.Threading.Tasks;

namespace Hydrax.Functional
{
    public static class OptionalExtensions
    {
        /// <summary>
        /// Wrap some value to a Some Optional.
        /// </summary>
        /// <param name="value">Value to wrap.</param>
        /// <returns>Wrapped value as an Optional.</returns>
        public static Optional<TValue> Some<TValue>(this TValue value) 
        {
            return Optional.Some(value);
        }

        /// <summary>
        /// Create a Some Optional from the result of a Task.
        /// </summary>
        /// <param name="task">Task to get value from.</param>
        /// <returns>Optional with value from task as a Task.</returns>
        public static async Task<Optional<TValue>> SomeAsync<TValue>(this Task<TValue> task) 
        {
            return Optional.Some(await task);
        }

        /// <summary>
        /// Create a Some Optional if the value is not null.
        /// </summary>
        /// <param name="value">Value to convert to Some.</param>
        /// <returns>Optional of value.</returns>
        public static Optional<TValue> SomeNotNull<TValue>(this TValue value) where TValue : class
        {
            if(value == null)
            {
                return Optional.None<TValue>();
            }

            return value.Some();
        }

        /// <summary>
        /// Call an action depending on if the optional is a Some or None. If 
        /// it is Some then the value of the optional will be passed to the
        /// action.
        /// </summary>
        /// <param name="optional">Optional to match on.</param>
        /// <param name="some">Action to call if Some.</param>
        /// <param name="none">Action to call if None.</param>
        public static void Match<TValue>(
            this Optional<TValue> optional, 
            Action<TValue> some, 
            Action none)
        {
            if(optional.HasValue) 
            {
                some(optional.Value);
            }
            else
            {
                none();
            }
        }

        /// <summary>
        /// Call a function depending on if the optional is a Some or None. If 
        /// it is Some then the value of the optional will be passed to the
        /// function.
        /// </summary>
        /// <param name="optional">Optional to match on.</param>
        /// <param name="some">Function to call if Some.</param>
        /// <param name="none">Function to call if None.</param>
        /// <returns>Result from either the some or none functions.</returns>
        public static T Match<TValue, T>(
            this Optional<TValue> optional, 
            Func<TValue, T> some, 
            Func<T> none)
        {
            if(optional.HasValue) 
            {
                return some(optional.Value);
            }
            else 
            {
                return none();
            }
        }

        /// <summary>
        /// Call an async action depending on if the optional is a Some or None. 
        /// If it is Some then the value of the optional will be passed to the
        /// function.
        /// </summary>
        /// <param name="optional">Optional to match on.</param>
        /// <param name="some">Aysnc action to call if Some.</param>
        /// <param name="none">Async action to call if None.</param>
        public static async Task MatchAsync<TValue>(
            this Optional<TValue> optional, 
            Func<TValue, Task> some, 
            Func<Task> none)
        {
            await optional.Match(some, none);
        }

        /// <summary>
        /// Call an async function depending on if the optional is a 
        /// Some or None. If it is Some then the value of the optional 
        /// will be passed to the function.
        /// </summary>
        /// <param name="optional">Optional to match on.</param>
        /// <param name="some">Async function to call if Some.</param>
        /// <param name="none">Async function to call if None.</param>
        /// <returns>Result from either the some or none functions.</returns>
        public static Task<T> MatchAsync<TValue, T>(
            this Optional<TValue> optional, 
            Func<TValue, Task<T>> some, 
            Func<Task<T>> none)
        {
            return optional.Match(some, none);
        }

        /// <summary>
        /// Call an async function depending on if the optional is a 
        /// Some or None. If it is Some then the value of the optional 
        /// will be passed to the function.
        /// </summary>
        /// <param name="optional">Optional to match on.</param>
        /// <param name="some">Async function to call if Some.</param>
        /// <param name="none">Async function to call if None.</param>
        /// <returns>Result from either the some or none functions.</returns>
        public static async Task<T> MatchAsync<TValue, T>(
            this Task<Optional<TValue>> optional, 
            Func<TValue, Task<T>> some, 
            Func<Task<T>> none)
        {
            return await (await optional).Match(some, none);
        }

        /// <summary>
        /// Map an optional from one value to another if the Optional is a
        /// Some.
        /// </summary>
        /// <param name="optional">Optional to map.</param>
        /// <param name="some">Map function to use if Some.</param>
        /// <returns>Optional with new mapped value.</returns>
        public static Optional<T> Map<TValue, T>(
            this Optional<TValue> optional, 
            Func<TValue, T> some)
        {
            if(optional.HasValue)
            {
                return Optional.Some<T>(some(optional.Value));
            }

            return Optional.None<T>();
        }

        /// <summary>
        /// Map an optional from one value to another if the Optional is a
        /// Some using an async function.
        /// </summary>
        /// <param name="optional">Optional to map.</param>
        /// <param name="some">Async map function to use if Some.</param>
        /// <returns>Optional with new mapped value.</returns>
        public static async Task<Optional<T>> MapAsync<TValue, T>(
            this Optional<TValue> optional, 
            Func<TValue, Task<T>> some)
        {
            if(optional.HasValue)
            {
                return Optional.Some<T>(await some(optional.Value));
            }

            return Optional.None<T>();
        }

        /// <summary>
        /// Map an task optional from one value to another if the Optional is a
        /// Some using an async function.
        /// 
        /// This allows for chaining of async maps.
        /// </summary>
        /// <param name="optional">Optional to map.</param>
        /// <param name="some">Async map function to use if Some.</param>
        /// <returns>Optional with new mapped value.</returns>
        public static async Task<Optional<T>> MapAsync<TValue, T>(
            this Task<Optional<TValue>> optionalTask, 
            Func<TValue, Task<T>> some)
        {
            var optional = await optionalTask;

            return await optional.MapAsync(some);
        }

        /// <summary>
        /// Flattens an optional that is returned from a mapping function
        /// into a Optional of the map result.
        /// </summary>
        /// <param name="optional">Optional to flat map.</param>
        /// <param name="some">Mapping function to use if Some.</param>
        /// <returns>Flat mapped optional.</returns>
        public static Optional<T> FlatMap<TValue, T>(
            this Optional<TValue> optional,
            Func<TValue, Optional<T>> some)
        {
            return optional
                .Match(
                    some: value => some(value), 
                    none: () => Optional.None<T>()
                );
        }

        /// <summary>
        /// Flattens an optional that is returned from an async mapping 
        /// function into a Optional of the map result.
        /// </summary>
        /// <param name="optional">Optional to flat map.</param>
        /// <param name="some">Mapping function to use if Some.</param>
        /// <returns>Flat mapped optional.</returns>
        public static async Task<Optional<T>> FlatMapAsync<TValue, T>(
            this Optional<TValue> optional,
            Func<TValue, Task<Optional<T>>> some)
        {
            var mapped = await optional.MapAsync(some);

            return mapped.Match(
                some: value => value, 
                none: () => Optional.None<T>()
            );
        }

        /// <summary>
        /// Flattens an optional that is returned from an async mapping 
        /// function into a Optional of the map result.
        /// 
        /// Allows for chaining.
        /// </summary>
        /// <param name="optional">Optional to flat map.</param>
        /// <param name="some">Mapping function to use if Some.</param>
        /// <returns>Flat mapped optional.</returns>
        public static async Task<Optional<T>> FlatMapAsync<TValue, T>(
            this Task<Optional<TValue>> optionalTask,
            Func<TValue, Task<Optional<T>>> some)
        {
            return await (await optionalTask)
                .FlatMapAsync(some);
        }

        /// <summary>
        /// Get the value stored in the optional if it is a Some or return
        /// the value passed in as the default.
        /// </summary>
        /// <param name="optional">Optional to get value from.</param>
        /// <param name="orValue">Default value to use if optional is None.</param>
        /// <returns>Value or default.</returns>
        public static TValue ValueOr<TValue>(
            this Optional<TValue> optional, 
            TValue orValue)
        {
            return optional.Match(o => o, () => orValue);
        }

        /// <summary>
        /// Get the value stored in the optional if it is a Some or return
        /// the value resolved by the default value factory.
        /// </summary>
        /// <param name="optional">Optional to get value from.</param>
        /// <param name="orValue">Default value factory to use if optional is None.</param>
        /// <returns>Value or default.</returns>
        public static TValue ValueOr<TValue>(
            this Optional<TValue> optional, 
            Func<TValue> orValue)
        {
            return optional.Match(o => o, orValue);
        }

        /// <summary>
        /// Create a none from a Some when a predicate is true.
        /// </summary>
        /// <param name="optional">Optional to test.</param>
        /// <param name="predicate">Predicate to check if true.</param>
        /// <returns>None optional if predicate is true; original optional otherwise.</returns>
        public static Optional<TValue> NoneWhen<TValue>(
            this Optional<TValue> optional,
            Func<TValue, bool> predicate)
        {
            if(optional.Match(predicate, () => true)) 
            {
                return Optional.None<TValue>();
            }

            return optional;
        }

        /// <summary>
        /// When the predicate returns true and the optional is a Some, the
        /// Some will be returned. Otherwise None is returned.
        /// </summary>
        /// <param name="optional">Optional to test.</param>
        /// <param name="predicate">Predicate to check if true.</param>
        /// <returns>Optional result.</returns>
        public static Optional<TValue> SomeWhen<TValue>(
            this Optional<TValue> optional,
            Func<TValue, bool> predicate)
        {
            if(optional.Match(predicate, () => false)) 
            {
                return optional;
            }

            return Optional.None<TValue>();
        }

        /// <summary>
        /// Convert an Optional to a Result. If the optional has a value it
        /// will be a Success Result otherwise it will be a Failure Result.
        /// </summary>
        /// <param name="optional">Optional to convert.</param>
        /// <returns>Converted Result from Optional.</returns>
        public static Result ToResult<TValue>(this Optional<TValue> optional)
        {
            return optional.Match(
                _ => Result.Success(), 
                () => Result.Failure()
            );
        }
    }
}
