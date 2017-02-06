using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Text
{
    public class IsEqualCompressingWhiteSpace : TypeSafeMatcher<IEnumerable<char>>
    {
        private readonly string _value;
        private readonly string _originalValue;

        public IsEqualCompressingWhiteSpace(IEnumerable<char> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Cannot be null");
            }
            _originalValue = value.ToString();
            _value = RemoveRepeatedSpaces(value);
        }

        protected override bool MatchesSafely(IEnumerable<char> item)
        {
            return _value.Equals(RemoveRepeatedSpaces(item));
        }

        protected override void DescribeMismatchSafely(IEnumerable<char> item, IDescription mismatchDescription)
        {
            mismatchDescription.AppendText("was ");
            mismatchDescription.AppendValue(item);
            mismatchDescription.AppendText(" compressing white space to ");
            mismatchDescription.AppendValue(RemoveRepeatedSpaces(item));
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("a string ");
            description.AppendValue(_originalValue);
            description.AppendText(" compressing white space to ");
            description.AppendValue(_value);
        }

        private static string RemoveRepeatedSpaces(IEnumerable<char> chars)
        {
            char[] values = chars.ToArray();
            StringBuilder builder = new StringBuilder();
            var previousIsWhitespace = false;
            foreach (var currentChar in values)
            {
                if (char.IsWhiteSpace(currentChar))
                {
                    if (previousIsWhitespace)
                    {
                        continue;
                    }

                    previousIsWhitespace = true;
                    builder.Append(' ');
                }
                else
                {
                    previousIsWhitespace = false;
                    builder.Append(currentChar);
                }
            }
            return builder.ToString().Trim();
        }
    }
}