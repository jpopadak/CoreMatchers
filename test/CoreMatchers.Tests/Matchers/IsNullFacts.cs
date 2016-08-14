using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsNullFacts
    {
        [Fact]
        public void NullValue_IsNull_IsNullSafe()
        {
            // Given
            Matcher<string> matcher = Matchers.IsNull<string>();

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void NullValue_IsNotNull_IsNullSafe()
        {
            // Given
            Matcher<string> matcher = Matchers.IsNotNull<string>();

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_IsNull_IsTypeSafe()
        {
            // Given
            Matcher<string> matcher = Matchers.IsNull<string>();

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_IsNotNull_IsTypeSafe()
        {
            // Given
            Matcher<string> matcher = Matchers.IsNotNull<string>();

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void NullValue_IsNull_True()
        {
            // Given
            Matcher<string> matcher = Matchers.IsNull<string>();

            // When
            TestHelper.AssertMatches(matcher, null);

            // Then - No Exception
        }

        [Fact]
        public void NotNullValue_IsNull_False()
        {
            // Given
            Matcher<string> matcher = Matchers.IsNull<string>();

            // When
            TestHelper.AssertDoesNotMatch(matcher, new object());

            // Then - No Exception
        }

        [Fact]
        public void NullValue_IsNotNull_False()
        {
            // Given
            Matcher<string> matcher = Matchers.IsNotNull<string>();

            // When
            TestHelper.AssertDoesNotMatch(matcher, null);

            // Then - No Exception
        }

        [Fact]
        public void NotNullValue_IsNotNull_True()
        {
            // Given
            Matcher<string> matcher = Matchers.IsNotNull<string>();

            // When
            TestHelper.AssertMatches(matcher, new object());

            // Then - No Exception
        }
    }
}
