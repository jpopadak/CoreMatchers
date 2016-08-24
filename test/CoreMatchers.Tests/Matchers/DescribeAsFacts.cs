using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class DescribeAsFacts
    {
        [Fact]
        public void NullValue_DescribeAs_IsNullSafe()
        {
            // Given
            string description = "description";
            Matcher<string> matcher = DescribeAs(description, Anything<string>());

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownType_DescribeAs_IsUnknownTypeSafe()
        {
            // Given
            string description = "description";
            Matcher<string> matcher = DescribeAs(description, Anything<string>());

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void DescriptionText_DecribeAs_OverridesMatchersDescription()
        {
            // Given
            string description = "description";
            Matcher<string> matcher = DescribeAs(description, Anything<string>());

            // When
            TestHelper.AssertDescription(description, matcher);

            // Then - No Exception
        }

        [Fact]
        public void DescriptionTextWithValues_DecribeAs_OverridesMatchersDescriptionWithValues()
        {
            // Given
            string description = "description {0} {1}";
            int value1 = 1234;
            string value2 = "value2";
            Matcher<string> matcher = DescribeAs(description, Anything<string>(), value1, value2);

            // When
            TestHelper.AssertDescription("description <" + value1  + "> \"" + value2 + "\"", matcher);

            // Then - No Exception
        }

        [Fact]
        public void DescribeAsWithEqualToWithExpectedIsActual_DecribeAs_EnsuresMatchingIsDoneByPassedInMatcherReturnsTrue()
        {
            // Given
            string description = "description";
            string expected = "hello";
            Matcher<string> matcher = DescribeAs(description, EqualTo(expected));

            // When
            TestHelper.AssertMatches(matcher, expected);

            // Then - No Exception
        }

        [Fact]
        public void DescribeAsWithEqualToWithExpectedDifferentThanActual_DecribeAs_EnsuresMatchingIsDoneByPassedInMatcherReturnsFalse()
        {
            // Given
            string description = "description";
            string expected = "hello";
            string actual = "hello NOPE";
            Matcher<string> matcher = DescribeAs(description, EqualTo(expected));

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void DescribeAsWithEqualToWithExpectedDifferentThanActual_DecribeAs_EnsuresMismatchDescriptionIsDoneByPassedInMatcher()
        {
            // Given
            string description = "description";
            string expected = "hello";
            string actual = "hello NOPE";
            Matcher<string> matcher = DescribeAs(description, EqualTo(expected));

            // When
            TestHelper.AssertMismatchDescription("was \"" + actual + "\"", matcher, actual);

            // Then - No Exception
        }
    }
}
