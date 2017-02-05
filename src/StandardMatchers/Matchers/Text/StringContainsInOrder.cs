using System;
using System.Collections.Generic;
using System.Linq;
using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Text
{
    public class StringContainsInOrder : TypeSafeMatcher<string>
    {
        private readonly StringComparison _comparison;
        private readonly List<string> _substrings;

        public StringContainsInOrder(params string[] substrings)
            : this(false, substrings)
        {
            // Do Nothing
        }

        public StringContainsInOrder(bool withCurrentCulture, params string[] substrings)
        {
            _comparison = withCurrentCulture
                ? StringComparison.CurrentCulture
                : StringComparison.Ordinal;

            if (substrings.Length <= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(substrings), "Must contain more than one. If not, use StringContains");
            }
            _substrings = substrings.ToList();
            if (_substrings.Any(substring => substring == null))
            {
                throw new ArgumentNullException(nameof(substrings), "Cannot contain null strings");
            }
        }

        protected override bool MatchesSafely(string item)
        {
            var index = 0;
            foreach (var substring in _substrings)
            {
                index = item.IndexOf(substring, index, _comparison);
                if (index == -1)
                {
                    return false;
                }
                index += substring.Length; // Increment so we start after that instance
            }
            return true;
        }

        protected override void DescribeMismatchSafely(string item, IDescription mismatchDescription)
        {
            mismatchDescription.AppendText("was \"");
            mismatchDescription.AppendText(item);
            mismatchDescription.AppendText("\"");
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("a string containing ");
            if (_comparison == StringComparison.CurrentCulture)
            {
                description.AppendText("with current culture ");
            }
            description.AppendValueList("", ", ", "", _substrings);
            description.AppendText(" in order");
        }
    }
}