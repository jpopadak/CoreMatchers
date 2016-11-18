using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class CombinationMatcher<T> : TypeSafeDiagnosingMatcher<T>
    {
        private readonly Matcher _matcher;

        public CombinationMatcher(Matcher matcher)
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

        public CombinationMatcher<T> And(Matcher other)
        {
            return new CombinationMatcher<T>(new AllOf(_matcher, other));
        }

        public CombinationMatcher<T> Or(Matcher other)
        {
            return new CombinationMatcher<T>(new AnyOf(_matcher, other));
        }
    }
}
