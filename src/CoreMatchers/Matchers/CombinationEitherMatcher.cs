namespace JPopadak.CoreMatchers.Matchers
{
    public sealed class CombinationEitherMatcher
    {
        private readonly Matcher _firstMatcher;

        public CombinationEitherMatcher(Matcher firstMatcher)
        {
            _firstMatcher = firstMatcher;
        }

        public CombinationMatcher<T> Or<T>(Matcher secondMatcher)
        {
            return new CombinationMatcher<T>(_firstMatcher).Or(secondMatcher);
        }
    }
}
