using System;
using JPopadak.CoreMatchers;
using JPopadak.CoreMatchers.Matchers;
using Xunit;
using static JPopadak.StandardMatchers.Matchers.Matchers;

namespace JPopadak.StandardMatchers.Tests.Matchers.Text
{
    public class StringContainsInOrderFacts
    {
        [Fact]
        public void NullValue_ContainsStringsInOrder_IsNullSafe()
        {
            // Given
            IMatcher<string> matcher = ContainsStringsInOrder("string1", "string2");

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_ContainsStringsInOrder_IsTypeSafe()
        {
            // Given
            IMatcher<string> matcher = ContainsStringsInOrder("string1", "string2");

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void NoStrings_ContainsStringsInOrder_ThrowsArgumentException()
        {
            // When
            Assert.Throws<ArgumentOutOfRangeException>(() => ContainsStringsInOrder());

            // Then - Throws ArgumentOutOfRangeException
        }

        [Fact]
        public void OneStrings_ContainsStringsInOrder_ThrowsArgumentException()
        {
            // When
            Assert.Throws<ArgumentOutOfRangeException>(() => ContainsStringsInOrder("string1"));

            // Then - Throws ArgumentOutOfRangeException
        }

        [Fact]
        public void NotEnoughStrings_ContainsStringsInOrder_ExceptionMessageSaysNotEnoughStrings()
        {
            // When
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => ContainsStringsInOrder());

            // Then - Throws ArgumentOutOfRangeException
            Assert.Contains("Must contain more than one. If not, use StringContains", ex.Message);
        }

        [Fact]
        public void ActualABCC_ExpectedA_B_C_C_ContainsStringsInOrder_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = ContainsStringsInOrder("A", "B", "C", "C");
            string actual = "ABCC";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Actual1A2B3C4C5_ExpectedA_B_C_C_ContainsStringsInOrder_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = ContainsStringsInOrder("A", "B", "C", "C");
            string actual = "1A2B3C4C5";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualABCæC_ExpectedA_B_æ_C_ContainsStringsInOrderWithCulture_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = ContainsStringsInOrder(true, "A", "B", "æ", "C");
            string actual = "ABCæC";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Actual1A2B3C4æC5_ExpectedA_B_æ_C_ContainsStringsInOrderWithCulture_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = ContainsStringsInOrder(true, "A", "B", "æ", "C");
            string actual = "1A2B3C4æC5";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Actual1A2B3C4aeC5_ExpectedA_B_æ_C_ContainsStringsInOrderWithCulture_ReturnsTrue()
        {
            // Given
            IMatcher<string> matcher = ContainsStringsInOrder(true, "A", "B", "æ", "C");
            string actual = "1A2B3C4aeC5";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Actual1A2B3C4aeC5_ExpectedA_B_æ_C_WithCombinedLetter_ContainsStringsInOrder_ReturnsFalse()
        {
            // Given
            IMatcher<string> matcher = ContainsStringsInOrder("A", "B", "æ", "C");
            string actual = "1A2B3C4aeC5";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualHasOneInstance_ExpectedHasTwoInstances_ContainsStringsInOrder_ReturnsFalse()
        {
            // Given
            IMatcher<string> matcher = ContainsStringsInOrder("ABC", "ABC");
            string actual = "--------ABC-------";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualMissingLastInstance_ContainsStringsInOrder_ReturnsFalse()
        {
            // Given
            IMatcher<string> matcher = ContainsStringsInOrder("A", "B", "C", "C");
            string actual = "abc";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsOutOfOrder_ContainsStringsInOrder_ReturnsFalse()
        {
            // Given
            IMatcher<string> matcher = ContainsStringsInOrder("A", "B", "C", "C");
            string actual = "CABC";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualNotLongEnough_ContainsStringsInOrder_ReturnsFalse()
        {
            // Given
            IMatcher<string> matcher = ContainsStringsInOrder("A", "B", "C", "C");
            string actual = "ab";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsEmpty_ContainsStringsInOrder_ReturnsFalse()
        {
            // Given
            IMatcher<string> matcher = ContainsStringsInOrder("A", "B", "C", "C");
            string actual = string.Empty;

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ContainsStringsInOrder_ContainsStringsInOrder_HasReadableDescription()
        {
            // Given
            IMatcher<string> matcher = ContainsStringsInOrder("A", "B", "C", "C");

            // When
            TestHelper.AssertDescription("a string containing \"A\", \"B\", \"C\", \"C\" in order", matcher);

            // Then - No Exception
        }

        [Fact]
        public void ContainsStringsInOrder_ContainsStringsInOrderWithCulture_HasReadableDescription()
        {
            // Given
            IMatcher<string> matcher = ContainsStringsInOrder(true, "A", "B", "C", "æ", "C");

            // When
            TestHelper.AssertDescription("a string containing with current culture \"A\", \"B\", \"C\", \"æ\", \"C\" in order", matcher);

            // Then - No Exception
        }

        [Fact]
        public void ContainsStringsInOrder_ContainsStringsInOrder_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<string> matcher = ContainsStringsInOrder("A", "B", "C", "C");
            string actual = "abc";

            // When
            TestHelper.AssertMismatchDescription("was \"abc\"", matcher, actual);

            // Then - No Exception
        }
    }
}