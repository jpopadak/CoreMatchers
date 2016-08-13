using JPopadak.CoreMatchers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public abstract class SubStringMatcher : Matcher<string>
    {
        private readonly string _relationship;
        private readonly bool _ignoringCase;
        protected readonly string _substring;

        protected SubStringMatcher(string relationship, bool ignoringCase, string substring)
        {
            _relationship = relationship;
            _ignoringCase = ignoringCase;
            _substring = substring;

            Contract.NotNull(_substring);
        }

        public override bool Matches(string actual)
        {
            return evalSubstringOf(_ignoringCase ? actual.ToLowerInvariant() : actual);
        }

        public override void DescribeMismatch(string actual, IDescription description)
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
