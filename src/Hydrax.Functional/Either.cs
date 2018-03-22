using System;

namespace Hydrax.Functional
{
    public static class Either 
    {
        public static Either<TLeft, TRight> Left<TLeft, TRight>(TLeft left)
        {
            return new Either<TLeft, TRight>(true, left, default(TRight));
        }

        public static Either<TLeft, TRight> Right<TLeft, TRight>(TRight right)
        {
            return new Either<TLeft, TRight>(false, default(TLeft), right);
        }
    }

    public struct Either<TLeft, TRight>
    {
        public bool IsLeft { get; }

        public bool IsRight => !IsLeft;

        internal TLeft LeftValue { get; }

        internal TRight RightValue { get; }

        internal Either(bool isLeft, TLeft left, TRight right) 
        {
            this.IsLeft = isLeft;

            if(isLeft)
            {
                this.LeftValue = left;
                this.RightValue = default(TRight);
            }
            else 
            {
                this.LeftValue = default(TLeft);
                this.RightValue = right;
            }
        }

        public override string ToString()
        {
            return this.Match(
                left => $"Left({left})", 
                right => $"Right({right})");
        }
    }
}
