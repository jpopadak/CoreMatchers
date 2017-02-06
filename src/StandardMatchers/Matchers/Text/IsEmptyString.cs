using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Text
{
    public class IsEmptyString : TypeSafeMatcher<string>
    {
        protected override bool MatchesSafely(string item)
        {
            return string.Empty.Equals(item);
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("an empty string");
        }
    }
}