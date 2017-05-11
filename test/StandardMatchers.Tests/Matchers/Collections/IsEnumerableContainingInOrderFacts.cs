using System.Collections.Generic;
using JPopadak.CoreMatchers;
using JPopadak.CoreMatchers.Matchers;
using Xunit;
using static JPopadak.StandardMatchers.Matchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Collections
{
    public class IsEnumerableContainingInOrderFacts
    {
        [Fact]
        public void NullValue_ContainsInOrder1And2_IsNullSafe()
        {
            // Given
            IMatcher<object> matcher = ContainsInOrder(1, 2);

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_ContainsInOrder1And2_IsTypeSafe()
        {
            // Given
            IMatcher<object> matcher = ContainsInOrder(1, 2);

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void Number1And2And3_ContainsInOrder1And2And3_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = ContainsInOrder(1, 2, 3);
            IEnumerable<int> actual = new List<int> { 1, 2, 3 };

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Number1AndNullAnd3_ContainsInOrder1AndNullAnd3_ReturnsTrueAndCanHandleNullsInArray()
        {
            // Given
            IMatcher<object> matcher = ContainsInOrder<int?>(1, null, 3);
            IEnumerable<int?> actual = new List<int?> { 1, null, 3 };

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void SingleNumber1_ContainsInOrder1_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = ContainsInOrder(1);
            IEnumerable<int> actual = new List<int> { 1 };

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void NullActual_ContainsInOrder1And2And3_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<object> matcher = ContainsInOrder(1, 2, 3);
            IEnumerable<int> actual = null;

            // When
            TestHelper.AssertMismatchDescription("was null", matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void NoItemMatching1_ContainsInOrder1And2And3_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<object> matcher = ContainsInOrder(1, 2, 3);
            IEnumerable<int> actual = new List<int>();

            // When
            TestHelper.AssertMismatchDescription("no item was <1>", matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void NoItemMatching2_ContainsInOrder1And2And3_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<object> matcher = ContainsInOrder(1, 2, 3);
            IEnumerable<int> actual = new List<int> { 1 };

            // When
            TestHelper.AssertMismatchDescription("no item was <2>", matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void FirstItemIs4_ContainsInOrder1And2And3_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<object> matcher = ContainsInOrder(1, 2, 3);
            IEnumerable<int> actual = new List<int> { 4, 3, 2, 1 };

            // When
            TestHelper.AssertMismatchDescription("item 0: was <4>", matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ThirdItemIs4_ContainsInOrder1And2And3_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<object> matcher = ContainsInOrder(1, 2, 3);
            IEnumerable<int> actual = new List<int> { 1, 2, 4 };

            // When
            TestHelper.AssertMismatchDescription("item 2: was <4>", matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Number1And2_ContainsInOrder_HasReadableDescription()
        {
            // Given
            IMatcher<object> matcher = ContainsInOrder(1, 2);

            // When
            TestHelper.AssertDescription("IEnumerable containing [<1>, <2>]", matcher);

            // Then - No Exception
        }
    }
}