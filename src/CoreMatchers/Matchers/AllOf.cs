using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class AllOf<T> : Matcher<T>
    {
        private readonly Matcher<T>[] _matchers;

        public AllOf(params Matcher<T>[] matchers)
        {
            _matchers = matchers;
        }

        public override void Describe(IDescription description)
        {
            description.AppendList("(", " " + "and" + " ", ")", _matchers);
        }

        public override bool Matches(T actual)
        {
            return _matchers.All(_ => _.Matches(actual));
        }

        public override void DescribeMismatch(T actual, IDescription description)
        {
            foreach (Matcher<T> matcher in _matchers)
            {
                if (!matcher.Matches(actual))
                {
                    description.AppendDescribable(matcher).AppendText(" ");
                    matcher.DescribeMismatch(actual, description);
                }
            }
        }
    }
}
