using System;
using System.Threading.Tasks;

namespace Hydrax.Functional.Unsafe
{
    public static class ResultExtensionsUnsafe
    {
        /// <summary>
        /// Get the value in a Failure or throw an exception if not a Failure.
        /// </summary>
        /// <param name="result">Result to get Failure value from.</param>
        /// <returns>Failure value.</returns>
        public static TFailure FailureValueOrThrow<TFailure>(this Result<TFailure> result) 
        {
          if(result.IsFailure) { return result.FailureValue; }

          throw new Exception("Result does not have a failure value.");
        }
    }
}
