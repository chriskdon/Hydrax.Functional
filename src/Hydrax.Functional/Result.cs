using System;

namespace Hydrax.Functional
{
    public class Result
    {
        /// <summary>
        /// Is the result a Success.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Is the result a Failure.
        /// </summary>
        public bool IsFailure => !IsSuccess;

        internal Result(bool isSuccess) 
        {
            this.IsSuccess = isSuccess;
        }

        public override string ToString()
        {
            return this.Match(() => "Success", () => "Failure");
        }

        /// <summary>
        /// Create a success result.
        /// </summary>
        /// <returns>Success result.</returns>
        public static Result Success() 
        {
            return new Result(true);
        }

        /// <summary>
        /// Create a failure result.
        /// </summary>
        /// <returns>Failure result.</returns>
        public static Result Failure() {
            return new Result(false);
        }

        /// <summary>
        /// Create a success result.
        /// </summary>
        /// <returns>Success result.</returns>
        public static Result<TFailure> Success<TFailure>() 
        {
            return new Result<TFailure>(true, default(TFailure));
        }

        /// <summary>
        /// Create a failure result.
        /// </summary>
        /// <returns>Failure result.</returns>
        public static Result<TFailure> Failure<TFailure>(TFailure failure) {
            return new Result<TFailure>(false, failure);
        }
    }

    /// <summary>
    /// Result that stores a failure value.
    /// </summary>
    public class Result<TFailure> : Result
    {
        internal TFailure FailureValue { get; }

        internal Result(bool isSuccess, TFailure failure) : base(isSuccess)
        {
            this.FailureValue = failure;
        }

        public override string ToString()
        {
            return this.Match(() => $"Success", error => $"Failure({error})");
        }
    }
}
