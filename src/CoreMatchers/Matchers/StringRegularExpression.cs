using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;
using System.Text.RegularExpressions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class StringRegularExpression : TypeSafeDiagnosingMatcher<string>
    {
        private readonly Regex _regex;

        public StringRegularExpression(Regex regex)
        {
            _regex = regex;
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("a string matching the pattern ").AppendValue(_regex.ToString());
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
