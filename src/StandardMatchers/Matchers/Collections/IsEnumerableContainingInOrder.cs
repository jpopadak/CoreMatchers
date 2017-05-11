using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Collections
{
    public class IsEnumerableContainingInOrder<T> : TypeSafeDiagnosingMatcher<IEnumerable<T>>
    {
        private readonly IEnumerable<IMatcher<T>> _matchers;

        public IsEnumerableContainingInOrder(IEnumerable<IMatcher<T>> matchers)
        {
            if (matchers == null)
            {
                throw new ArgumentNullException(nameof(matchers), "Must specify matchers");
            }

            _matchers = matchers;
        }

        protected override bool MatchesSafely(IEnumerable<T> items, IDescription mismatchDescription)
        {
            var series = new MatchSeries(_matchers, mismatchDescription);
            if (items.Any(item => !series.Matches(item)))
            {
                return false;
            }
            return series.IsFinished();
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("IEnumerable containing ");
            description.AppendList("[", ", ", "]", _matchers);
        }

        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        private class MatchSeries
        {
            private readonly IDescription _description;
            private readonly List<IMatcher<T>> _matchers;
            private int _nextMatchIndex;

            public MatchSeries(IEnumerable<IMatcher<T>> matchers, IDescription description)
            {
                _description = description;
                if (!matchers.GetEnumerator().MoveNext())
                {
                    throw new ArgumentException("Must have at least one matcher to match the enumerable against", nameof(matchers));
                }
                _matchers = new List<IMatcher<T>>(matchers);
            }

            public bool Matches(T item)
            {
                if (_matchers.Count < _nextMatchIndex)
                {
                    _description.AppendText("not matched: ");
                    _description.AppendValue(item);
                    return false;
                }

                return IsMatched(item);
            }

            private bool IsMatched(T item)
            {
                IMatcher<T> matcher = _matchers[_nextMatchIndex];
                if (!matcher.Matches(item))
                {
                    DescribeMismatch(matcher, item);
                    return false;
                }
                ++_nextMatchIndex;
                return true;
            }

            public bool IsFinished()
            {
                if (_nextMatchIndex < _matchers.Count)
                {
                    _description.AppendText("no item was ");
                    _description.AppendDescribable(_matchers[_nextMatchIndex]);
                    return false;
                }
                return true;
            }

            private void DescribeMismatch(IMatcher<T> matcher, T item)
            {
                _description.AppendText("item " + _nextMatchIndex + ": ");
                matcher.DescribeMismatch(item, _description);
            }
        }
    }
}