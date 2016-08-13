using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class AllOf<T> : DiagnosingMatcher<T>
    {
        private readonly Matcher<T>[] _matchers;

        public AllOf(params Matcher<T>[] matchers)
        {
            _matchers = matchers;
        }

        public AllOf(IEnumerable<Matcher<T>> matchers)
            : this(matchers.ToArray())
        {
            // Do Nothing
        }

        public override void Describe(IDescription description)
        {
            description.AppendList("(", " " + "and" + " ", ")", _matchers);
        }

        protected override bool Matches(object actual, IDescription description)
        {
            foreach (Matcher<T> matcher in _matchers)
            {
                if (!matcher.Matches(actual))
                {
                    description.AppendDescribable(matcher).AppendText(" ");
                    matcher.DescribeMismatch(actual, description);
                    return false;
                }
            }
            return true;
        }
    }
}
