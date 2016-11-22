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
            string expected = "expected";
            IMatcher<string> matcher = Is(expected);

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_Is_IsTypeSafe()
        {
            // Given
            string expected = "expected";
            IMatcher<string> matcher = Is(expected);

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void TrueValue_IsEqualTo_ReturnsTrueAndIsMatchesSameBehaviorAsIsEqualTo()
        {
            // Given
            bool expected = true;
            IMatcher<bool> matcher = Is(EqualTo(expected));

            // When
            TestHelper.AssertMatches(matcher, true);

            // Then - No Exception
        }

        [Fact]
        public void TrueMatcherFalseValue_IsEqualTo_ReturnsFalseAndIsMatchesSameBehaviorAsIsEqualTo()
        {
            // Given
            bool expected = true;
            IMatcher<bool> matcher = Is(EqualTo(expected));

            // When
            TestHelper.AssertDoesNotMatch(matcher, false);

            // Then - No Exception
        }

        [Fact]
        public void TrueExpectedAndActual_IsEqualTo_DescriptionHasIsInIt()
        {
            // Given
            bool expected = true;
            IMatcher<bool> matcher = Is(EqualTo(expected));

            // When
            TestHelper.AssertDescription("is <True>", matcher);

            // Then - No Exception
        }

        [Fact]
        public void LetterA_Is_DescriptionHasIsInIt()
        {
            // Given
            char expected = 'A';
            IMatcher<char> matcher = Is(expected);

            // When
            TestHelper.AssertDescription("is \"A\"", matcher);

            // Then - No Exception
        }
    }
}
