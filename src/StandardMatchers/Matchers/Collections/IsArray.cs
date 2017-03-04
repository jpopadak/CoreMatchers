using System;
using System.Collections.Generic;
using System.Linq;
using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Collections
{
    public class IsArray<T> : TypeSafeMatcher<T[]>
    {
        private readonly List<IMatcher<T>> _elementMatchers;

        public IsArray(params IMatcher<T>[] elementMatchers)
        {
            _elementMatchers = new List<IMatcher<T>>(elementMatchers);
        }

        protected override bool MatchesSafely(T[] actualItems)
        {
            if (_elementMatchers.Count != actualItems.Length)
            {
                return false;
            }

            for (var i = 0; i < _elementMatchers.Count; ++i)
            {
                if (_elementMatchers[i].Matches(actualItems[i]))
                {
                    // If it matches, continue
                    continue;
                }

                // If it doesnt match, write out why
                return false;
            }

            // All matched properly
            return true;
        }

        protected override void DescribeMismatchSafely(T[] actualItems, IDescription mismatchDescription)
        {
            if (_elementMatchers.Count != actualItems.Length)
            {
                mismatchDescription.AppendText("array length was ");
                // ReSharper disable once HeapView.BoxingAllocation
                mismatchDescription.AppendValue(actualItems.Length);
                return;
            }

            for (var i = 0; i < _elementMatchers.Count; ++i)
            {
                if (_elementMatchers[i].Matches(actualItems[i]))
                {
                    // If it matches, continue
                    continue;
                }

                // If it doesnt match, write out why
                mismatchDescription.AppendText("element ");
                // ReSharper disable once HeapView.BoxingAllocation
                mismatchDescription.AppendValue(i);
                mismatchDescription.AppendText(" ");
                _elementMatchers[i].DescribeMismatch(actualItems[i], mismatchDescription);
                return;
            }
        }

        public override void Describe(IDescription description)
        {
            description.AppendList(
                "[",
                ", ",
                "]",
                // ReSharper disable once CoVariantArrayConversion
                _elementMatchers);
        }
    }
}
