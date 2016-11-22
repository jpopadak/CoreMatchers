namespace JPopadak.CoreMatchers.Matchers
{
    public sealed class CombinationEitherMatcher<T>
    {
        private readonly IMatcher<T> _firstMatcher;

        public CombinationEitherMatcher(IMatcher<T> firstMatcher)
        {
            _firstMatcher = firstMatcher;
        }

        public CombinationMatcher<T> Or(IMatcher<T> secondMatcher)
        {
            return new CombinationMatcher<T>(_firstMatcher).Or(secondMatcher);
        }
    }
}
