using System;

namespace Hydrax.Functional
{
    public static class Optional
    {
        public static Optional<TValue> Some<TValue>(TValue value)
        {
            return new Optional<TValue>(true, value);
        }

        public static Optional<TValue> None<TValue>() 
        {
            return new Optional<TValue>(false, default(TValue));
        }
    }
    
    public struct Optional<TValue>
    {
        public bool HasValue { get; }

        internal TValue Value { get; }

        internal Optional(bool hasValue, TValue value) 
        {
            this.HasValue = hasValue;

            if(hasValue)
            {
                this.Value = value;
            } 
            else
            {
                this.Value = default(TValue);
            }
        }

        public override string ToString() 
        {
            return this.Match(value => $"Some({value})", () => "None");
        }
    }
}
