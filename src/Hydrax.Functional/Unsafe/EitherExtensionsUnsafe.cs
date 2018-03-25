using System;
using System.Threading.Tasks;

namespace Hydrax.Functional.Unsafe
{
    public static class EitherExtensionsUnsafe
    {
        /// <summary>
        /// Get the Left value from an Either or throw an exception.
        /// </summary>
        /// <param name="either">Either to get the value from.</param>
        /// <returns>Left value.</returns>
        public static TLeft LeftValueOrThrow<TLeft, TRight>(this Either<TLeft, TRight> either) 
        {
          if(either.IsLeft) { return either.LeftValue; }

          throw new Exception("Either does not have a left value.");
        }

        /// <summary>
        /// Get the Right value from an Either or throw an exception.
        /// </summary>
        /// <param name="either">Either to get the value from.</param>
        /// <returns>Right value.</returns>
        public static TRight RightValueOrThrow<TLeft, TRight>(this Either<TLeft, TRight> either) 
        {
          if(either.IsRight) { return either.RightValue; }

          throw new Exception("Either does not have a right value.");
        }
    }
}
