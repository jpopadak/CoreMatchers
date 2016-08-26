using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class StringRegularExpressionFacts
    {
        private const string PATTERN = "^[0-9]+$";

        [Fact]
        public void Number12_MatchesRegex_ReturnsTrue()
        {
            // Given
            string actual = "12";

            // When
            TestHelper.AssertMatches(getRegexMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void abc_MatchesRegex_ReturnsFalse()
        {
            // Given
            string actual = "abc";

            // When
            TestHelper.AssertDoesNotMatch(getRegexMatcher(), actual);

            // Then - No Exception
        }

        [Fact]
        public void ValidInput_MatchesRegex_DescriptionIncludesRegexUsed()
        {
            // When
            TestHelper.AssertDescription("a string matching the pattern <" + PATTERN + ">", getRegexMatcher());

            // Then - No Exception
        }

        [Fact]
        public void ValidInput_MatchesRegex_MismatchDescriptionIncludesActual()
        {
            // Given
            string actual = "asdf";

            // When
            TestHelper.AssertMismatchDescription("the string was \"" + actual + "\"", getRegexMatcher(), actual);

            // Then - No Exception
        }

        private Matcher<string> getRegexMatcher()
        {
            return MatchesRegex(PATTERN);
        }
    }
}
