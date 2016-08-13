using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Matchers
{
    public sealed class BothMatcher<T>
    {
        private readonly Matcher<T> _firstMatcher;

        public BothMatcher(Matcher<T> firstMatcher)
        {
            _firstMatcher = firstMatcher;
        }

        public CombinationMatcher<T> And(Matcher<T> secondMatcher)
        {
            return new CombinationMatcher<T>(_firstMatcher).And(secondMatcher);
        }
    }
}
