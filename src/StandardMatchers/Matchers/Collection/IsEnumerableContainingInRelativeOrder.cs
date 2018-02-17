using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using JPopadak.CoreMatchers.Contracts;
using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Collections
{
    public class IsEnumerableContainingInRelativeOrder<T> : TypeSafeDiagnosingMatcher<IEnumerable<T>>
    {
        private readonly IEnumerable<IMatcher<T>> _matchers;

        public IsEnumerableContainingInRelativeOrder(IEnumerable<IMatcher<T>> matchers)
        {
            _matchers = matchers;
        }

        protected override bool MatchesSafely(IEnumerable<T> items, IDescription mismatchDescription)
        {
            List<IMatcher<T>> matchers = new List<IMatcher<T>>(_matchers);
            
            object lastMatchedItem = null;
            int nextMatchIx = 0;
            foreach (var item in items)
            {
                if (nextMatchIx < matchers.Count)
                {
                    var matcher = matchers.ElementAt(nextMatchIx);
                    if (matcher.Matches(item))
                    {
                        lastMatchedItem = item;
                        nextMatchIx++;
                    }
                }
            }

            if (nextMatchIx >= matchers.Count) return true;
            
            mismatchDescription.AppendDescribable(matchers.ElementAt(nextMatchIx))
                .AppendText(" was not found");
            if (lastMatchedItem != null)
            {
                mismatchDescription.AppendText(" after ")
                    .AppendValue(lastMatchedItem);
            }
            return false;

        }
        
        public override void Describe(IDescription description)
        {
            description.AppendText("enumerable containing ")
                .AppendList("[", ", ", "]", _matchers)
                .AppendText(" in relative order");
        }
    }
}