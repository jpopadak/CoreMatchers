using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Matchers
{
    public sealed class CombinationEitherMatcher<T>
    {
        private readonly Matcher<T> _firstMatcher;

        public CombinationEitherMatcher(Matcher<T> firstMatcher)
        {
            _firstMatcher = firstMatcher;
        }

        public CombinationMatcher<T> Or(Matcher<T> secondMatcher)
        {
            return new CombinationMatcher<T>(_firstMatcher).Or(secondMatcher);
        }
    }
}
