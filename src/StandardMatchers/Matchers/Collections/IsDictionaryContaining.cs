using System.Collections.Generic;
using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Collections
{
    public class IsDictionaryContaining<TKey, TValue> : TypeSafeMatcher<IDictionary<TKey, TValue>>
    {
        private readonly IMatcher<TKey> _keyMatcher;
        private readonly IMatcher<TValue> _valueMatcher;

        public IsDictionaryContaining(IMatcher<TKey> keyMatcher, IMatcher<TValue> valueMatcher)
        {
            _keyMatcher = keyMatcher;
            _valueMatcher = valueMatcher;
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("a dictionary containing [")
                .AppendDescribable(_keyMatcher)
                .AppendText("->")
                .AppendDescribable(_valueMatcher)
                .AppendText("]");
        }

        protected override void DescribeMismatchSafely(IDictionary<TKey, TValue> actual, IDescription mismatchDescription)
        {
            mismatchDescription.AppendText("dictionary was [");
            bool separate = false;
            foreach (TKey key in actual.Keys)
            {
                if (separate)
                {
                    mismatchDescription.AppendText(", ");
                }

                TValue value = actual[key];
                mismatchDescription.AppendValue(key)
                    .AppendText("->")
                    .AppendValue(value);

                separate = true;
            }
            mismatchDescription.AppendText("]");
        }

        protected override bool MatchesSafely(IDictionary<TKey, TValue> dictionary)
        {
            foreach (TKey key in dictionary.Keys)
            {
                if (_keyMatcher.Matches(key))
                {
                    TValue value = dictionary[key];
                    if (_valueMatcher.Matches(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}