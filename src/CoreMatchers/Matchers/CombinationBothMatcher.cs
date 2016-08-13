using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Matchers
{
    public sealed class CombinationBothMatcher<T>
    {
        private readonly Matcher<T> _firstMatcher;

        public CombinationBothMatcher(Matcher<T> matcher)
        {
            _firstMatcher = matcher;
        }

        public CombinationMatcher<T> And(Matcher<T> otherMatcher)
        {
            return new CombinationMatcher<T>(_firstMatcher).And(otherMatcher);
        }
    }
}
