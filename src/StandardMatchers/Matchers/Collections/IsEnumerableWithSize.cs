using System.Collections.Generic;
using System.Linq;
using JPopadak.CoreMatchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Collections
{
    public class IsEnumerableWithSize<T> : FeatureMatcher<IEnumerable<T>, int>
    {
        public IsEnumerableWithSize(IMatcher<int> subMatcher)
            : base(subMatcher, "an IEnumerable with size", "IEnumerable size")
        {
            // Do nothing
        }

        protected override int FeatureValueOf(IEnumerable<T> actual)
        {
            return actual.Count();
        }
    }
}