using System.Collections.Generic;
using System.Linq;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class AllOf<T> : DiagnosingMatcher<T>
    {
        private readonly IDescribable[] _matchers;

        public AllOf(params IMatcher<T>[] matchers)
        {
            _matchers = matchers;
        }

        public AllOf(IEnumerable<IMatcher<T>> matchers)
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
            foreach (var describable in _matchers)
            {
                var matcher = (IMatcher<T>) describable;
                if (matcher.Matches(actual)) continue;
                
                description.AppendDescribable(matcher).AppendText(" ");
                matcher.DescribeMismatch(actual, description);
                return false;
            }
            return true;
        }
    }
}
