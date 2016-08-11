using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsNot<T> : Matcher<T>
    {
        private readonly Matcher<T> _matcher;

        public IsNot(Matcher<T> matcher)
        {
            _matcher = matcher;
        }

        public override bool Matches(T actual)
        {
            return !(_matcher.Matches(actual));
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("not ").AppendDescribable(_matcher);
        }
    }
}
