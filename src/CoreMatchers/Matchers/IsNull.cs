using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsNull : Matcher
    {
        public override bool Matches(object actual)
        {
            return actual == null;
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("null");
        }
    }
}
