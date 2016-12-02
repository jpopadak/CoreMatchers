using System.Collections.Generic;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsDictionaryWithSize<TKey, TValue> : FeatureMatcher<IDictionary<TKey, TValue>, int>
    {
        public IsDictionaryWithSize(IMatcher<int> sizeMatcher) 
            : base(sizeMatcher, "a dictionary with size", "map size")
        {
            // Do nothing
        }

        protected override int FeatureValueOf(IDictionary<TKey, TValue> actual)
        {
            return actual.Count;
        }
    }
}