using System.Collections.Generic;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class EveryFacts
    {
        private static readonly IMatcher<IEnumerable<string>> HAS_CHAR_A_MATCHER = EveryItem(Contains("a"));

        [Fact]
        public void NullValue_Every_IsNullSafe()
        {
            // When
            TestHelper.AssertNullSafe(HAS_CHAR_A_MATCHER);

            // Then - No Exception
        }

        [Fact]
        public void UnknownType_Every_IsUnknownTypeSafe()
        {
            // When
            TestHelper.AssertUnknownTypeSafe(HAS_CHAR_A_MATCHER);

            // Then - No Exception
        }

        [Fact]
        public void ValuesWithLowerCaseAInMiddle_Every_ReturnsTrue()
        {
            // Given
            string[] actual = { "AaA", "BaB", "CaC" };

            // When
            TestHelper.AssertMatches(HAS_CHAR_A_MATCHER, actual);

            // Then - No Exception
        }

        [Fact]
        public void TwoWithLowerCaseAInMiddleOneDoesNot_Every_ReturnsFalse()
        {
            // Given
            string[] actual = { "AaA", "BxB", "CaC" };

            // When
            TestHelper.AssertDoesNotMatch(HAS_CHAR_A_MATCHER, actual);

            // Then - No Exception
        }

        [Fact]
        public void EmptyList_Every_ReturnsTrue()
        {
            // Given
            string[] actual = { };

            // When
            TestHelper.AssertMatches(HAS_CHAR_A_MATCHER, actual);

            // Then - No Exception
        }

        [Fact]
        public void EveryItemContainsA_Every_DescribesItself()
        {
            // When
            TestHelper.AssertDescription("every item is a string containing \"a\"", HAS_CHAR_A_MATCHER);

            // Then - No Exception
        }

        [Fact]
        public void EveryItemContainsA_Every_DescribesMismatch()
        {
            // Given
            string[] actual = { "BxB" };

            // When
            TestHelper.AssertMismatchDescription("an item was \"BxB\"", HAS_CHAR_A_MATCHER, actual);

            // Then - No Exception
        }
    }
}
