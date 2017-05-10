using System;
using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Text
{
    public class HasToString : Matcher<string>
    {
        private readonly IMatcher<string> _subMatcher;

        public HasToString(IMatcher<string> subMatcher)
        {
            _subMatcher = subMatcher;
        }

        public override bool Matches(object actual)
        {
            var converted = ConvertToString(actual);
            return _subMatcher.Matches(converted);
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("with ToString()").AppendText(" ").AppendDescribable(_subMatcher);
        }

        public override void DescribeMismatch(object actual, IDescription mismatch)
        {
            var converted = ConvertToString(actual);
            mismatch.AppendText("ToString()").AppendText(" ");
            _subMatcher.DescribeMismatch(converted, mismatch);
        }

        private static string ConvertToString(object actual)
        {
            var converted = "null";
            if (actual != null)
            {
                converted = Convert.ToString(actual);
            }
            return converted;
        }
    }
}