using JPopadak.CoreMatchers;
using JPopadak.CoreMatchers.Matchers;
using Xunit;
using static JPopadak.StandardMatchers.Matchers.Matchers;

namespace JPopadak.StandardMatchers.Tests.Matchers.Text
{
    public class IsBlankStringFacts
    {
        [Fact]
        public void NullValue_BlankString_IsNullSafe()
        {
            // Given
            IMatcher<string> matcher = BlankString();

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_BlankString_IsTypeSafe()
        {
            // Given
            IMatcher<string> matcher = BlankString();

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void EmptyString_BlankString_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = BlankString();
            string actual = string.Empty;

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void EmptyString_BlankOrNullString_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = BlankOrNullString();
            string actual = string.Empty;

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void NullString_BlankString_ReturnsFalse()
        {
            // Given
            IMatcher<string> matcher = BlankString();
            string actual = null;

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void NullString_BlankOrNullString_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = BlankOrNullString();
            string actual = null;

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void TabbedString_BlankString_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = BlankString();
            string actual = "\t";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void TabbedString_BlankOrNullString_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = BlankOrNullString();
            string actual = "\t";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void NewLineString_BlankString_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = BlankString();
            string actual = "\n";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void NewLineString_BlankOrNullString_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = BlankOrNullString();
            string actual = "\n";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void LetterAString_BlankString_ReturnsFalse()
        {
            // Given
            IMatcher<string> matcher = BlankString();
            string actual = "A";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void LetterAString_BlankOrNullString_ReturnsFalse()
        {
            // Given
            IMatcher<string> matcher = BlankOrNullString();
            string actual = "A";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void BlankString_BlankString_HasReadableDescription()
        {
            // Given
            IMatcher<string> matcher = BlankString();

            // When
            TestHelper.AssertDescription("a blank string", matcher);

            // Then - No Exception
        }

        [Fact]
        public void BlankOrNullString_BlankOrNullString_HasReadableDescription()
        {
            // Given
            IMatcher<string> matcher = BlankOrNullString();

            // When
            TestHelper.AssertDescription("(null or a blank string)", matcher);

            // Then - No Exception
        }

        [Fact]
        public void LetterAString_BlankString_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<string> matcher = BlankString();
            string actual = "A";

            // When
            TestHelper.AssertMismatchDescription("was \"A\"", matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void LetterAString_BlankOrNullString_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<string> matcher = BlankOrNullString();
            string actual = "A";

            // When
            TestHelper.AssertMismatchDescription("was \"A\"", matcher, actual);

            // Then - No Exception
        }
    }
}