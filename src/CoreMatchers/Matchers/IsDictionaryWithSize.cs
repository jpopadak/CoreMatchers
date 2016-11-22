using System.Collections.Generic;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsDictionaryWithSize<TKey, TValue> : FeatureMatcher<IDictionary<TKey, TValue>, int>
    {
        private readonly IMatcher<int> _sizeMatcher;

        public IsDictionaryWithSize(IMatcher<int> sizeMatcher) : base(sizeMatcher, "a dictionary with size", "map size")
        {
            _sizeMatcher = sizeMatcher;
        }

        protected override int FeatureValueOf(IDictionary<TKey, TValue> actual)
        {
            return actual.Count;
        }

        public override void Describe(IDescription description)
        {
            base.Describe(description);
            description.AppendText(" with size ");
            _sizeMatcher.Describe(description);
        }
    }
}