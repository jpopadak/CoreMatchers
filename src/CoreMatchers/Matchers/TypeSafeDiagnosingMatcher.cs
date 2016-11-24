using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public abstract class TypeSafeDiagnosingMatcher<T> : Matcher<T>
    {
        /// <summary>
        /// Subclasses should implement this. The item will already have been checked
        /// for the specific type and will never be null.
        /// </summary>
        protected abstract bool MatchesSafely(T item, IDescription mismatchDescription);

        /// <summary>
        /// Method made final to prevent accidental override.
        /// If you need to override this, there's no point on extending TypeSafeMatcher.
        /// Instead, extend Matcher.
        /// </summary>
        public sealed override bool Matches(object actual)
        {
            // Cannot use 'as' here due to _expectedType not being constrained to Class types
            if (actual == null || !(actual is T))
            {
                return false;
            }

            return MatchesSafely((T)actual, new Description());
        }

        /// <summary>
        /// Method made final to prevent accidental override.
        /// Override DescribeMismatchSafely instead.
        /// </summary>
        public override void DescribeMismatch(object actual, IDescription description)
        {
            if (actual == null)
            {
                description.AppendText("was null ");
            }
            else if (!(actual is T))
            {
                description.AppendText("was ")
                           .AppendText(actual.GetType().Name)
                           .AppendText(" (")
                           .AppendValue(actual)
                           .AppendText(")");
            }
            else
            {
                MatchesSafely((T)actual, description);
            }
        }
    }
}
