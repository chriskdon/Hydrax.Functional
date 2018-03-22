using System;

namespace Hydrax.Functional
{
    /// <summary>
    /// Common functions.
    /// </summary>
    public static class Functions
    {
        /// <summary>
        /// Identity function.
        /// </summary>
        /// <param name="value">Input value.</param>
        /// <returns>Return is the same as input value.</returns>
        public static T Identity<T>(T value) => value;
    }
}
