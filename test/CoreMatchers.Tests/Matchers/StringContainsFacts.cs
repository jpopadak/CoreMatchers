using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class StringContainsFacts
    {
        private const string EXCERPT = "EXCERPT";
        private const string EXCERPT_RANDOM_CASE = "ExCeRpT";

        [Fact]
        public void ExcerptWithAppendedEnd_Contains_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT + "END";

            // When
            TestHelper.AssertMatches(getStringContainsMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptWithPrependedStart_Contains_ReturnsTrue()
        {
            // Given
            string actual = "START" + EXCERPT;

            // When
            TestHelper.AssertMatches(getStringContainsMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptWithPrependedStartAndAppendedWithEnd_Contains_ReturnsTrue()
        {
            // Given
            string actual = "START" + EXCERPT + "END";

            // When
            TestHelper.AssertMatches(getStringContainsMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptAlone_Contains_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT;

            // When
            TestHelper.AssertMatches(getStringContainsMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptAloneLowercase_Contains_ReturnsFalse()
        {
            // Given
            string actual = EXCERPT.ToLower();

            // When
            TestHelper.AssertDoesNotMatch(getStringContainsMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptTwice_Contains_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT + EXCERPT;

            // When
            TestHelper.AssertMatches(getStringContainsMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void Exc_Contains_ReturnsFalse()
        {
            // Given
            string actual = "EXC";

            // When
            TestHelper.AssertDoesNotMatch(getStringContainsMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void Exc_Contains_MismatchDescriptionIncludesActual()
        {
            // Given
            string actual = "EXC";

            // When
            TestHelper.AssertMismatchDescription("was \"" + actual + "\"", getStringContainsMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void Exc_Contains_DescriptionIncludesExpected()
        {
            // When
            TestHelper.AssertDescription("a string containing \"" + EXCERPT + "\"", getStringContainsMatcher());

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingWithAppendedEnd_ContainsIgnoringCase_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT_RANDOM_CASE + "END";

            // When
            TestHelper.AssertMatches(getIgnoreCaseStringContainsMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingWithPrependedStart_ContainsIgnoringCase_ReturnsTrue()
        {
            // Given
            string actual = "START" + EXCERPT_RANDOM_CASE;

            // When
            TestHelper.AssertMatches(getIgnoreCaseStringContainsMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingWithPrependedStartAndAppendedWithEnd_ContainsIgnoringCase_ReturnsTrue()
        {
            // Given
            string actual = "START" + EXCERPT_RANDOM_CASE + "END";

            // When
            TestHelper.AssertMatches(getIgnoreCaseStringContainsMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingAlone_ContainsIgnoringCase_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT_RANDOM_CASE;

            // When
            TestHelper.AssertMatches(getIgnoreCaseStringContainsMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingAloneLowercase_ContainsIgnoringCase_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT_RANDOM_CASE.ToLower();

            // When
            TestHelper.AssertMatches(getIgnoreCaseStringContainsMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ExcerptRandomCasingTwice_ContainsIgnoringCase_ReturnsTrue()
        {
            // Given
            string actual = EXCERPT_RANDOM_CASE + EXCERPT_RANDOM_CASE;

            // When
            TestHelper.AssertMatches(getIgnoreCaseStringContainsMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void Exc_ContainsIgnoringCase_MismatchDescriptionIncludesActual()
        {
            // Given
            string actual = "EXC";

            // When
            TestHelper.AssertMismatchDescription("was \"" + actual + "\"",
                getIgnoreCaseStringContainsMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void Exc_ContainsIgnoringCase_DescriptionIncludesExpected()
        {
            // When
            TestHelper.AssertDescription("a string containing \"" + EXCERPT
                + "\" ignoring case", getIgnoreCaseStringContainsMatcher());

            // Then - No Exception
        }

        private Matcher<string> getStringContainsMatcher()
        {
            return Contains(EXCERPT);
        }

        private Matcher<string> getIgnoreCaseStringContainsMatcher()
        {
            return ContainsIgnoringCase(EXCERPT);
        }
    }
}
