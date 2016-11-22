using System;
using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Internal;

namespace JPopadak.CoreMatchers.Matchers
{
    public abstract class FeatureMatcher<TSafe, TSub> : TypeSafeDiagnosingMatcher<TSafe>
    {
        private static readonly ReflectiveTypeFinder TYPE_FINDER = new ReflectiveTypeFinder("FeatureValueOf", 1, 0);
        private readonly IMatcher<TSub> _subMatcher;
        private readonly String _featureDescription;
        private readonly String _featureName;

        public FeatureMatcher(IMatcher<TSub> subMatcher, String featureDescription, String featureName) : base(TYPE_FINDER)
        {
            _subMatcher = subMatcher;
            _featureDescription = featureDescription;
            _featureName = featureName;
        }

        protected abstract TSub FeatureValueOf(TSafe actual);

        protected override bool MatchesSafely(TSafe actual, IDescription mismatch)
        {
            TSub featureValue = FeatureValueOf(actual);
            if (!_subMatcher.Matches(featureValue))
            {
                mismatch.AppendText(_featureName).AppendText(" ");
                _subMatcher.DescribeMismatch(featureValue, mismatch);
                return false;
            }
            return true;
        }

        public override void Describe(IDescription description)
        {
            description.AppendText(_featureDescription).AppendText(" ").AppendDescribable(_subMatcher);
        }
    }
}