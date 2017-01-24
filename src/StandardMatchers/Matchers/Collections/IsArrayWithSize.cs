using System;
using JPopadak.CoreMatchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Collections
{
    public class IsArrayWithSize<T> : FeatureMatcher<T[], int>
    {
        public IsArrayWithSize(IMatcher<int> sizeMatcher)
            : base(sizeMatcher, "an array with size", "array size")
        {
            // Do Nothing
        }

        protected override int FeatureValueOf(T[] actual)
        {
            return actual.Length;
        }
    }
}