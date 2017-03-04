using System.Collections.Generic;
using JPopadak.CoreMatchers;
using JPopadak.CoreMatchers.Matchers;
using Xunit;
using static JPopadak.StandardMatchers.Matchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Collections
{
    public class IsEnumerableContainingInAnyOrderFacts
    {
        [Fact]
        public void NullValue_ContainsInAnyOrder1And2_IsNullSafe()
        {
            // Given
            IMatcher<object> matcher = ContainsInAnyOrder(1, 2);

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_ContainsInAnyOrder1And2_IsTypeSafe()
        {
            // Given
            IMatcher<object> matcher = ContainsInAnyOrder(1, 2);

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void NoItems_ContainsInAnyOrder1_ReturnsFalse()
        {
            // Given
            IMatcher<object> matcher = ContainsInAnyOrder(1);
            IEnumerable<int> actual = new List<int>();

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void SingleItemNumber1_ContainsInAnyOrder1_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = ContainsInAnyOrder(1);
            IEnumerable<int> actual = new List<int> { 1 };

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Number1And2And3InOrder_ContainsInAnyOrder1And2And3_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = ContainsInAnyOrder(1, 2, 3);
            IEnumerable<int> actual = new List<int> { 1, 2, 3 };

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Number3And2And1OutOfORder_ContainsInAnyOrder1And2And3_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = ContainsInAnyOrder(1, 2, 3);
            IEnumerable<int> actual = new List<int> { 3, 2, 1 };

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ContainsInAnyOrder1And2And3_HasReadableDescription()
        {
            // Given
            IMatcher<object> matcher = ContainsInAnyOrder(1, 2, 3);

            // When
            TestHelper.AssertDescription("IEnumerable with items [<1>, <2>, <3>] in any order", matcher);

            // Then - No Exception
        }

        [Fact]
        public void NoItems_ContainsInAnyOrder1And2And3_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<object> matcher = ContainsInAnyOrder(1, 2, 3);
            IEnumerable<int> actual = new List<int>();

            // When
            TestHelper.AssertMismatchDescription("no item matches: <1>, <2>, <3> in []", matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Number3And2And1OutOfOrder_ContainsInAnyOrder1And2And4_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<object> matcher = ContainsInAnyOrder(1, 2, 4);
            IEnumerable<int> actual = new List<int>{ 3, 2, 1 };

            // When
            TestHelper.AssertMismatchDescription("not matched: <3>", matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void MoreActualThanMatchers_Number4And3And2And1OutOfOrder_ContainsInAnyOrder1And2And3_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<object> matcher = ContainsInAnyOrder(1, 2, 3);
            IEnumerable<int> actual = new List<int>{ 4, 3, 2, 1 };

            // When
            TestHelper.AssertMismatchDescription("not matched: <4>", matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void MoreMatchersThanActuals_Number2And1OutOfOrder_ContainsInAnyOrder1And2And3_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<object> matcher = ContainsInAnyOrder(1, 2, 3);
            IEnumerable<int> actual = new List<int>{ 4, 3, 2, 1 };

            // When
            TestHelper.AssertMismatchDescription("not matched: <4>", matcher, actual);

            // Then - No Exception
        }
    }
}