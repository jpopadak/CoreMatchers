using System.Collections.Generic;
using Xunit;
using static JPopadak.StandardMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsEmptyEnumerableFacts
    {
        [Fact]
        public void NullValue_EmptyEnumerable_IsNullSafe()
        {
            // Given
            IMatcher<object> matcher = EmptyEnumerable<object>();

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_EmptyEnumerable_IsTypeSafe()
        {
            // Given
            IMatcher<object> matcher = EmptyEnumerable<object>();

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void EmptyCollection_EmptyEnumerable_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = EmptyEnumerable<object>();

            // When
            TestHelper.AssertMatches(matcher, emptyList());

            // Then - No Exception
        }

        [Fact]
        public void CollectionWithItems_EmptyEnumerable_ReturnsFalse()
        {
            // Given
            IMatcher<object> matcher = EmptyEnumerable<object>();

            // When
            TestHelper.AssertDoesNotMatch(matcher, populatedList());

            // Then - No Exception
        }

        [Fact]
        public void EmptyEnumerable_ReturnsDescriptionWithSameInstanceWithString()
        {
            // Given
            IMatcher<object> matcher = EmptyEnumerable<object>();

            // When
            TestHelper.AssertDescription("an empty IEnumerable", matcher);

            // Then - No Exception
        }

        [Fact]
        public void StringType_EmptyEnumerable_CompilesSuccessfullyWithSpecificType()
        {
            // Given / When / Then
            IMatcher<IEnumerable<string>> matcher = EmptyEnumerable<string>();
        }

        private List<object> emptyList()
        {
            return new List<object>();
        }

        private List<object> populatedList()
        {
            return new List<object> {
                new object(),
                new object(),
                new object(),
                new object(),
                new object()
            };
        }
    }
}
