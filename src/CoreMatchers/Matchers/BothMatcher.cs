namespace JPopadak.CoreMatchers.Matchers
{
    public sealed class BothMatcher<T>
    {
        private readonly IMatcher<T> _firstMatcher;

        public BothMatcher(IMatcher<T> firstMatcher)
        {
            _firstMatcher = firstMatcher;
        }

        public CombinationMatcher<T> And(IMatcher<T> secondMatcher)
        {
            return new CombinationMatcher<T>(_firstMatcher).And(secondMatcher);
        }
    }
}
