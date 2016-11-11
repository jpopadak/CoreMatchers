using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Matcher matcher = IsNull();

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void NullValue_IsNotNull_IsNullSafe()
        {
            // Given
            Matcher matcher = IsNotNull();

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_IsNull_IsTypeSafe()
        {
            // Given
            Matcher matcher = IsNull();

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_IsNotNull_IsTypeSafe()
        {
            // Given
            Matcher matcher = IsNotNull();

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void NullValue_IsNull_True()
        {
            // Given
            Matcher matcher = IsNull();

            // When
            TestHelper.AssertMatches(matcher, null);

            // Then - No Exception
        }

        [Fact]
        public void NotNullValue_IsNull_False()
        {
            // Given
            Matcher matcher = IsNull();

            // When
            TestHelper.AssertDoesNotMatch(matcher, new object());

            // Then - No Exception
        }

        [Fact]
        public void NullValue_IsNotNull_False()
        {
            // Given
            Matcher matcher = IsNotNull();

            // When
            TestHelper.AssertDoesNotMatch(matcher, null);

            // Then - No Exception
        }

        [Fact]
        public void NotNullValue_IsNotNull_True()
        {
            // Given
            Matcher matcher = IsNotNull();

            // When
            TestHelper.AssertMatches(matcher, new object());

            // Then - No Exception
        }
    }
}
