using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Matchers
{
    public sealed class CombinationBothMatcher
    {
        private readonly Matcher _firstMatcher;

        public CombinationBothMatcher(Matcher matcher)
        {
            _firstMatcher = matcher;
        }

        public CombinationMatcher<T> And<T>(Matcher otherMatcher)
        {
            return new CombinationMatcher<T>(_firstMatcher).And(otherMatcher);
        }
    }
}
