using System;
using System.Linq;
using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Collections
{
    public class IsArray<T> : TypeSafeMatcher<T[]>
    {
        private readonly IMatcher<T>[] _elementMatchers;

        public IsArray(params IMatcher<T>[] elementMatchers)
        {
            _elementMatchers = new IMatcher<T>[elementMatchers.Length];
            Array.Copy(elementMatchers, _elementMatchers, elementMatchers.Length);
        }

        protected override bool MatchesSafely(T[] actualItems)
        {
            if (_elementMatchers.Length != actualItems.Length)
            {
                return false;
            }

            for (var i = 0; i < _elementMatchers.Length; ++i)
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
            if (_elementMatchers.Length != actualItems.Length)
            {
                mismatchDescription.AppendText("array length was ");
                mismatchDescription.AppendValue(actualItems.Length);
                return;
            }

            for (var i = 0; i < _elementMatchers.Length; ++i)
            {
                if (_elementMatchers[i].Matches(actualItems[i]))
                {
                    // If it matches, continue
                    continue;
                }

                // If it doesnt match, write out why
                mismatchDescription.AppendText("element ");
                mismatchDescription.AppendValue(i);
                mismatchDescription.AppendText(" ");
                _elementMatchers[i].DescribeMismatch(actualItems[i], mismatchDescription);
                return;
            }
        }

        public override void Describe(IDescription description)
        {
            description.AppendList(
                DescriptionStart(),
                DescriptionSeparator(),
                DescriptionEnd(),
                // ReSharper disable once CoVariantArrayConversion
                _elementMatchers);
        }

        protected string DescriptionStart()
        {
            return "[";
        }

        protected string DescriptionSeparator()
        {
            return " ";
        }

        protected string DescriptionEnd()
        {
            return "]";
        }
    }
}