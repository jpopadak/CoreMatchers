using System.Collections.Generic;
using JPopadak.CoreMatchers;
using JPopadak.CoreMatchers.Matchers;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;
using static JPopadak.StandardMatchers.Matchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Collections
{
    public class IsArrayWithSizeFacts
    {
        [Fact]
        public void NullValue_ArrayWithSize_IsNullSafe()
        {
            // Given
            IMatcher<object[]> matcher = ArrayWithSize<object>(EqualTo(2));

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_ArrayWithSize_IsTypeSafe()
        {
            // Given
            IMatcher<object[]> matcher = ArrayWithSize<object>(EqualTo(1));

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void TwoItems_ArrayWithSizeEqualTo2_ReturnsTrue()
        {
            // Given
            IMatcher<object[]> matcher = ArrayWithSize<object>(EqualTo(2));
            object[] actual = {1, 2};

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void TwoItems_ArrayWithSizeEqualTo3_ReturnsFalse()
        {
            // Given
            IMatcher<object[]> matcher = ArrayWithSize<object>(EqualTo(3));
            object[] actual = {1, 2};

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void TwoItems_ArrayWithSize2_ReturnsTrue()
        {
            // Given
            IMatcher<object[]> matcher = ArrayWithSize<object>(2);
            object[] actual = {1, 2};

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void TwoItems_ArrayWithSize3_ReturnsFalse()
        {
            // Given
            IMatcher<object[]> matcher = ArrayWithSize<object>(3);
            object[] actual = {1, 2};

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void EmptyArray_EmptyArray_ReturnsTrue()
        {
            // Given
            IMatcher<object[]> matcher = EmptyArray<object>();
            object[] actual = {};

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void TwoItems_EmptyArray_ReturnsFalse()
        {
            // Given
            IMatcher<object[]> matcher = EmptyArray<object>();
            object[] actual = {1, 2};

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void SizeOfThree_ArrayWithSizeEqualTo3_HasReadableDescription()
        {
            // Given
            IMatcher<object[]> matcher = ArrayWithSize<object>(EqualTo(3));

            // When
            TestHelper.AssertDescription("an array with size <3>", matcher);

            // Then - No Exception
        }

        [Fact]
        public void EmptyArray_EmptyArray_HasReadableDescription()
        {
            // Given
            IMatcher<object[]> matcher = EmptyArray<object>();

            // When
            TestHelper.AssertDescription("an empty array", matcher);

            // Then - No Exception
        }
    }
}