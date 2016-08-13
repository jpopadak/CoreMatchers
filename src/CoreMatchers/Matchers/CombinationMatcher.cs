using System;
using JPopadak.CoreMatchers.Descriptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Matchers
{
    public class CombinationMatcher<T> : TypeSafeDiagnosingMatcher<T>
    {
        private readonly Matcher<T> _matcher;

        public CombinationMatcher(Matcher<T> matcher)
        {
            _matcher = matcher;
        }

        public override void Describe(IDescription description)
        {
            description.AppendDescribable(_matcher);
        }

        protected override bool MatchesSafely(T item, IDescription mismatchDescription)
        {
            if (!_matcher.Matches(item))
            {
                _matcher.DescribeMismatch(item, mismatchDescription);
                return false;
            }
            return true;
        }

        public CombinationMatcher<T> And(Matcher<T> other)
        {
            return new CombinationMatcher<T>(new AllOf<T>(_matcher, other));
        }

        public CombinationMatcher<T> Or(Matcher<T> other)
        {
            return new CombinationMatcher<T>(new AnyOf<T>(_matcher, other));
        }
    }
}
