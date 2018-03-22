using System;
using System.Threading.Tasks;

namespace Hydrax.Functional
{
    public static partial class HxF
    {   
        /// <summary>
        /// Convert method to Func. Useful because extensions methods of
        /// type Func don't work on instance or static methods.
        /// </summary>
        /// <param name="Func<TArg"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Func<T, T> ToFunc<T>(Func<T, T> func)
        {
            return func;
        }

        /// <summary>
        /// Convert method to Func. Useful because extensions methods of
        /// type Func don't work on instance or static methods.
        /// </summary>
        /// <param name="Func<TArg"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Func<TArg, TReturn> ToFunc<TArg, TReturn>(Func<TArg, TReturn> func)
        {
            return func;
        }
    }
}