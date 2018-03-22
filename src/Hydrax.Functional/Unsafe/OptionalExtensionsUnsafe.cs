using System;
using System.Threading.Tasks;

namespace Hydrax.Functional.Unsafe
{
    public static class OptionalExtensionsUnsafe
    {
        /// <summary>
        /// Get the value from an Optional or throw an exception if not 
        /// present.
        /// </summary>
        /// <param name="optional">Optional to try to get the value for.</param>
        /// <returns>Value of the Optional.</returns>
        public static TValue ValueOrThrow<TValue>(this Optional<TValue> optional) 
        {
            if(optional.HasValue) { return optional.Value; }

            throw new Exception("Optional does not have a value.");
        }

        /// <summary>
        /// Get the value from an Optional or throw an exception if not 
        /// present.
        /// </summary>
        /// <param name="optional">Optional to try to get the value for.</param>
        /// <param name="ex">Exception to throw.</param>
        /// <returns>Value of the optional.</returns>
        public static TValue ValueOrThrow<TValue, TException>(this Optional<TValue> optional, TException ex) where TException : Exception
        {
            if(optional.HasValue) { return optional.Value; }

            throw ex;
        }

        /// <summary>
        /// Get the value from an Optional or throw an exception if not 
        /// present.
        /// </summary>
        /// <param name="optional">Optional to try to get the value for.</param>
        /// <param name="ex">Lazy function to generate exception to throw.</param>
        /// <returns>Value of the optional.</returns>
        public static TValue ValueOrThrow<TValue, TException>(this Optional<TValue> optional, Func<TException> ex) where TException : Exception
        {
            if(optional.HasValue) { return optional.Value; }

            throw ex();
        }
    }
}
