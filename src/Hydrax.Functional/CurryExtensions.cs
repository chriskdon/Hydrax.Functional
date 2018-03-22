using System;
using System.Threading.Tasks;

namespace Hydrax.Functional
{
    public static class CurryExtensions
    {
        /// <summary>
        /// Curry function.
        /// </summary>
        /// <param name="func">Function to curry.</param>
        /// <returns>Curried form of the function.</returns>
        public static Func<TArg1, Func<TArg2, TReturn>> Curry<TArg1, TArg2, TReturn>(
          this Func<TArg1, TArg2, TReturn> func)
        {
            return arg1 => arg2 => func(arg1, arg2);
        }

        /// <summary>
        /// Curry function.
        /// </summary>
        /// <param name="func">Function to curry.</param>
        /// <returns>Curried form of the function.</returns>
        public static Func<TArg1, Func<TArg2, Func<TArg3, TReturn>>> Curry<TArg1, TArg2, TArg3, TReturn>(
          this Func<TArg1, TArg2, TArg3, TReturn> func)
        {
            return arg1 => arg2 => arg3 => func(arg1, arg2, arg3);
        }

        /// <summary>
        /// Curry function.
        /// </summary>
        /// <param name="func">Function to curry.</param>
        /// <returns>Curried form of the function.</returns>
        public static Func<TArg1, Func<TArg2, Func<TArg3, Func<TArg4, TReturn>>>> Curry<TArg1, TArg2, TArg3, TArg4, TReturn>(
          this Func<TArg1, TArg2, TArg3, TArg4, TReturn> func)
        {
            return arg1 => arg2 => arg3 => arg4 => func(arg1, arg2, arg3, arg4);
        }
    }
}