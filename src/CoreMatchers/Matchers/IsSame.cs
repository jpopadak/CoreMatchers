using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsSame : Matcher
    {
        private readonly object _value;

        public IsSame(object value)
        {
            _value = value;
        }

        public override bool Matches(object actual)
        {
            return ReferenceEquals(actual, _value);
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("sameInstance(")
                .AppendValue(_value)
                .AppendText(")");
        }
    }
}
