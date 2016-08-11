using JPopadak.CoreMatchers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Matchers
{
    public static partial class Matchers
    {
        public static bool Eq(this string actual, string expected)
        {
            Contract.NotNull(expected, nameof(expected));
            if (actual == null)
            {
                return false;
            }
            return actual.Equals(expected);
        }

        public static bool Eq(this char actual, char expected)
        {
            return actual.Equals(expected);
        }

        public static bool Eq(this short actual, short expected)
        {
            return actual.Equals(expected);
        }

        public static bool Eq(this int actual, int expected)
        {
            return actual.Equals(expected);
        }

        public static bool Eq(this long actual, long expected)
        {
            return actual.Equals(expected);
        }

        public static bool Eq<T>(this T actual, T expected)
        {
            Contract.NotNull(expected, nameof(expected));
            if (actual == null)
            {
                return false;
            }
            return actual.Equals(expected);
        }
    }
}
