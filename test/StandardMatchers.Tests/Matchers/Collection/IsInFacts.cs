using System.Collections.Generic;
using JPopadak.CoreMatchers;
using JPopadak.CoreMatchers.Matchers;
using Xunit;
using static JPopadak.StandardMatchers.Matchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Collections
{
    public class IsInFacts
    {
        private static readonly string[] _elements = {"a", "b", "c"};
        private static readonly ICollection<string> _collection = new List<string>(_elements);

        [Fact]
        public void NullValueInArray_IsIn_IsNullSafe()
        {
            // Given
            IMatcher<object> matcher = IsIn(_elements);

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValueInArray_IsIn_IsTypeSafe()
        {
            // Given
            IMatcher<object> matcher = IsIn(_elements);

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }
        
        [Fact]
        public void NullValueInCollection_IsIn_IsNullSafe()
        {
            // Given
            IMatcher<object> matcher = IsIn(_collection);

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValueInCollection_IsIn_IsTypeSafe()
        {
            // Given
            IMatcher<object> matcher = IsIn(_collection);

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void LetterAInArray_IsIn_Matches()
        {
            // Given
            IMatcher<object> matcher = IsIn(_elements);
            string actual = "a";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void LetterBInArray_IsIn_Matches()
        {
            // Given
            IMatcher<object> matcher = IsIn(_elements);
            string actual = "b";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void LetterCInArray_IsIn_Matches()
        {
            // Given
            IMatcher<object> matcher = IsIn(_elements);
            string actual = "c";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }
        
        [Fact]
        public void LetterDInArray_IsIn_DoesNotMatch()
        {
            // Given
            IMatcher<object> matcher = IsIn(_elements);
            string actual = "d";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void LetterAInCollection_IsIn_Matches()
        {
            // Given
            IMatcher<object> matcher = IsIn(_collection);
            string actual = "a";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void LetterBInCollection_IsIn_Matches()
        {
            // Given
            IMatcher<object> matcher = IsIn(_collection);
            string actual = "b";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void LetterCInCollection_IsIn_Matches()
        {
            // Given
            IMatcher<object> matcher = IsIn(_collection);
            string actual = "c";

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }
        
        [Fact]
        public void LetterDInCollection_IsIn_DoesNotMatch()
        {
            // Given
            IMatcher<object> matcher = IsIn(_collection);
            string actual = "d";

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }
        
        [Fact]
        public void LetterD_IsIn_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<object> matcher = IsIn(_collection);
            string actual = "d";

            // When
            TestHelper.AssertMismatchDescription("was \"d\"", matcher, actual);

            // Then - No Exception
        }
        
        [Fact]
        public void Collection_IsIn_HasReadableDescription()
        {
            // Given
            IMatcher<object> matcher = IsIn(_collection);

            // When
            TestHelper.AssertDescription("one of {\"a\", \"b\", \"c\"}", matcher);

            // Then - No Exception
        }
    }
}