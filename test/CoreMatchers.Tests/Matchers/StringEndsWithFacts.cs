using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class StringEndsWithFacts
    {
        private const string EXCERPT = "EXCERPT";
        private const string EXCERPT_RANDOM_CASE = "ExCeRpT";

        [Fact]
        public void ExcerptWithAppendedEnd_EndsWith_ReturnsFalse()
        {
            // Given
            string actual = EXCERPT + "END";

            // When
            TestHelper.AssertDoesNotMatch(getStringEndsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptWithPrependedStart_EndsWith_ReturnsTrue()
        {
            // Given
            string actual = "START" + EXCERPT;

            // When
            TestHelper.AssertMatches(getStringEndsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptWithPrependedStartAndAppendedWithEnd_EndsWith_ReturnsFalse()
        {
            // Given
            string actual = "START" + EXCERPT + "END";

            // When
            TestHelper.AssertDoesNotMatch(getStringEndsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptAlone_EndsWith_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT;

            // When
            TestHelper.AssertMatches(getStringEndsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptAloneLowercase_EndsWith_ReturnsFalse()
        {
            // Given
            string actual = EXCERPT.ToLower();

            // When
            TestHelper.AssertDoesNotMatch(getStringEndsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptTwice_EndsWith_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT + EXCERPT;

            // When
            TestHelper.AssertMatches(getStringEndsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void Exc_EndsWith_ReturnsFalse()
        {
            // Given
            string actual = "EXC";

            // When
            TestHelper.AssertDoesNotMatch(getStringEndsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void Exc_EndsWith_MismatchDescriptionIncludesActual()
        {
            // Given
            string actual = "EXC";

            // When
            TestHelper.AssertMismatchDescription("was \"" + actual + "\"", getStringEndsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void Exc_EndsWith_DescriptionIncludesExpected()
        {
            // When
            TestHelper.AssertDescription("a string ending with \"" + EXCERPT + "\"", getStringEndsWithMatcher());

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingWithAppendedEnd_EndsWithIgnoringCase_ReturnsFalse()
        {
            // Given
            string actual = EXCERPT_RANDOM_CASE + "END";

            // When
            TestHelper.AssertDoesNotMatch(getIgnoreCaseStringEndsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingWithPrependedStart_EndsWithIgnoringCase_ReturnsTrue()
        {
            // Given
            string actual = "START" + EXCERPT_RANDOM_CASE;

            // When
            TestHelper.AssertMatches(getIgnoreCaseStringEndsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingWithPrependedStartAndAppendedWithEnd_EndsWithIgnoringCase_ReturnsFalse()
        {
            // Given
            string actual = "START" + EXCERPT_RANDOM_CASE + "END";

            // When
            TestHelper.AssertDoesNotMatch(getIgnoreCaseStringEndsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingAlone_EndsWithIgnoringCase_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT_RANDOM_CASE;

            // When
            TestHelper.AssertMatches(getIgnoreCaseStringEndsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingAloneLowercase_EndsWithIgnoringCase_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT_RANDOM_CASE.ToLower();

            // When
            TestHelper.AssertMatches(getIgnoreCaseStringEndsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingTwice_EndsWithIgnoringCase_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT_RANDOM_CASE + EXCERPT_RANDOM_CASE;

            // When
            TestHelper.AssertMatches(getIgnoreCaseStringEndsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void Exc_EndsWithIgnoringCase_MismatchDescriptionIncludesActual()
        {
            // Given
            string actual = "EXC";

            // When
            TestHelper.AssertMismatchDescription("was \"" + actual + "\"",
                getIgnoreCaseStringEndsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void Exc_EndsWithIgnoringCase_DescriptionIncludesExpected()
        {
            // When
            TestHelper.AssertDescription("a string ending with \"" + EXCERPT
                + "\" ignoring case", getIgnoreCaseStringEndsWithMatcher());

            // Then - No Exception
        }

        private Matcher<string> getStringEndsWithMatcher()
        {
            return EndsWith(EXCERPT);
        }

        private Matcher<string> getIgnoreCaseStringEndsWithMatcher()
        {
            return EndsWithIgnoringCase(EXCERPT);
        }
    }
}
