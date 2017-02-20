using JPopadak.CoreMatchers.Descriptions;
using System.Text.RegularExpressions;
using JPopadak.CoreMatchers.Contracts;

namespace JPopadak.CoreMatchers.Matchers
{
    public class StringRegularExpression : TypeSafeDiagnosingMatcher<string>
    {
        private readonly Regex _regex;

        public StringRegularExpression(string regex)
            : this(regex, false)
        {
            // Do Nothing
        }

        public StringRegularExpression(string regex, bool ignoreCase)
            : this(new Regex(regex, ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None))
        {
            // Do Nothing
        }

        public StringRegularExpression(Regex regex)
        {
            regex.NotNull();
            _regex = regex;
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("a string matching the pattern ").AppendValue(_regex);
        }

        protected override bool MatchesSafely(string item, IDescription mismatchDescription)
        {
            if (!_regex.IsMatch(item))
            {
                mismatchDescription.AppendText("the string was ")
                    .AppendValue(item);
                return false;
            }
            return true;
        }
    }
}
