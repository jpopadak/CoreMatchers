using System;
using JPopadak.CoreMatchers;
using JPopadak.CoreMatchers.Matchers;
using Xunit;
using static JPopadak.StandardMatchers.Matchers.Matchers;

namespace JPopadak.StandardMatchers.Tests.Matchers.Text
{
    public class IsEqualIgnoringCaseFacts
    {
        [Fact]
        public void NullValue_EqualToIgnoringCase_IsNullSafe()
        {
            // Given
            IMatcher<string> matcher = EqualToIgnoringCase("any");

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_EqualToIgnoringCase_IsTypeSafe()
        {
            // Given
            IMatcher<string> matcher = EqualToIgnoringCase("any");

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void AllLower_EqualToIgnoringCase_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = EqualToIgnoringCase("heLLo");
            string actual = "hello";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void OneCapitalL_EqualToIgnoringCase_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = EqualToIgnoringCase("heLLo");
            string actual = "helLo";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void DifferentWordAllTogether_EqualToIgnoringCase_ReturnsFalse()
        {
            // Given
            IMatcher<string> matcher = EqualToIgnoringCase("heLLo");
            string actual = "byeee";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void WhiteSpacePrior_EqualToIgnoringCase_ReturnsFalse()
        {
            // Given
            IMatcher<string> matcher = EqualToIgnoringCase("heLLo");
            string actual = " heLLo";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void WhiteSpaceAfter_EqualToIgnoringCase_ReturnsFalse()
        {
            // Given
            IMatcher<string> matcher = EqualToIgnoringCase("heLLo");
            string actual = "heLLo ";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ExpectedEncyclopædiaActualEncyclopaedia_EqualToIgnoringCaseWithCulture_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = EqualToIgnoringCase(true, "Encyclopædia");
            string actual = "Encyclopaedia";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ExpectedHeLLoActualHello_EqualToIgnoringCaseWithCulture_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = EqualToIgnoringCase(true, "HeLLo");
            string actual = "Hello";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void NullExpectedValue_ConstructEqualToIgnoringCase_ThrowsArgumentNullException()
        {
            // Given
            string expected = null;

            // When
            Assert.Throws<ArgumentNullException>(() => EqualToIgnoringCase(expected));

            // Then - Throws Exception
        }

        [Fact]
        public void NullExpectedValue_ConstructEqualToIgnoringCase_ExceptionMessageExplainsValueCannotBeNull()
        {
            // Given
            string expected = null;

            // When
            var ex = Assert.Throws<ArgumentNullException>(() => EqualToIgnoringCase(expected));

            // Then
            Assert.Contains("Non-null value required", ex.Message);
        }

        [Fact]
        public void EqualToIgnoringCase_EqualToIgnoringCase_HasReadableDescription()
        {
            // Given
            IMatcher<string> matcher = EqualToIgnoringCase("heLLo");

            // When
            TestHelper.AssertDescription("a string equal to \"heLLo\" ignoring case", matcher);

            // Then - No Exception
        }

        [Fact]
        public void EqualToIgnoringCaseIncludingCulture_EqualToIgnoringCase_HasReadableDescription()
        {
            // Given
            IMatcher<string> matcher = EqualToIgnoringCase(true, "heLLo");

            // When
            TestHelper.AssertDescription("a string equal to \"heLLo\" culture ignoring case", matcher);

            // Then - No Exception
        }

        [Fact]
        public void EqualToIgnoringCaseIncludingCulture_EqualToIgnoringCaseIncludingCulture_CarriesAeCombo()
        {
            // Given
            IMatcher<string> matcher = EqualToIgnoringCase(true, "Encyclopædia");

            // When
            TestHelper.AssertDescription("a string equal to \"Encyclopædia\" culture ignoring case", matcher);

            // Then - No Exception
        }

        [Fact]
        public void AddedWord_EqualToIgnoringCaseIncludingCulture_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<string> matcher = EqualToIgnoringCase(true, "Encyclopædia");
            string actual = "Duh Encyclopaedia";

            // When
            TestHelper.AssertMismatchDescription("was \"Duh Encyclopaedia\"", matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Includingæ_EqualToIgnoringCase_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<string> matcher = EqualToIgnoringCase("Encyclopædia");
            string actual = "Encyclopaedia";

            // When
            TestHelper.AssertMismatchDescription("was \"Encyclopaedia\"", matcher, actual);

            // Then - No Exception
        }
    }
}