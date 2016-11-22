using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class CombinationMatcher<T> : TypeSafeDiagnosingMatcher<T>
    {
        private readonly IMatcher<T> _matcher;

        public CombinationMatcher(IMatcher<T> matcher)
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

        public CombinationMatcher<T> And(IMatcher<T> other)
        {
            return new CombinationMatcher<T>(new AllOf<T>(_matcher, other));
        }

        public CombinationMatcher<T> Or(IMatcher<T> other)
        {
            return new CombinationMatcher<T>(new AnyOf<T>(_matcher, other));
        }
    }
}
