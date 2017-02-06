using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Number
{
    public class IsNaN : TypeSafeMatcher<double>
    {
        protected override bool MatchesSafely(double item)
        {
            return double.IsNaN(item);
        }

        protected override void DescribeMismatchSafely(double item, IDescription mismatchDescription)
        {
            mismatchDescription.AppendText("was ");
            mismatchDescription.AppendValue(item);
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("a double value of NaN");
        }
    }
}