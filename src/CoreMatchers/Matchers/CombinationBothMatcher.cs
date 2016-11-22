namespace JPopadak.CoreMatchers.Matchers
{
    public sealed class CombinationBothMatcher<T>
    {
        private readonly IMatcher<T> _firstMatcher;

        public CombinationBothMatcher(IMatcher<T> matcher)
        {
            _firstMatcher = matcher;
        }

        public CombinationMatcher<T> And(IMatcher<T> otherMatcher)
        {
            return new CombinationMatcher<T>(_firstMatcher).And(otherMatcher);
        }
    }
}
