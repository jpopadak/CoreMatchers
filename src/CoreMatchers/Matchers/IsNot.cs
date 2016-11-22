using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsNot<T> : Matcher<T>
    {
        private readonly IMatcher<T> _matcher;

        public IsNot(IMatcher<T> matcher)
        {
            _matcher = matcher;
        }

        public override bool Matches(object actual)
        {
            return !_matcher.Matches(actual);
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("not ").AppendDescribable(_matcher);
        }
    }
}
