using System;
using System.Threading.Tasks;

namespace Hydrax.Functional
{
    public static partial class FuncExtensions
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

        /// <summary>
        /// Curry function.
        /// </summary>
        /// <param name="func">Function to curry.</param>
        /// <returns>Curried form of the function.</returns>
        public static Func<TArg1, Func<TArg2, Func<TArg3, Func<TArg4, Func<TArg5, TReturn>>>>> Curry<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(
          this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> func)
        {
            return arg1 => arg2 => arg3 => arg4 => arg5 => func(arg1, arg2, arg3, arg4, arg5);
        }

        /// <summary>
        /// Curry function.
        /// </summary>
        /// <param name="func">Function to curry.</param>
        /// <returns>Curried form of the function.</returns>
        public static Func<TArg1, Func<TArg2, Func<TArg3, Func<TArg4, Func<TArg5, Func<TArg6, TReturn>>>>>> Curry<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(
          this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn> func)
        {
            return arg1 => arg2 => arg3 => 
                   arg4 => arg5 => arg6 => func(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        /// <summary>
        /// Curry function.
        /// </summary>
        /// <param name="func">Function to curry.</param>
        /// <returns>Curried form of the function.</returns>
        public static Func<TArg1, Func<TArg2, Func<TArg3, Func<TArg4, Func<TArg5, Func<TArg6, Func<TArg7, TReturn>>>>>>> Curry<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(
          this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn> func)
        {
            return arg1 => arg2 => arg3 => 
                   arg4 => arg5 => arg6 => 
                   arg7 => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        /// <summary>
        /// Curry function.
        /// </summary>
        /// <param name="func">Function to curry.</param>
        /// <returns>Curried form of the function.</returns>
        public static Func<TArg1, Func<TArg2, Func<TArg3, Func<TArg4, Func<TArg5, Func<TArg6, Func<TArg7, Func<TArg8, TReturn>>>>>>>> Curry<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(
          this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn> func)
        {
            return arg1 => arg2 => arg3 => 
                   arg4 => arg5 => arg6 => 
                   arg7 => arg8 => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        /// <summary>
        /// Curry function.
        /// </summary>
        /// <param name="func">Function to curry.</param>
        /// <returns>Curried form of the function.</returns>
        public static Func<TArg1, Func<TArg2, Func<TArg3, Func<TArg4, Func<TArg5, Func<TArg6, Func<TArg7, Func<TArg8, Func<TArg9, TReturn>>>>>>>>> Curry<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(
          this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn> func)
        {
            return arg1 => arg2 => arg3 => 
                   arg4 => arg5 => arg6 => 
                   arg7 => arg8 => arg9 => func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }
    }
}