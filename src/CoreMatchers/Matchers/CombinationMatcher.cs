using System;
using JPopadak.CoreMatchers.Descriptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Matchers
{
    public class CombinationMatcher<T> : Matcher<T>
    {
        private readonly Matcher<T> _matcher;

        public CombinationMatcher(Matcher<T> matcher)
        {
            _matcher = matcher;
        }

        public override bool Matches(T actual)
        {
            return _matcher.Matches(actual);
        }

        public override void Describe(IDescription description)
        {
            description.AppendDescribable(_matcher);
        }

        public override void DescribeMismatch(T actual, IDescription description)
        {
            _matcher.DescribeMismatch(actual, description);
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
