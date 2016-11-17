using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsAnything : Matcher
    {
        private readonly string _message;

        public IsAnything()
            : this("ANYTHING")
        {
            // Do Nothing
        }

        public IsAnything(string message)
        {
            _message = message;
        }

        public override bool Matches(object actual)
        {
            return true;
        }

        public override void Describe(IDescription description)
        {
            description.AppendText(_message);
        }
    }
}
