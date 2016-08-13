using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public abstract class TypeSafeMatcher<T> : Matcher<T>
    {
        /// <summary>
        /// Subclasses should implement this. The item will already have been checked for
        /// the specific type and will never be null.
        /// </summary>
        protected abstract bool MatchesSafely(T item);
        
        /// <summary>
        /// Subclasses should override this. The item will already have been checked for
        /// the specific type and will never be null.
        /// </summary>
        protected virtual void DescribeMismatchSafely(T item, IDescription mismatchDescription)
        {
            base.DescribeMismatch(item, mismatchDescription);
        }

        /// <summary>
        /// Method made final to prevent accidental override.
        /// If you need to override this, there's no point on extending TypeSafeMatcher.
        /// Instead, extend Matcher.
        /// </summary>
        public sealed override bool Matches(object actual)
        {
            // Cannot use 'as' here due to T not being constrained to Class types
            if (actual == null || !(actual is T))
            {
                return false;
            }
            
            return MatchesSafely((T)actual);
        }

        /// <summary>
        /// Method made final to prevent accidental override.
        /// Override DescribeMismatchSafely instead.
        /// </summary>
        public override void DescribeMismatch(object actual, IDescription description)
        {
            if (actual == null)
            {
               base.DescribeMismatch(null, description);

            }
            else if (!(actual is T))
            {
                description.AppendText("was a ")
                           .AppendText(actual.GetType().Name)
                           .AppendText(" (")
                           .AppendValue(actual)
                           .AppendText(")");
            }
            else
            {
                DescribeMismatchSafely((T)actual, description);
            }
        }
    }
}
