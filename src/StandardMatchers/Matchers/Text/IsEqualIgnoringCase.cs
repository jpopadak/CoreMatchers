using System;
using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Text
{
    public class IsEqualIgnoringCase : TypeSafeMatcher<string>
    {
        private readonly string _value;
        private readonly StringComparison _comparison;

        public IsEqualIgnoringCase(string value, bool withCurrentCulture = false)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value), "Non-null value required");
            _comparison = withCurrentCulture
                ? StringComparison.CurrentCultureIgnoreCase
                : StringComparison.OrdinalIgnoreCase;
        }

        protected override bool MatchesSafely(string item)
        {
            return string.Equals(_value, item, _comparison);
        }

        protected override void DescribeMismatchSafely(string item, IDescription mismatchDescription)
        {
            mismatchDescription.AppendText(" was ");
            mismatchDescription.AppendValue(item);
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("a string equal to ");
            description.AppendValue(_value);
            description.AppendText(_comparison == StringComparison.CurrentCultureIgnoreCase
                ? " culture ignoring case"
                : " ignoring case");
        }
    }
}