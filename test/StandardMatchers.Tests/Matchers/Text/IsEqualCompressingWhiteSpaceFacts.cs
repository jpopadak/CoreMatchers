using System;
using System.Collections.Generic;
using JPopadak.CoreMatchers;
using JPopadak.CoreMatchers.Matchers;
using Xunit;
using static JPopadak.StandardMatchers.Matchers.Matchers;

namespace JPopadak.StandardMatchers.Tests.Matchers.Text
{
    public class IsEqualCompressingWhitespaceFacts
    {
        [Fact]
        public void NullValue_EqualToCompressingWhiteSpace_IsNullSafe()
        {
            // Given
            IMatcher<IEnumerable<char>> matcher = CreateMatcher();

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_EqualToCompressingWhiteSpace_IsTypeSafe()
        {
            // Given
            IMatcher<IEnumerable<char>> matcher = CreateMatcher();

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void WordsAreSimilarButSpacesInDifferentSpots_EqualToCompressingWhiteSpace_ReturnsTrue()
        {
            // Given
            IMatcher<IEnumerable<char>> matcher = CreateMatcher();
            string actual = "Hello     World how    \nare   we? ";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void WordsAreSimilarButSpacesAndTabsInDifferentSpots_EqualToCompressingWhiteSpace_ReturnsTrue()
        {
            // Given
            IMatcher<IEnumerable<char>> matcher = CreateMatcher();
            string actual = "   Hello World   how are \n\n\twe?";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void HasDifferentCasing_EqualToCompressingWhiteSpace_ReturnsFalse()
        {
            // Given
            IMatcher<IEnumerable<char>> matcher = CreateMatcher();
            string actual = "   Hello WORLD   how are \n\n\twe?";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void MissingQuestionMark_EqualToCompressingWhiteSpace_ReturnsFalse()
        {
            // Given
            IMatcher<IEnumerable<char>> matcher = CreateMatcher();
            string actual = "   Hello World   how are \n\n\twe";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void AddedSpaceInHello_EqualToCompressingWhiteSpace_ReturnsFalse()
        {
            // Given
            IMatcher<IEnumerable<char>> matcher = CreateMatcher();
            string actual = "   Hel lo World   how are \n\n\twe?";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void NoSpaceBetweenHelloAndWorld_EqualToCompressingWhiteSpace_ReturnsFalse()
        {
            // Given
            IMatcher<IEnumerable<char>> matcher = CreateMatcher();
            string actual = "   HelloWorld   how are \n\n\twe?";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void NullExpected_EqualToCompressingWhiteSpace_ThrowsArgumentNullException()
        {
            // When
            Assert.Throws<ArgumentNullException>(() => EqualToCompressingWhiteSpace(null));

            // Then - Throws ArgumentNullException
        }

        [Fact]
        public void NullExpected_EqualToCompressingWhiteSpace_ExceptionMessageHasCannotBeNullValue()
        {
            // When
            var ex = Assert.Throws<ArgumentNullException>(() => EqualToCompressingWhiteSpace(null));

            // Then - Throws ArgumentNullException
            Assert.Contains("Cannot be null", ex.Message);
        }

        [Fact]
        public void EqualToCompressingWhitespace_EqualToCompressingWhiteSpace_HasReadableDescription()
        {
            // Given
            IMatcher<IEnumerable<char>> matcher = CreateMatcher();

            // When
            TestHelper.AssertDescription("a string \" Hello World   how\\n are we? \" compressing white space to \"Hello World how are we?\"", matcher);

            // Then - No Exception
        }

        [Fact]
        public void EqualToCompressingWhitespace_EqualToCompressingWhiteSpace_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<IEnumerable<char>> matcher = CreateMatcher();
            string actual = "Hello World how are we ";

            // When
            TestHelper.AssertMismatchDescription("was \"Hello World how are we \" compressing white space to \"Hello World how are we\"", matcher, actual);

            // Then - No Exception
        }

        private static IMatcher<IEnumerable<char>> CreateMatcher()
        {
            return EqualToCompressingWhiteSpace(" Hello World   how\n are we? ");
        }
    }
}