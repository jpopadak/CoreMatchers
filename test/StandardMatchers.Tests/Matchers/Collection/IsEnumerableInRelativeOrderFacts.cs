using System.Collections.Generic;
using JPopadak.CoreMatchers;
using JPopadak.CoreMatchers.Matchers;
using Xunit;
using static JPopadak.StandardMatchers.Matchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Collections
{
    public class IsEnumerableInRelativeOrderFacts
    {
        [Fact]
        public void NullValue_ContainsInRelativeOrder1And2_IsNullSafe()
        {
            // Given
            IMatcher<object> matcher = ContainsInRelativeOrder(1, 2);

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_ContainsInRelativeOrder1And2_IsTypeSafe()
        {
            // Given
            IMatcher<object> matcher = ContainsInRelativeOrder(1, 2);

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void SingleItem_ContainsInRelativeOrder_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = ContainsInRelativeOrder(1);
            IEnumerable<int> actual = new List<int> { 1 };

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void MultipleItems_ContainsInRelativeOrder_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = ContainsInRelativeOrder(1, 2, 3);
            IEnumerable<int> actual = new List<int> { 1, 2, 3 };

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void MoreElementsAtBeginning_ContainsInRelitiveOrder_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = ContainsInRelativeOrder(2, 3, 4);
            IEnumerable<int> actual = new List<int> { 1, 2, 3, 4 };

            // When
            TestHelper.AssertMatches(matcher, actual);
            
            // Then - No Exception
        }

        [Fact]
        public void MoreElementsAtEnd_ContainsInRelitiveOrder_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = ContainsInRelativeOrder(1, 2, 3);
            IEnumerable<int> actual = new List<int> { 1, 2, 3, 4 };

            // When
            TestHelper.AssertMatches(matcher, actual);
            
            // Then - No Exception
        }

        [Fact]
        public void MoreElementsInBetween_ContainsInRelitiveOrder_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = ContainsInRelativeOrder(1, 3);
            IEnumerable<int> actual = new List<int> { 1, 2, 3 };

            // When
            TestHelper.AssertMatches(matcher, actual);
            
            // Then - No Exception
        }

        [Fact]
        public void SubSection_ContainsInRelitiveOrder_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = ContainsInRelativeOrder(2, 3);
            IEnumerable<int> actual = new List<int> { 1, 2, 3, 4 };

            // When
            TestHelper.AssertMatches(matcher, actual);
            
            // Then - No Exception
        }

        [Fact]
        public void SingleGapAndNotFirstOrLast_ContainsInRelitiveOrder_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = ContainsInRelativeOrder(2, 4);
            IEnumerable<int> actual = new List<int> { 1, 2, 3, 4, 5 };

            // When
            TestHelper.AssertMatches(matcher, actual);
            
            // Then - No Exception
        }

        [Fact]
        public void SubSectionWithManyGaps_ContainsInRelitiveOrder_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = ContainsInRelativeOrder(2, 4, 6);
            IEnumerable<int> actual = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            // When
            TestHelper.AssertMatches(matcher, actual);
            
            // Then - No Exception
        }

        [Fact]
        public void FewerThanExpected_ContainsInRelitiveOrder_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<object> matcher = ContainsInRelativeOrder(1, 2, 3);
            IEnumerable<int> actual = new List<int> { 1, 2 };

            // When
            TestHelper.AssertMismatchDescription("<3> was not found after <2>", matcher, actual);
            
            // Then - No Exception
        }

        [Fact]
        public void SingleItemNotFound_ContainsInRelitiveOrder_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<object> matcher = ContainsInRelativeOrder(4);
            IEnumerable<int> actual = new List<int> { 3 };

            // When
            TestHelper.AssertMismatchDescription("<4> was not found", matcher, actual);
            
            // Then - No Exception
        }

        [Fact]
        public void OneOfMultipleNotFound_ContainsInRelitiveOrder_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<object> matcher = ContainsInRelativeOrder(1, 2, 3);
            IEnumerable<int> actual = new List<int> { 1, 2, 4 };

            // When
            TestHelper.AssertMismatchDescription("<3> was not found after <2>", matcher, actual);
            
            // Then - No Exception
        }

        [Fact]
        public void EmptyIterable_ContainsInRelitiveOrder_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<object> matcher = ContainsInRelativeOrder(4);
            IEnumerable<int> actual = new List<int>();

            // When
            TestHelper.AssertMismatchDescription("<4> was not found", matcher, actual);
            
            // Then - No Exception
        }

        [Fact]
        public void Number1And2_ContainsInRelitiveOrder_HasReadableDescription()
        {
            // Given
            IMatcher<object> matcher = ContainsInRelativeOrder(1, 2);

            // When
            TestHelper.AssertDescription("enumerable containing [<1>, <2>] in relative order", matcher);
            
            // Then - No Exception
        }
    }
}