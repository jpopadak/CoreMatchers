using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class Every<T> : Matcher<IEnumerable<T>>
    {
        private readonly Matcher<T> _matcher;

        public Every(Matcher<T> matcher)
        {
            _matcher = matcher;
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("every item is ").AppendDescribable(_matcher);
        }

        public override bool Matches(IEnumerable<T> actual)
        {
            return actual.All(_matcher.Matches);
        }

        public override void DescribeMismatch(IEnumerable<T> actual, IDescription description)
        {
            // Will never be empty
            T invalid = actual.First(value => !_matcher.Matches(value));

            description.AppendText("an item ");
            _matcher.DescribeMismatch(invalid, description);
        }
    }
}
