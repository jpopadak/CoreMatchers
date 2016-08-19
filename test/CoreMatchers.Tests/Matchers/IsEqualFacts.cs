using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsEqualFacts
    {
        private const string DYNAMIC_TYPE_SKIP = "Cannot test until Issue is resolved: https://github.com/dotnet/roslyn/issues/12045";

        [Fact]
        public void NullValue_EqualTo_IsNullSafe()
        {
            // Given
            string actual = "actual";
            Matcher<string> matcher = Matchers.EqualTo(actual);

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_EqualTo_IsTypeSafe()
        {
            // Given
            string actual = "actual";
            Matcher<string> matcher = Matchers.EqualTo(actual);

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void ActualStringIsExpectedString_EqualTo_True()
        {
            // Given
            string actual = "actual";
            Matcher<string> matcher = Matchers.EqualTo(actual);

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
            Matcher<string> matcher = Matchers.EqualTo(expected);

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
            Matcher<string> matcher = Matchers.EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ActualIntIsExpectedInt_EqualTo_True()
        {
            // Given
            int actual = 1;
            Matcher<int> matcher = Matchers.EqualTo(actual);

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
            Matcher<int> matcher = Matchers.EqualTo(expected);

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
            Matcher<int> matcher = Matchers.EqualTo(expected);

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
            Matcher<object> matcher = Matchers.EqualTo<object>(expected);

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
            Matcher<object> matcher = Matchers.EqualTo<object>(expected);

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
            Matcher<object> matcher = Matchers.EqualTo<object>(expected);

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
            Matcher<object> matcher = Matchers.EqualTo<object>(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact(Skip = DYNAMIC_TYPE_SKIP)]
        public void ActualIsStringArrayExpectedIsSameInstanceOfStringArray_EqualTo_True()
        {
            // Given
            string[] actual = { "actual1", "actual2", "actual3" };
            Matcher<string[]> matcher = Matchers.EqualTo(actual);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact(Skip = DYNAMIC_TYPE_SKIP)]
        public void ActualIsStringArrayExpectedIsStringArray_EqualTo_True()
        {
            // Given
            string[] actual = { "actual1", "actual2", "actual3" };
            string[] expected = { "actual1", "actual2", "actual3" };
            Matcher<string[]> matcher = Matchers.EqualTo(expected);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact(Skip = DYNAMIC_TYPE_SKIP)]
        public void ActualIsStringArrayExpectedIsDifferentValuesInStringArray_EqualTo_False()
        {
            // Given
            string[] actual = { "actual1", "actual2", "actual3" };
            string[] expected = { "expected1", "expected2", "expected3" };
            Matcher<string[]> matcher = Matchers.EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact(Skip = DYNAMIC_TYPE_SKIP)]
        public void ActualIsStringArrayExpectedIsDifferentLengthForStringArray_EqualTo_False()
        {
            // Given
            string[] actual = { "actual1", "actual2", "actual3" };
            string[] expected = { "expected1" };
            Matcher<string[]> matcher = Matchers.EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact(Skip = DYNAMIC_TYPE_SKIP)]
        public void ActualIsNullExpectelIsStringArray_EqualTo_False()
        {
            // Given
            string[] actual = null;
            string[] expected = { "actual1", "actual2", "actual3" };
            Matcher<string[]> matcher = Matchers.EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact(Skip = DYNAMIC_TYPE_SKIP)]
        public void ActualIsStringArrayWithNullExpectedIsSameInstanceOfStringArray_EqualTo_True()
        {
            // Given
            string[] actual = { "actual1", null, "actual3" };
            Matcher<string[]> matcher = Matchers.EqualTo(actual);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact(Skip = DYNAMIC_TYPE_SKIP)]
        public void ActualIsStringArrayWithNullExpectedIsStringArray_EqualTo_True()
        {
            // Given
            string[] actual = { "actual1", null, "actual3" };
            string[] expected = { "actual1", null, "actual3" };
            Matcher<string[]> matcher = Matchers.EqualTo(expected);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact(Skip = DYNAMIC_TYPE_SKIP)]
        public void ActualIsStringArrayWithNullExpectedIsDifferentValuesInStringArray_EqualTo_False()
        {
            // Given
            string[] actual = { "actual1", null, "actual3" };
            string[] expected = { "expected1", "expected2", "expected3" };
            Matcher<string[]> matcher = Matchers.EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact(Skip = DYNAMIC_TYPE_SKIP)]
        public void ActualIsStringArrayWithNullExpectedIsDifferentLengthForStringArray_EqualTo_False()
        {
            // Given
            string[] actual = { "actual1", null, "actual3" };
            string[] expected = { "expected1" };
            Matcher<string[]> matcher = Matchers.EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact(Skip = DYNAMIC_TYPE_SKIP)]
        public void ActualIsNullExpectedIsStringArrayWithNull_EqualTo_False()
        {
            // Given
            string[] actual = null;
            string[] expected = { "actual1", null, "actual3" };
            Matcher<string[]> matcher = Matchers.EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact(Skip = DYNAMIC_TYPE_SKIP)]
        public void ActualIntArrayIsExpectedIsNull_EqualTo_False()
        {
            // Given
            int[] actual = { 1, 2, 3 };
            int? expected = null;
            Matcher<object> matcher = Matchers.EqualTo<object>(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact(Skip = DYNAMIC_TYPE_SKIP)]
        public void ActualIsIntArrayExpectedIsSameInstanceOfIntArray_EqualTo_True()
        {
            // Given
            int[] actual = { 1, 2, 3 };
            Matcher<int[]> matcher = Matchers.EqualTo(actual);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact(Skip = DYNAMIC_TYPE_SKIP)]
        public void ActualIsIntArrayExpectedIsIntArray_EqualTo_True()
        {
            // Given
            int[] actual = { 1, 2, 3 };
            int[] expected = { 1, 2, 3 };
            Matcher<int[]> matcher = Matchers.EqualTo(expected);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact(Skip = DYNAMIC_TYPE_SKIP)]
        public void ActualIsIntArrayExpectedIsDifferentValuesInIntArray_EqualTo_False()
        {
            // Given
            int[] actual = { 1, 2, 3 };
            int[] expected = { -1, -2, -3 };
            Matcher<int[]> matcher = Matchers.EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact(Skip = DYNAMIC_TYPE_SKIP)]
        public void ActualIsIntArrayExpectedIsDifferentLengthForIntArray_EqualTo_False()
        {
            // Given
            int[] actual = { 1, 2, 3 };
            int[] expected = { 1 };
            Matcher<int[]> matcher = Matchers.EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact(Skip = DYNAMIC_TYPE_SKIP)]
        public void ActualIsNullExpectedIsIntArray_EqualTo_False()
        {
            // Given
            int[] actual = null;
            int[] expected = { 1, 2, 3 };
            Matcher<int[]> matcher = Matchers.EqualTo(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }
    }
}
