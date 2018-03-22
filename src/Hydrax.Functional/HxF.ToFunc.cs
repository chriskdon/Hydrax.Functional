using System;
using System.Threading.Tasks;

namespace Hydrax.Functional
{
    public static partial class HxF
    {   
        /// <summary>
        /// Convert method to Func type. Useful because extensions methods of
        /// type Func don't work on instance or static methods.
        /// </summary>
        /// <param name="func">Function to convert.</param>
        /// <returns>Converted function.</returns>
        public static Func<T, T> ToFunc<T>(Func<T, T> func)
        {
            return func;
        }

        /// <summary>
        /// Convert method to Func type. Useful because extensions methods of
        /// type Func don't work on instance or static methods.
        /// </summary>
        /// <param name="func">Function to convert.</param>
        /// <returns>Converted function.</returns>
        public static Func<TArg, TReturn> ToFunc<TArg, TReturn>(Func<TArg, TReturn> func)
        {
            return func;
        }

        /// <summary>
        /// Convert method to Func type. Useful because extensions methods of
        /// type Func don't work on instance or static methods.
        /// </summary>
        /// <param name="func">Function to convert.</param>
        /// <returns>Converted function.</returns>
        public static Func<TArg1, TArg2, TReturn> ToFunc<TArg1, TArg2, TReturn>(
            Func<TArg1, TArg2, TReturn> func)
        {
            return func;
        }

        /// <summary>
        /// Convert method to Func type. Useful because extensions methods of
        /// type Func don't work on instance or static methods.
        /// </summary>
        /// <param name="func">Function to convert.</param>
        /// <returns>Converted function.</returns>
        public static Func<TArg1, TArg2, TArg3, TReturn> ToFunc<TArg1, TArg2, TArg3, TReturn>(
            Func<TArg1, TArg2, TArg3, TReturn> func)
        {
            return func;
        }

        /// <summary>
        /// Convert method to Func type. Useful because extensions methods of
        /// type Func don't work on instance or static methods.
        /// </summary>
        /// <param name="func">Function to convert.</param>
        /// <returns>Converted function.</returns>
        public static Func<TArg1, TArg2, TArg3, TArg4, TReturn> ToFunc<TArg1, TArg2, TArg3, TArg4, TReturn>(
            Func<TArg1, TArg2, TArg3, TArg4, TReturn> func)
        {
            return func;
        }

        /// <summary>
        /// Convert method to Func type. Useful because extensions methods of
        /// type Func don't work on instance or static methods.
        /// </summary>
        /// <param name="func">Function to convert.</param>
        /// <returns>Converted function.</returns>
        public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> ToFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(
            Func<TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> func)
        {
            return func;
        }

        /// <summary>
        /// Convert method to Func type. Useful because extensions methods of
        /// type Func don't work on instance or static methods.
        /// </summary>
        /// <param name="func">Function to convert.</param>
        /// <returns>Converted function.</returns>
        public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn> ToFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(
            Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn> func)
        {
            return func;
        }

        /// <summary>
        /// Convert method to Func type. Useful because extensions methods of
        /// type Func don't work on instance or static methods.
        /// </summary>
        /// <param name="func">Function to convert.</param>
        /// <returns>Converted function.</returns>
        public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn> ToFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(
            Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn> func)
        {
            return func;
        }

        /// <summary>
        /// Convert method to Func type. Useful because extensions methods of
        /// type Func don't work on instance or static methods.
        /// </summary>
        /// <param name="func">Function to convert.</param>
        /// <returns>Converted function.</returns>
        public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn> ToFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(
            Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn> func)
        {
            return func;
        }

        /// <summary>
        /// Convert method to Func type. Useful because extensions methods of
        /// type Func don't work on instance or static methods.
        /// </summary>
        /// <param name="func">Function to convert.</param>
        /// <returns>Converted function.</returns>
        public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn> ToFunc<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(
            Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn> func)
        {
            return func;
        }
    }
}