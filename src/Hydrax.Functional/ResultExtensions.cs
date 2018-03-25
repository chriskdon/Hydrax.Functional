using System;
using System.Threading.Tasks;

namespace Hydrax.Functional
{
    public static class ResultExtensions
    {
        /// <summary>
        /// Create a Result Failure from a value.
        /// </summary>
        /// <param name="value">Value to convert to Failure.</param>
        /// <returns>Failure Result.</returns>
        public static Result<TFailure> Failure<TFailure>(this TFailure value)
        {
            return Result.Failure(value);
        }

        /// <summary>
        /// Call actions depending on if a Result is a Success or Failure.
        /// </summary>
        /// <param name="result">Result to check cases for.</param>
        /// <param name="success">Action to call on Success.</param>
        /// <param name="failure">Action to call on Failure.</param>
        public static void Match(this Result result, Action success, Action failure)
        {
            if(result.IsSuccess) 
            {
                success();
            }
            else if(result.IsFailure)
            {
                failure();
            }
            else 
            {
                throw new Exception("Unknown result state.");
            }
        }

        /// <summary>
        /// Call functions depending on if a Result is a Success or Failure.
        /// </summary>
        /// <param name="result">Result to check cases for.</param>
        /// <param name="success">Function to call on Success.</param>
        /// <param name="failure">Function to call on Failure.</param>
        /// <returns>Result of success or failure function.</returns>
        public static T Match<T>(this Result result, Func<T> success, Func<T> failure)
        {
            if(result.IsSuccess) 
            {
                return success();
            }
            else if(result.IsFailure)
            {
                return failure();
            }
            else 
            {
                throw new Exception("Unknown result state.");
            }
        }

        /// <summary>
        /// Call actions depending on if a Result is a Success or Failure.
        /// </summary>
        /// <param name="result">Result to check cases for.</param>
        /// <param name="success">Action to call on Success.</param>
        /// <param name="failure">Action to call on Failure.</param>
        public static void Match<TFailure>(
            this Result<TFailure> result, 
            Action success, 
            Action<TFailure> failure)
        {
            if(result.IsSuccess) 
            {
                success();
            }
            else if(result.IsFailure)
            {
                failure(result.FailureValue);
            }
            else 
            {
                throw new Exception("Result is in unknown state."); 
            }
        }

        /// <summary>
        /// Call functions depending on if a Result is a Success or Failure.
        /// </summary>
        /// <param name="result">Result to check cases for.</param>
        /// <param name="success">Function to call on Success.</param>
        /// <param name="failure">Function to call on Failure.</param>
        /// <returns>Result of success or failure function.</returns>
        public static T Match<TFailure, T>(
            this Result<TFailure> result, 
            Func<T> success, Func<TFailure, T> failure)
        {
            if(result.IsSuccess) 
            {
                return success();
            }
            else if(result.IsFailure)
            {
                return failure(result.FailureValue);
            }
            else
            {
                throw new Exception("Unknown result state.");
            }
        }

        /// <summary>
        /// Call async actions depending on if a Result is a Success or Failure.
        /// </summary>
        /// <param name="result">Result to check cases for.</param>
        /// <param name="success">Async action to call on Success.</param>
        /// <param name="failure">Async action to call on Failure.</param>
        public static Task MatchAsync(
            this Result result, 
            Func<Task> success, 
            Func<Task> failure)
        {
            return result.Match(success, failure);
        }

        /// <summary>
        /// Call async functions depending on if a Result is a Success or Failure.
        /// </summary>
        /// <param name="result">Result to check cases for.</param>
        /// <param name="success">Async function to call on Success.</param>
        /// <param name="failure">Async function to call on Failure.</param>
        /// <returns>Result of success or failure function.</returns>
        public static Task<T> MatchAsync<T>(
            this Result result, 
            Func<Task<T>> success, 
            Func<Task<T>> failure)
        {
            return result.Match(success, failure);
        }

        /// <summary>
        /// Call async actions depending on if a Result is a Success or Failure.
        /// </summary>
        /// <param name="result">Result to check cases for.</param>
        /// <param name="success">Async action to call on Success.</param>
        /// <param name="failure">Async action to call on Failure.</param>
        public static Task MatchAsync<TFailure, T>(
            this Result<TFailure> result, 
            Func<Task> success, 
            Func<Task> failure)
        {
            return result.Match(success, failure);
        }

        /// <summary>
        /// Call async functions depending on if a Result is a Success or Failure.
        /// </summary>
        /// <param name="result">Result to check cases for.</param>
        /// <param name="success">Async function to call on Success.</param>
        /// <param name="failure">Async function to call on Failure.</param>
        /// <returns>Result of success or failure function.</returns>
        public static Task<T> MatchAsync<TFailure, T>(
            this Result<TFailure> result, 
            Func<Task<T>> success, 
            Func<TFailure, Task<T>> failure)
        {
            return result.Match(success, failure);
        }

        /// <summary>
        /// Map the Failure value of Result.
        /// </summary>
        /// <param name="result">Result to map.</param>
        /// <param name="failure">Map function.</param>
        /// <returns>Result with mapped Failure.</returns>
        public static Result<T> MapFailure<T>(
            this Result result, 
            Func<T> failure)
        {
            return result.Match(
                () => Result.Success<T>(), 
                () => failure().Failure());
        } 

        /// <summary>
        /// Map the Failure value of Result.
        /// </summary>
        /// <param name="result">Result to map.</param>
        /// <param name="failure">Map function.</param>
        /// <returns>Result with mapped Failure.</returns>
        public static Result<T> MapFailure<TFailure, T>(
            this Result<TFailure> result, 
            Func<TFailure, T> failure)
        {
            return result.Match(
                () => Result.Success<T>(), 
                f => failure(f).Failure());
        }

        /// <summary>
        /// Map the Failure value of Result using an async function.
        /// </summary>
        /// <param name="result">Result to map.</param>
        /// <param name="failure">Async map function.</param>
        /// <returns>Result with mapped Failure.</returns>
        public static async Task<Result<T>> MapFailureAsync<T>(
            this Result result, 
            Func<Task<T>> failure)
        {
            return await result.MatchAsync(
                () => Task.FromResult(Result.Success<T>()), 
                async () => (await failure()).Failure());
        } 

        /// <summary>
        /// Map the Failure value of Result using an async function.
        /// </summary>
        /// <param name="result">Result to map.</param>
        /// <param name="failure">Async map function.</param>
        /// <returns>Result with mapped Failure.</returns>
        public static async Task<Result<T>> MapFailureAsync<TFailure, T>(
            this Result<TFailure> result, 
            Func<TFailure, Task<T>> failure)
        {
            return await result.MatchAsync(
                () => Task.FromResult(Result.Success<T>()), 
                async f => (await failure(f)).Failure());
        }

        /// <summary>
        /// Map the Failure value of Result using an async function.
        /// </summary>
        /// <param name="result">Result to map.</param>
        /// <param name="failure">Async map function.</param>
        /// <returns>Result with mapped Failure.</returns>
        public static async Task<Result<T>> MapFailureAsync<T>(
            this Task<Result> result, 
            Func<Task<T>> failure)
        {
            return await (await result)
                .MapFailureAsync(failure);
        } 

        /// <summary>
        /// Map the Failure value of Result using an async function.
        /// </summary>
        /// <param name="result">Result to map.</param>
        /// <param name="failure">Async map function.</param>
        /// <returns>Result with mapped Failure.</returns>
        public static async Task<Result<T>> MapFailureAsync<TFailure, T>(
            this Task<Result<TFailure>> result, 
            Func<TFailure, Task<T>> failure)
        {
            return await (await result)
                .MapFailureAsync(failure);
        }

        /// <summary>
        /// Flat map a Result Failure.
        /// </summary>
        /// <param name="result">Result to flat map on.</param>
        /// <param name="failure">Mapping function.</param>
        /// <returns>Flat mapped result.</returns>
        public static Result<T> FlatMapFailure<T>(
            this Result result,
            Func<Result<T>> failure)
        {
            return result.Match(() => Result.Success<T>(), failure);
        }

        /// <summary>
        /// Flat map a Result Failure.
        /// </summary>
        /// <param name="result">Result to flat map on.</param>
        /// <param name="failure">Mapping function.</param>
        /// <returns>Flat mapped result.</returns>
        public static Result<T> FlatMapFailure<TFailure, T>(
            this Result<TFailure> result,
            Func<TFailure, Result<T>> failure)
        {
            return result.Match(() => Result.Success<T>(), failure);
        }

        /// <summary>
        /// Flat map a Result Failure.
        /// </summary>
        /// <param name="result">Result to flat map on.</param>
        /// <param name="failure">Mapping function.</param>
        /// <returns>Flat mapped result.</returns>
        public static Task<Result<T>> FlatMapFailureAsync<T>(
            this Result result,
            Func<Task<Result<T>>> failure)
        {
            return result.MatchAsync(
                () => Task.FromResult(Result.Success<T>()), 
                failure);
        }

        /// <summary>
        /// Flat map a Result Failure.
        /// </summary>
        /// <param name="result">Result to flat map on.</param>
        /// <param name="failure">Mapping function.</param>
        /// <returns>Flat mapped result.</returns>
        public static Task<Result<T>> FlatMapFailureAsync<TFailure, T>(
            this Result<TFailure> result,
            Func<TFailure, Task<Result<T>>> failure)
        {
            return result.MatchAsync(
                () => Task.FromResult(Result.Success<T>()), 
                failure);
        }

        /// <summary>
        /// Flat map a Result Failure.
        /// </summary>
        /// <param name="result">Result to flat map on.</param>
        /// <param name="failure">Mapping function.</param>
        /// <returns>Flat mapped result.</returns>
        public static async Task<Result<T>> FlatMapFailureAsync<T>(
            this Task<Result> result,
            Func<Task<Result<T>>> failure)
        {
            return await (await result)
                .FlatMapFailureAsync(failure);
        }

        /// <summary>
        /// Flat map a Result Failure.
        /// </summary>
        /// <param name="result">Result to flat map on.</param>
        /// <param name="failure">Mapping function.</param>
        /// <returns>Flat mapped result.</returns>
        public static async Task<Result<T>> FlatMapFailureAsync<TFailure, T>(
            this Task<Result<TFailure>> result,
            Func<TFailure, Task<Result<T>>> failure)
        {
            return await (await result)
                .FlatMapFailureAsync(failure);
        }
    }
}
