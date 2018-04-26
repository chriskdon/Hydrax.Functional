using System;

namespace Hydrax.Functional {
    public abstract class Union<TBase, T1, T2, T3, T4, T5, T6>
        where T1 : TBase
        where T2 : TBase
        where T3 : TBase
        where T4 : TBase
        where T5 : TBase
        where T6 : TBase
    {

        public TResult Match<TResult>(
            Func<T1, TResult> t1Fn,
            Func<T2, TResult> t2Fn,
            Func<T3, TResult> t3Fn,
            Func<T4, TResult> t4Fn,
            Func<T5, TResult> t5Fn,
            Func<T6, TResult> t6Fn)
        {
            if(this is T1 t1) { return t1Fn(t1); }
            if(this is T2 t2) { return t2Fn(t2); }
            if(this is T3 t3) { return t3Fn(t3); }
            if(this is T4 t4) { return t4Fn(t4); }
            if(this is T5 t5) { return t5Fn(t5); }
            if(this is T6 t6) { return t6Fn(t6); }
        
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
            Action<T3> t3Ac,
            Action<T4> t4Ac,
            Action<T5> t5Ac,
            Action<T6> t6Ac)
        {
            if(this is T1 t1) { t1Ac(t1); return; }
            if(this is T2 t2) { t2Ac(t2); return; }
            if(this is T3 t3) { t3Ac(t3); return; }
            if(this is T4 t4) { t4Ac(t4); return; }
            if(this is T5 t5) { t5Ac(t5); return; }
            if(this is T6 t6) { t6Ac(t6); return; }
        
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