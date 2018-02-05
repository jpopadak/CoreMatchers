using System;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public abstract class FeatureMatcher<TSafe, TSub> : TypeSafeDiagnosingMatcher<TSafe>
    {
        private readonly IMatcher<TSub> _subMatcher;
        private readonly string _featureDescription;
        private readonly string _featureName;

        protected FeatureMatcher(IMatcher<TSub> subMatcher, string featureDescription, string featureName)
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