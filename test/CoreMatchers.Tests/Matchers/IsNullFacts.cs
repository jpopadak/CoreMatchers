using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsNullFacts
    {
        [Fact]
        public void NullValue_IsNull_IsNullSafe()
        {
            // Given
            IMatcher<object> matcher = IsNull<object>();

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void NullValue_IsNotNull_IsNullSafe()
        {
            // Given
            IMatcher<object> matcher = IsNotNull<object>();

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_IsNull_IsTypeSafe()
        {
            // Given
            IMatcher<object> matcher = IsNull<object>();

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_IsNotNull_IsTypeSafe()
        {
            // Given
            IMatcher<object> matcher = IsNotNull<object>();

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void NullValue_IsNull_True()
        {
            // Given
            IMatcher<object> matcher = IsNull<object>();

            // When
            TestHelper.AssertMatches(matcher, null);

            // Then - No Exception
        }

        [Fact]
        public void NotNullValue_IsNull_False()
        {
            // Given
            IMatcher<object> matcher = IsNull<object>();

            // When
            TestHelper.AssertDoesNotMatch(matcher, new object());

            // Then - No Exception
        }

        [Fact]
        public void NullValue_IsNotNull_False()
        {
            // Given
            IMatcher<object> matcher = IsNotNull<object>();

            // When
            TestHelper.AssertDoesNotMatch(matcher, null);

            // Then - No Exception
        }

        [Fact]
        public void NotNullValue_IsNotNull_True()
        {
            // Given
            IMatcher<object> matcher = IsNotNull<object>();

            // When
            TestHelper.AssertMatches(matcher, new object());

            // Then - No Exception
        }
    }
}
