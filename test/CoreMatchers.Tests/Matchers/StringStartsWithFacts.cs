using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class StringStartsWithFacts
    {
        private const string EXCERPT = "EXCERPT";
        private const string EXCERPT_RANDOM_CASE = "ExCeRpT";

        [Fact]
        public void ExcerptWithAppendedEnd_StartsWith_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT + "END";

            // When
            TestHelper.AssertMatches(getStringStartsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptWithPrependedStart_StartsWith_ReturnsFalse()
        {
            // Given
            string actual = "START" + EXCERPT;

            // When
            TestHelper.AssertDoesNotMatch(getStringStartsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptWithPrependedStartAndAppendedWithEnd_StartsWith_ReturnsFalse()
        {
            // Given
            string actual = "START" + EXCERPT + "END";

            // When
            TestHelper.AssertDoesNotMatch(getStringStartsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptAlone_StartsWith_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT;

            // When
            TestHelper.AssertMatches(getStringStartsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptAloneLowercase_StartsWith_ReturnsFalse()
        {
            // Given
            string actual = EXCERPT.ToLower();

            // When
            TestHelper.AssertDoesNotMatch(getStringStartsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptTwice_StartsWith_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT + EXCERPT;

            // When
            TestHelper.AssertMatches(getStringStartsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void Exc_StartsWith_ReturnsFalse()
        {
            // Given
            string actual = "EXC";

            // When
            TestHelper.AssertDoesNotMatch(getStringStartsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void Exc_StartsWith_MismatchDescriptionIncludesActual()
        {
            // Given
            string actual = "EXC";

            // When
            TestHelper.AssertMismatchDescription("was \"" + actual + "\"", getStringStartsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void Exc_StartsWith_DescriptionIncludesExpected()
        {
            // When
            TestHelper.AssertDescription("a string starting with \"" + EXCERPT + "\"", getStringStartsWithMatcher());

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingWithAppendedEnd_StartsWithIgnoringCase_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT_RANDOM_CASE + "END";

            // When
            TestHelper.AssertMatches(getIgnoreCaseStringStartsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingWithPrependedStart_StartsWithIgnoringCase_ReturnsFalse()
        {
            // Given
            string actual = "START" + EXCERPT_RANDOM_CASE;

            // When
            TestHelper.AssertDoesNotMatch(getIgnoreCaseStringStartsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingWithPrependedStartAndAppendedWithEnd_StartsWithIgnoringCase_ReturnsFalse()
        {
            // Given
            string actual = "START" + EXCERPT_RANDOM_CASE + "END";

            // When
            TestHelper.AssertDoesNotMatch(getIgnoreCaseStringStartsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingAlone_StartsWithIgnoringCase_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT_RANDOM_CASE;

            // When
            TestHelper.AssertMatches(getIgnoreCaseStringStartsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingAloneLowercase_StartsWithIgnoringCase_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT_RANDOM_CASE.ToLower();

            // When
            TestHelper.AssertMatches(getIgnoreCaseStringStartsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingTwice_StartsWithIgnoringCase_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT_RANDOM_CASE + EXCERPT_RANDOM_CASE;

            // When
            TestHelper.AssertMatches(getIgnoreCaseStringStartsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void Exc_StartsWithIgnoringCase_MismatchDescriptionIncludesActual()
        {
            // Given
            string actual = "EXC";

            // When
            TestHelper.AssertMismatchDescription("was \"" + actual + "\"",
                getIgnoreCaseStringStartsWithMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void Exc_StartsWithIgnoringCase_DescriptionIncludesExpected()
        {
            // When
            TestHelper.AssertDescription("a string starting with \"" + EXCERPT
                + "\" ignoring case", getIgnoreCaseStringStartsWithMatcher());

            // Then - No Exception
        }

        [Fact]
        public void NullSubString_StartsWith_ThrowsEx()
        {
            // Given
            string expected = null;

            // When
            Xunit.Assert.Throws<ArgumentNullException>(() => StartsWith(expected));

            // Then - Throws verifies throws ArugmentNullException
        }

        [Fact]
        public void NullSubString_StartsWithIgnoringCase_ThrowsEx()
        {
            // Given
            string expected = null;

            // When
            Xunit.Assert.Throws<ArgumentNullException>(() => StartsWithIgnoringCase(expected));

            // Then - Throws verifies throws ArugmentNullException
        }

        private Matcher<string> getStringStartsWithMatcher()
        {
            return StartsWith(EXCERPT);
        }

        private Matcher<string> getIgnoreCaseStringStartsWithMatcher()
        {
            return StartsWithIgnoringCase(EXCERPT);
        }
    }
}