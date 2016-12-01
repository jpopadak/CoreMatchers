using System.Collections.Generic;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsDictionaryContainingFacts
    {
        [Fact]
        public void NullValue_IsDictionaryContaining_IsNullSafe()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = HasEntry("", "");

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_IsDictionaryContaining_IsTypeSafe()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = HasEntry("", "");

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void ExpectedKeyIsNotActualKey_IsDictionaryContaining_DoesNotMatch()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = HasKey<string, string>("expected");

            // When
            TestHelper.AssertDoesNotMatch(matcher, getDictionaryWith("unexpected", ""));

            // Then - No Exception
        }

        [Fact]
        public void ExpectedKeyIsActualKey_IsDictionaryContaining_Matches()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = HasKey<string, string>("expected");

            // When
            TestHelper.AssertMatches(matcher, getDictionaryWith("expected", ""));

            // Then - No Exception
        }

        [Fact]
        public void ExpectedValueIsNotActualValue_IsDictionaryContaining_DoesNotMatch()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = HasValue<string, string>("expected");

            // When
            TestHelper.AssertDoesNotMatch(matcher, getDictionaryWith("", "unexpected"));

            // Then - No Exception
        }

        [Fact]
        public void ExpectedValueIsActualValue_IsDictionaryContaining_Matches()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = HasValue<string, string>("expected");

            // When
            TestHelper.AssertMatches(matcher, getDictionaryWith("", "expected"));

            // Then - No Exception
        }

        [Fact]
        public void ExpectedKeyIsActualKeyAndExpectedValueIsActualValue_IsDictionaryContaining_Matcher()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = HasEntry("key", "value");

            // When
            TestHelper.AssertMatches(matcher, getDictionaryWith("key", "value"));

            // Then - No Exception
        }

        [Fact]
        public void ExpectedKeyIsActualKeyAndExpectedValueIsNotActualValue_IsDictionaryContaining_DoesNotMatch()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = HasEntry("key", "expected");

            // When
            TestHelper.AssertDoesNotMatch(matcher, getDictionaryWith("key", "unexpected"));

            // Then - No Exception
        }

        [Fact]
        public void ExpectedKeyIsNotActualKeyAndExpectedValueIsActualValue_IsDictionaryContaining_DoesNotMatch()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = HasEntry("expected", "value");

            // When
            TestHelper.AssertDoesNotMatch(matcher, getDictionaryWith("unexpected", "value"));

            // Then - No Exception
        }

        [Fact]
        public void ExpectedKeyIsNotActualKeyAndExpectedValueIsNotActualValue_IsDictionaryContaining_DoesNotMatch()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = HasEntry("expected", "expected");

            // When
            TestHelper.AssertDoesNotMatch(matcher, getDictionaryWith("unexpected", "unexpected"));

            // Then - No Exception
        }

        [Fact]
        public void KeyAndValueAreBothExpected_IsDictionaryContaining_DescriptionIsCorrect()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = HasEntry("key", "value");

            // When
            TestHelper.AssertDescription("a dictionary containing [\"key\"->\"value\"]", matcher);

            // Then - No Exception
        }

        [Fact]
        public void ExpectedKeyIsNotActualKeyAndExpectedValueIsNotActualValue_IsDictionaryContaining_DescribesMismatchCorrectly()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = HasEntry("expected key", "expected value");

            // When
            TestHelper.AssertMismatchDescription("dictionary was [\"actual key\"->\"actual value\"]", matcher, getDictionaryWith("actual key", "actual value"));

            // Then - No Exception
        }

        private IDictionary<TKey, TValue> getDictionaryWith<TKey, TValue>(TKey key, TValue value)
        {
            IDictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
            dictionary.Add(key, value);
            return dictionary;
        }
    }
}