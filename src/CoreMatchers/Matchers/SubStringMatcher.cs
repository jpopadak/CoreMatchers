using JPopadak.CoreMatchers.Contracts;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public abstract class SubStringMatcher : TypeSafeMatcher<string>
    {
        private readonly string _relationship;
        private readonly bool _ignoringCase;
        protected readonly string _substring;

        protected SubStringMatcher(string relationship, bool ignoringCase, string substring)
        {
            _relationship = relationship;
            _ignoringCase = ignoringCase;
            _substring = substring;

            _relationship.NotNull();
            _substring.NotNull();
        }

        protected override bool MatchesSafely(string actual)
        {
            return evalSubstringOf(_ignoringCase ? actual.ToLowerInvariant() : actual);
        }

        protected override void DescribeMismatchSafely(string actual, IDescription description)
        {
            description.AppendText("was \"").AppendText(actual).AppendText("\"");
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("a string ")
                .AppendText(_relationship)
                .AppendText(" ")
                .AppendValue(_substring);

            if (_ignoringCase)
            {
                description.AppendText(" ignoring case");
            }
        }

        protected string converted(string arg)
        {
            return _ignoringCase ? arg.ToLowerInvariant() : arg;
        }

        protected abstract bool evalSubstringOf(string arg);
    }
}
