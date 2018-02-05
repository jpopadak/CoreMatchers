using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsEqualFacts
    {
        [Fact]
        public void NullValue_EqualTo_IsNullSafe()
        {
            // Given
            string actual = "actual";
            IMatcher<string> matcher = EqualTo(actual);

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_EqualTo_IsTypeSafe()
        {
            // Given
            string actual = "actual";
            IMatcher<string> matcher = EqualTo(actual);

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void ActualStringIsExpectedString_EqualTo_True()
        {
            // Given
            string actual = "actual";
            IMatcher<string> matcher = EqualTo(actual);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualStringIsDifferentThanExpectedString_EqualTo_False()
        {
            // Given
            string actual = "actual";
            string expected = "expected";
            IMatcher<string> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsNull_EqualTo_False()
        {
            // Given
            string actual = null;
            string expected = "expected";
            IMatcher<string> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIntIsExpectedInt_EqualTo_True()
        {
            // Given
            int actual = 1;
            IMatcher<int> matcher = EqualTo(actual);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIntIsDifferentThanExpectedInt_EqualTo_False()
        {
            // Given
            int actual = 1;
            int expected = -1;
            IMatcher<int> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIntIsNull_EqualTo_False()
        {
            // Given
            int? actual = null;
            int expected = 1;
            IMatcher<int> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsNullExpectedIsNull_EqualTo_True()
        {
            // Given
            int? actual = null;
            int? expected = null;
            IMatcher<int?> matcher = EqualTo(expected);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIntIsExpectedIsNull_EqualTo_False()
        {
            // Given
            int actual = 2;
            int? expected = null;
            IMatcher<int?> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualStringIsExpectedIsNull_EqualTo_False()
        {
            // Given
            string actual = "actual";
            int? expected = null;
            IMatcher<int?> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualStringArrayIsExpectedIsNull_EqualTo_False()
        {
            // Given
            string[] actual = { "actual1", "actual2", "actual3" };
            int? expected = null;
            IMatcher<int?> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsStringArrayExpectedIsSameInstanceOfStringArray_EqualTo_True()
        {
            // Given
            string[] actual = { "actual1", "actual2", "actual3" };
            IMatcher<string[]> matcher = EqualTo(actual);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsStringArrayExpectedIsStringArray_EqualTo_True()
        {
            // Given
            string[] actual = { "actual1", "actual2", "actual3" };
            string[] expected = { "actual1", "actual2", "actual3" };
            IMatcher<string[]> matcher = EqualTo(expected);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsStringArrayExpectedIsDifferentValuesInStringArray_EqualTo_False()
        {
            // Given
            string[] actual = { "actual1", "actual2", "actual3" };
            string[] expected = { "expected1", "expected2", "expected3" };
            IMatcher<string[]> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsStringArrayExpectedIsDifferentLengthForStringArray_EqualTo_False()
        {
            // Given
            string[] actual = { "actual1", "actual2", "actual3" };
            string[] expected = { "expected1" };
            IMatcher<string[]> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsNullExpectelIsStringArray_EqualTo_False()
        {
            // Given
            string[] actual = null;
            string[] expected = { "actual1", "actual2", "actual3" };
            IMatcher<string[]> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        //[Fact]
        [Fact]
        public void ActualIsStringArrayWithNullExpectedIsSameInstanceOfStringArray_EqualTo_True()
        {
            // Given
            string[] actual = { "actual1", null, "actual3" };
            IMatcher<string[]> matcher = EqualTo(actual);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsStringArrayWithNullExpectedIsStringArray_EqualTo_True()
        {
            // Given
            string[] actual = { "actual1", null, "actual3" };
            string[] expected = { "actual1", null, "actual3" };
            IMatcher<string[]> matcher = EqualTo(expected);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsStringArrayWithNullExpectedIsDifferentValuesInStringArray_EqualTo_False()
        {
            // Given
            string[] actual = { "actual1", null, "actual3" };
            string[] expected = { "expected1", "expected2", "expected3" };
            IMatcher<string[]> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsStringArrayWithNullExpectedIsDifferentLengthForStringArray_EqualTo_False()
        {
            // Given
            string[] actual = { "actual1", null, "actual3" };
            string[] expected = { "expected1" };
            IMatcher<string[]> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsNullExpectedIsStringArrayWithNull_EqualTo_False()
        {
            // Given
            string[] actual = null;
            string[] expected = { "actual1", null, "actual3" };
            IMatcher<string[]> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIntArrayIsExpectedIsNull_EqualTo_False()
        {
            // Given
            int[] actual = { 1, 2, 3 };
            int? expected = null;
            IMatcher<int?> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsIntArrayExpectedIsSameInstanceOfIntArray_EqualTo_True()
        {
            // Given
            int[] actual = { 1, 2, 3 };
            IMatcher<int[]> matcher = EqualTo(actual);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsIntArrayExpectedIsIntArray_EqualTo_True()
        {
            // Given
            int[] actual = { 1, 2, 3 };
            int[] expected = { 1, 2, 3 };
            IMatcher<int[]> matcher = EqualTo(expected);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsIntArrayExpectedIsDifferentValuesInIntArray_EqualTo_False()
        {
            // Given
            int[] actual = { 1, 2, 3 };
            int[] expected = { -1, -2, -3 };
            IMatcher<int[]> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsIntArrayExpectedIsDifferentLengthForIntArray_EqualTo_False()
        {
            // Given
            int[] actual = { 1, 2, 3 };
            int[] expected = { 1 };
            IMatcher<int[]> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIsNullExpectedIsIntArray_EqualTo_False()
        {
            // Given
            int[] actual = null;
            int[] expected = { 1, 2, 3 };
            IMatcher<int[]> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }
        
        [Fact]
        public void ActualAndExpectedIs3DimIntArray_EqualTo_True()
        {
            // Given
            int?[,,] actual = { { { 1, 2, 3 }, { 1, 2, 3 } }, { { 1, 2, 3 }, { 1, 2, 3 } } };
            int?[,,] expected = { { {  1, 2, 3 }, { 1, 2, 3 } }, { { 1, 2, 3 }, { 1, 2, 3 } } };
            IMatcher<int?[,,]> matcher = EqualTo(expected);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualAndExpectedIs3DimIntArrayWithNullAtEndOfExpected_EqualTo_False()
        {
            // Given
            int?[,,] actual = { { { 1, 2, 3 }, { 1, 2, 3 } }, { { 1, 2, 3 }, { 1, 2, 3 } } };
            int?[,,] expected = { { { 1, 2, 3 }, { 1, 2, 3 } }, { { 1, 2, 3 }, { 1, 2, null } } };
            IMatcher<int?[,,]> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualAndExpectedIs3DimIntArrayWithWrongValueAtEndOfExpected_EqualTo_False()
        {
            // Given
            int?[,,] actual = { { { 1, 2, 3 }, { 1, 2, 3 } }, { { 1, 2, 3 }, { 1, 2, 3 } } };
            int?[,,] expected = { { { 1, 2, 3 }, { 1, 2, 3 } }, { { 1, 2, 3 }, { 1, 2, 4 } } };
            IMatcher<int?[,,]> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualAndExpectedIs3DimIntArrayWithWrongLengthExpected_EqualTo_False()
        {
            // Given
            int?[,,] actual = { { { 1, 2, 3 }, { 1, 2, 3 } }, { { 1, 2, 3 }, { 1, 2, 3 } } };
            int?[,,] expected = { { { 1, 2, 3, 4 }, { 1, 2, 3, 4 } }, { { 1, 2, 3, 4 }, { 1, 2, 3, 4 } } };
            IMatcher<int?[,,]> matcher = EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }
    }
}
