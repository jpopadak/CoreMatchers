using JPopadak.CoreMatchers.Matchers;
using JPopadak.StandardMatchers.Matchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.StandardMatchers.Matchers
{
    public static class Matchers
    {
        /// <summary>
        /// Creates a matcher for Iterables matching examined 
        /// iterables that yield no items.
        /// For example:
        /// <code>Assert.That(new List&lt;String&gt;(), Is(EmptyEnumerable()))</code>
        /// </summary>
        public static IMatcher<IEnumerable<T>> EmptyEnumerable<T>()
        {
            return new IsEmptyEnumerable<T>();
        }
    }
}
