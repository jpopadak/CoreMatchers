using JPopadak.CoreMatchers;
using JPopadak.CoreMatchers.Matchers;
using Xunit;
using static JPopadak.StandardMatchers.Matchers.Matchers;

namespace JPopadak.StandardMatchers.Tests.Matchers.Text
{
    public class IsEmptyStringFacts
    {
        [Fact]
        public void NullValue_EmptyString_IsNullSafe()
        {
            // Given
            IMatcher<string> matcher = EmptyString();

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_EmptyString_IsTypeSafe()
        {
            // Given
            IMatcher<string> matcher = EmptyString();

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void EmptyString_EmptyString_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = EmptyString();
            string actual = string.Empty;

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void EmptyString_EmptyOrNullString_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = EmptyOrNullString();
            string actual = string.Empty;

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void NullString_EmptyString_ReturnsFalse()
        {
            // Given
            IMatcher<string> matcher = EmptyString();
            string actual = null;

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void NullString_EmptyOrNullString_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = EmptyOrNullString();
            string actual = null;

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void BlankString_EmptyString_ReturnsFalse()
        {
            // Given
            IMatcher<string> matcher = EmptyString();
            string actual = "     ";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void BlankString_EmptyOrNullString_ReturnsFalse()
        {
            // Given
            IMatcher<string> matcher = EmptyOrNullString();
            string actual = "     ";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void CharsInString_EmptyString_ReturnsFalse()
        {
            // Given
            IMatcher<string> matcher = EmptyString();
            string actual = "a";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void CharsInString_EmptyOrNullString_ReturnsFalse()
        {
            // Given
            IMatcher<string> matcher = EmptyOrNullString();
            string actual = "a";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void EmptyString_EmptyString_HasReadableDescription()
        {
            // Given
            IMatcher<string> matcher = EmptyString();

            // When
            TestHelper.AssertDescription("an empty string", matcher);

            // Then - No Exception
        }

        [Fact]
        public void EmptyOrNullString_EmptyOrNullString_HasReadableDescription()
        {
            // Given
            IMatcher<string> matcher = EmptyOrNullString();

            // When
            TestHelper.AssertDescription("(null or an empty string)", matcher);

            // Then - No Exception
        }

        [Fact]
        public void CharsInString_EmptyString_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<string> matcher = EmptyString();
            string actual = "a";

            // When
            TestHelper.AssertMismatchDescription("was \"a\"", matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void CharsInString_EmptyOrNullString_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<string> matcher = EmptyOrNullString();
            string actual = "a";

            // When
            TestHelper.AssertMismatchDescription("was \"a\"", matcher, actual);

            // Then - No Exception
        }
    }
}