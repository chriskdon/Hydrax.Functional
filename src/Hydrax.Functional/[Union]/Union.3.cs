using System;

namespace Hydrax.Functional {
    public abstract class Union<TBase, T1, T2, T3>
        where T1 : TBase
        where T2 : TBase
        where T3 : TBase
    {

        public TResult Match<TResult>(
            Func<T1, TResult> t1Fn,
            Func<T2, TResult> t2Fn,
            Func<T3, TResult> t3Fn)
        {
            if(this is T1 t1) { return t1Fn(t1); }
            if(this is T2 t2) { return t2Fn(t2); }
            if(this is T3 t3) { return t3Fn(t3); }
        
            throw new InvalidOperationException();
        }

        public TResult Match<T, TResult>(
            Func<T, TResult> tFn, 
            Func<TResult> otherwiseFn) where T : TBase
        {
            if(this is T t) { return tFn(t); }

            return otherwiseFn();
        }

        public void Match<TResult>(
            Action<T1> t1Ac,
            Action<T2> t2Ac,
            Action<T3> t3Ac)
        {
            if(this is T1 t1) { t1Ac(t1); return; }
            if(this is T2 t2) { t2Ac(t2); return; }
            if(this is T3 t3) { t3Ac(t3); return; }
        
            throw new InvalidOperationException();
        }

        public void Match<T, TResult>(
            Action<T> tAc, 
            Action otherwiseAc) where T : TBase
        {
            if(this is T t) { tAc(t); }

            otherwiseAc();
        }
    }
}