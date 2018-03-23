using System;
using System.Threading.Tasks;

namespace Hydrax.Functional
{
    public static partial class FuncExtensions
    { 
        /// <summary>
        /// Partially apply a function from left to right leaving the last
        /// argument free.
        /// </summary>
        /// <param name="func">Function to partially apply</param>
        /// <param name="arg1">Argument 1.</param>
        /// <returns>Partially applied function.</returns>
        public static Func<TArg2, TReturn> PartialL<TArg1, TArg2, TReturn>(
          this Func<TArg1, TArg2, TReturn> func,
          TArg1 arg1)
        {
            return arg2 => func(arg1, arg2);
        }

        /// <summary>
        /// Partially apply a function from left to right leaving the last
        /// argument free.
        /// </summary>
        /// <param name="func">Function to partially apply</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <returns>Partially applied function.</returns>
        public static Func<TArg3, TReturn> PartialL<TArg1, TArg2, TArg3, TReturn>(
          this Func<TArg1, TArg2, TArg3, TReturn> func,
          TArg1 arg1, TArg2 arg2)
        {
            return arg3 => func(arg1, arg2, arg3);
        }

        /// <summary>
        /// Partially apply a function from left to right leaving the last
        /// argument free.
        /// </summary>
        /// <param name="func">Function to partially apply</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <returns>Partially applied function.</returns>
        public static Func<TArg4, TReturn> PartialL<TArg1, TArg2, TArg3, TArg4, TReturn>(
          this Func<TArg1, TArg2, TArg3, TArg4, TReturn> func,
          TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            return arg4 => func(arg1, arg2, arg3, arg4);
        }

        /// <summary>
        /// Partially apply a function from left to right leaving the last
        /// argument free.
        /// </summary>
        /// <param name="func">Function to partially apply</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <returns>Partially applied function.</returns>
        public static Func<TArg5, TReturn> PartialL<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(
          this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> func,
          TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            return arg5 => func(arg1, arg2, arg3, arg4, arg5);
        }

        /// <summary>
        /// Partially apply a function from left to right leaving the last
        /// argument free.
        /// </summary>
        /// <param name="func">Function to partially apply</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <param name="arg5">Argument 5.</param>
        /// <returns>Partially applied function.</returns>
        public static Func<TArg6, TReturn> PartialL<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(
          this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn> func,
          TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            return arg6 => func(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        /// <summary>
        /// Partially apply a function from left to right leaving the last
        /// argument free.
        /// </summary>
        /// <param name="func">Function to partially apply</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <param name="arg5">Argument 5.</param>
        /// <param name="arg6">Argument 6.</param>
        /// <returns>Partially applied function.</returns>
        public static Func<TArg7, TReturn> PartialL<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(
          this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn> func,
          TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            return arg7 => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        /// <summary>
        /// Partially apply a function from left to right leaving the last
        /// argument free.
        /// </summary>
        /// <param name="func">Function to partially apply</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <param name="arg5">Argument 5.</param>
        /// <param name="arg6">Argument 6.</param>
        /// <param name="arg7">Argument 7.</param>
        /// <returns>Partially applied function.</returns>
        public static Func<TArg8, TReturn> PartialL<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(
          this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn> func,
          TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
        {
            return arg8 => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        /// <summary>
        /// Partially apply a function from left to right leaving the last
        /// argument free.
        /// </summary>
        /// <param name="func">Function to partially apply</param>
        /// <param name="arg1">Argument 1.</param>
        /// <param name="arg2">Argument 2.</param>
        /// <param name="arg3">Argument 3.</param>
        /// <param name="arg4">Argument 4.</param>
        /// <param name="arg5">Argument 5.</param>
        /// <param name="arg6">Argument 6.</param>
        /// <param name="arg7">Argument 7.</param>
        /// <param name="arg8">Argument 8.</param>
        /// <returns>Partially applied function.</returns>
        public static Func<TArg9, TReturn> PartialL<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(
          this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn> func,
          TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8)
        {
            return arg9 => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }
    }
}