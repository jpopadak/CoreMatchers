using System.Text.RegularExpressions;
using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Text
{
    public class IsBlankString : TypeSafeMatcher<string>
    {
        private static readonly Regex RegexWhitespace = new Regex(@"^\s*$", RegexOptions.Multiline);

        public override void Describe(IDescription description)
        {
            description.AppendText("a blank string");
        }

        protected override bool MatchesSafely(string item)
        {
            return RegexWhitespace.IsMatch(item);
        }
    }
}