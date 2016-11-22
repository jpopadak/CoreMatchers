using System;
using System.Reflection;
using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Internal;

namespace JPopadak.CoreMatchers.Matchers
{
    public abstract class TypeSafeDiagnosingMatcher<T> : Matcher<T>
    {
        private static readonly ReflectiveTypeFinder TYPE_FINDER = new ReflectiveTypeFinder("MatchesSafely", 2, 0);
        private readonly Type _expectedType;

        /// <summary>
        /// Use this constructor if the subclass that implements <code>matchesSafely</code>
        /// is <em>not</em> the class that binds &lt;T&gt; to a type.
        /// </summary>
        /// <param name="expectedType"> The expectedType of the actual value. </param>
        protected TypeSafeDiagnosingMatcher(Type expectedType)
        {
            _expectedType = expectedType;
        }

        /// <summary>
        /// Use this constructor if the subclass that implements <code>matchesSafely</code>
        /// is <em>not</em> the class that binds &lt;T&gt; to a type.
        /// </summary>
        /// <param name="typeFinder">A type finder to extract the type.</param>
        protected TypeSafeDiagnosingMatcher(ReflectiveTypeFinder typeFinder)
        {
            _expectedType = typeFinder.FindExpectedType(GetType());
        }

        /// <summary>
        /// The default constructor for simple sub types.
        /// </summary>
        protected TypeSafeDiagnosingMatcher() : this(TYPE_FINDER) {}

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
            if (actual == null || !_expectedType.IsInstanceOfType(actual))
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
