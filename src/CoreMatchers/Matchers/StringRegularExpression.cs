using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;
using System.Text.RegularExpressions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class StringRegularExpression : Matcher<string>
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

        public override bool Matches(string actual)
        {
            return _regex.IsMatch(actual);
        }
    }
}
