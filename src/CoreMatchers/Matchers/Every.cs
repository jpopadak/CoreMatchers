using System.Collections.Generic;
using System.Linq;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class Every<T> : TypeSafeDiagnosingMatcher<IEnumerable<T>>
    {
        private readonly IMatcher<T> _matcher;

        public Every(IMatcher<T> matcher)
        {
            _matcher = matcher;
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("every item is ").AppendDescribable(_matcher);
        }

        protected override bool MatchesSafely(IEnumerable<T> actual, IDescription description)
        {
            T invalid = actual.FirstOrDefault(value => !_matcher.Matches(value));
            if (invalid != null)
            {
                description.AppendText("an item ");
                _matcher.DescribeMismatch(invalid, description);
                return false;
            }
            return true;
        }
    }
}
