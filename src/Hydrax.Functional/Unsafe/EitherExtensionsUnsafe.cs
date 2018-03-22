using System;
using System.Threading.Tasks;

namespace Hydrax.Functional.Unsafe
{
    public static class EitherExtensionsUnsafe
    {
        public static TLeft ValueLeftOrThrow<TLeft, TRight>(this Either<TLeft, TRight> either) 
        {
          if(either.IsLeft) { return either.LeftValue; }

          throw new Exception("Either does not have a left value.");
        }

        public static TRight ValueRightOrThrow<TLeft, TRight>(this Either<TLeft, TRight> either) 
        {
          if(either.IsRight) { return either.RightValue; }

          throw new Exception("Either does not have a right value.");
        }
    }
}
