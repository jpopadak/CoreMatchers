using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Matchers
{
    public sealed class BothMatcher
    {
        private readonly Matcher _firstMatcher;

        public BothMatcher(Matcher firstMatcher)
        {
            _firstMatcher = firstMatcher;
        }

        public CombinationMatcher<T> And<T>(Matcher secondMatcher)
        {
            return new CombinationMatcher<T>(_firstMatcher).And(secondMatcher);
        }
    }
}
