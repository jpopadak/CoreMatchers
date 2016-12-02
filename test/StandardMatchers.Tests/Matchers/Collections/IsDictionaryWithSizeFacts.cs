using System.Collections.Generic;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;
using static JPopadak.StandardMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsDictionaryWithSizeFacts
    {
        [Fact]
        public void NullValue_IsDictionaryWithSize_IsNullSafe()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = IsDictionaryWithSize<string, string>(1);

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_IsDictionaryWithSize_IsTypeSafe()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = getMatcher(1);

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void ExpectedSize0AndActualSize0_IsDictionaryWithSize_Matches()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = getMatcher(0);

            // When
            TestHelper.AssertMatches(matcher, getEmptyDictionary());

            // Then - No Exception
        }

        [Fact]
        public void ExpectedSize1AndActualSize0_IsDictionaryWithSize_DoesNotMatch()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = getMatcher(1);

            // When
            TestHelper.AssertDoesNotMatch(matcher, getEmptyDictionary());

            // Then - No Exception
        }

        [Fact]
        public void ExpectedSizeNot1AndActualSize0_IsDictionaryWithSize_Matches()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = getMatcher(Not(1));

            // When
            TestHelper.AssertMatches(matcher, getEmptyDictionary());

            // Then - No Exception
        }

        [Fact]
        public void ExpectedSizeNot0AndActualSize0_IsDictionaryWithSize_DoesNotMatch()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = getMatcher(Not(0));

            // When
            TestHelper.AssertDoesNotMatch(matcher, getEmptyDictionary());

            // Then - No Exception
        }

        [Fact]
        public void ExpectedIs0_IsDictionaryWithSize_DescriptionIsCorrect()
        {
            // Given
            IMatcher<IDictionary<string, string>> matcher = getMatcher(0);

            // When
            TestHelper.AssertDescription("a dictionary with size <0>", matcher);

            // Then - No Exception
        }

        private IMatcher<IDictionary<string, string>> getMatcher(int size)
        {
            return IsDictionaryWithSize<string, string>(size);
        }

        private IMatcher<IDictionary<string, string>> getMatcher(IMatcher<int> sizeMatcher)
        {
            return IsDictionaryWithSize<string, string>(sizeMatcher);
        }

        private IDictionary<string, string> getEmptyDictionary()
        {
            return new Dictionary<string, string>();
        }
    }
}