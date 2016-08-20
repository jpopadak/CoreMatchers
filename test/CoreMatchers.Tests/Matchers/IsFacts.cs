using JPopadak.CoreMatchers.Matchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsFacts
    {
        [Fact]
        public void NullValue_Is_IsNullSafe()
        {
            // Given
            string actual = "actual";
            Matcher<string> matcher = Is(actual);

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_Is_IsTypeSafe()
        {
            // Given
            string actual = "actual";
            Matcher<string> matcher = Is(actual);

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void TrueValue_IsEqualTo_ReturnsTrueAndIsMatchesSameBehaviorAsIsEqualTo()
        {
            // Given
            bool actual = true;
            Matcher<bool> matcher = new Is<bool>(new IsEqual<bool>(actual));

            // When
            TestHelper.AssertMatches(matcher, true);

            // Then - No Exception
        }

        [Fact]
        public void TrueMatcherFalseValue_IsEqualTo_ReturnsFalseAndIsMatchesSameBehaviorAsIsEqualTo()
        {
            // Given
            bool actual = true;
            Matcher<bool> matcher = new Is<bool>(new IsEqual<bool>(actual));

            // When
            TestHelper.AssertDoesNotMatch(matcher, false);

            // Then - No Exception
        }

        [Fact]
        public void TrueExpectedAndActual_IsEqualTo_DescriptionHasIsInIt()
        {
            // Given
            bool actual = true;
            Matcher<bool> matcher = new Is<bool>(new IsEqual<bool>(actual));

            // When
            TestHelper.AssertDescription("is <True>", matcher);

            // Then - No Exception
        }

        [Fact]
        public void LetterA_Is_DescriptionHasIsInIt()
        {
            // Given
            char expected = 'A';
            Matcher<char> matcher = Is(expected);

            // When
            TestHelper.AssertDescription("is \"A\"", matcher);

            // Then - No Exception
        }
    }
}
