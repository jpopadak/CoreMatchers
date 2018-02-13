using System.Collections.Generic;
using System.Linq;
using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Collections
{
    public class IsEnumerableContainingInAnyOrder<T> : TypeSafeDiagnosingMatcher<IEnumerable<T>>
    {
        private readonly IEnumerable<IMatcher<T>> _matchers;

        public IsEnumerableContainingInAnyOrder(IEnumerable<IMatcher<T>> matchers)
        {
            _matchers = matchers;
        }

        protected override bool MatchesSafely(IEnumerable<T> items, IDescription mismatchDescription)
        {
            Matching<T> matching = new Matching<T>(_matchers, mismatchDescription);
            var enumerable = items as List<T> ?? items.ToList();
            if (enumerable.Any(item => ! matching.Matches(item)))
            {
                return false;
            }
            return matching.IsFinished(enumerable);
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("IEnumerable with items ");
            description.AppendList("[", ", ", "]", _matchers);
            description.AppendText(" in any order");
        }

        private class Matching<TM>
        {
            private readonly List<IMatcher<TM>> _matchers;
            private readonly IDescription _description;

            internal Matching(IEnumerable<IMatcher<TM>> matchers, IDescription description)
            {
                _matchers = new List<IMatcher<TM>>(matchers);
                _description = description;
            }

            public bool Matches(TM item) {
                if (_matchers.Count != 0) return IsMatched(item);
                _description.AppendText("no match for: ");
                _description.AppendValue(item);
                return false;
            }

            public bool IsFinished(IEnumerable<TM> items) {
                if (_matchers.Count == 0)
                {
                    return true;
                }

                _description.AppendText("no item matches: ");
                _description.AppendList("", ", ", "", _matchers);
                _description.AppendText(" in ");
                _description.AppendValueList("[", ", ", "]", items);
                return false;
            }

            private bool IsMatched(TM item) {
                foreach (var matcher in _matchers) {
                    if (!matcher.Matches(item)) continue;
                    _matchers.Remove(matcher);
                    return true;
                }
                _description.AppendText("not matched: ");
                _description.AppendValue(item);
                return false;

            }
        }
    }
}