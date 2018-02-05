using System;

namespace JPopadak.CoreMatchers.Contracts
{
    public static class Contract
    {
        public static void Requires<E>(Func<bool> evaluation) where E : Exception, new()
        {
            if (!evaluation.Invoke())
            {
                throw new E();
            }
        }

        public static void Requires<E>(Func<bool> evaluation, string message) where E : Exception, new()
        {
            if (!evaluation.Invoke())
            {
                throw (E)Activator.CreateInstance(typeof(E), message);
            }
        }

        public static void NotNull<T>(this  T value)
        {
            Requires<ArgumentNullException>(() => value != null);
        }

        public static void NotNull<T>(this T value, string name)
        {
            Requires<ArgumentNullException>(() => value != null, name);
        }
    }
}
