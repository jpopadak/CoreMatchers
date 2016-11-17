using System;

namespace JPopadak.CoreMatchers.Contracts
{
    public static class Contract
    {
        public static void Requires<E>(bool evaluation) where E : Exception, new()
        {
            if (!evaluation)
            {
                throw new E();
            }
        }

        public static void Requires<E>(bool evaluation, string message) where E : Exception, new()
        {
            if (!evaluation)
            {
                throw (E)Activator.CreateInstance(typeof(E), new object[] { message });
            }
        }

        public static void NotNull<T>(this T value)
        {
            Requires<ArgumentNullException>(value != null);
        }

        public static void NotNull<T>(this T value, string name)
        {
            Requires<ArgumentNullException>(value != null, name);
        }
    }
}
