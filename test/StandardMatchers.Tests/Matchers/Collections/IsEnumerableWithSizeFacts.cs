using System.Collections.Generic;
using JPopadak.CoreMatchers;
using JPopadak.CoreMatchers.Matchers;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;
using static JPopadak.StandardMatchers.Matchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Collections
{
    public class IsEnumerableWithSizeFacts
    {
        [Fact]
        public void NullValue_IsEnumerableWithSize_IsNullSafe()
        {
            // Given
            IMatcher<IEnumerable<string>> matcher = EnumerableWithSize<string>(1);

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_IsEnumerableWithSize_IsTypeSafe()
        {
            // Given
            IMatcher<IEnumerable<string>> matcher = getMatcher(1);

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void ExpectedSize0AndActualSize0_IsEnumerableWithSize_Matches()
        {
            // Given
            IMatcher<IEnumerable<string>> matcher = getMatcher(0);

            // When
            TestHelper.AssertMatches(matcher, getEmptyEnumerable());

            // Then - No Exception
        }

        [Fact]
        public void ExpectedSize1AndActualSize0_IsEnumerableWithSize_DoesNotMatch()
        {
            // Given
            IMatcher<IEnumerable<string>> matcher = getMatcher(1);

            // When
            TestHelper.AssertDoesNotMatch(matcher, getEmptyEnumerable());

            // Then - No Exception
        }

        [Fact]
        public void ExpectedSizeNot1AndActualSize0_IsEnumerableWithSize_Matches()
        {
            // Given
            IMatcher<IEnumerable<string>> matcher = getMatcher(Not(1));

            // When
            TestHelper.AssertMatches(matcher, getEmptyEnumerable());

            // Then - No Exception
        }

        [Fact]
        public void ExpectedSizeNot0AndActualSize0_IsEnumerableWithSize_DoesNotMatch()
        {
            // Given
            IMatcher<IEnumerable<string>> matcher = getMatcher(Not(0));

            // When
            TestHelper.AssertDoesNotMatch(matcher, getEmptyEnumerable());

            // Then - No Exception
        }

        [Fact]
        public void ExpectedIs0_IsEnumerableWithSize_DescriptionIsCorrect()
        {
            // Given
            IMatcher<IEnumerable<string>> matcher = getMatcher(0);

            // When
            TestHelper.AssertDescription("an IEnumerable with size <0>", matcher);

            // Then - No Exception
        }

        private IMatcher<IEnumerable<string>> getMatcher(int size)
        {
            return EnumerableWithSize<string>(size);
        }

        private IMatcher<IEnumerable<string>> getMatcher(IMatcher<int> sizeMatcher)
        {
            return EnumerableWithSize<string>(sizeMatcher);
        }

        private IEnumerable<string> getEmptyEnumerable()
        {
            return new List<string>();
        }
    }
}