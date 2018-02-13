using JPopadak.CoreMatchers;
using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;
using static JPopadak.StandardMatchers.Matchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Collections
{
    public class IsArrayFacts
    {
        [Fact]
        public void NullValue_ArrayEqualTo_IsNullSafe()
        {
            // Given
            IMatcher<string[]> matcher = Array(EqualTo("a"), EqualTo("b"), EqualTo("c"), EqualTo("d"));

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_ArrayEqualTo_IsTypeSafe()
        {
            // Given
            IMatcher<string[]> matcher = Array(EqualTo("a"), EqualTo("b"), EqualTo("c"), EqualTo("d"));

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void ExactValuesAsMatcherValues_ArrayEqualTo_ReturnsTrue()
        {
            // Given
            IMatcher<string[]> matcher = Array(EqualTo("a"), EqualTo("b"), EqualTo("c"));
            string[] values = {"a", "b", "c"};

            // When
            TestHelper.AssertMatches(matcher, values);

            // Then - No Exception
        }

        [Fact]
        public void DifferentSecondEqualToValues_ArrayEqualTo_ReturnsFalse()
        {
            // Given
            IMatcher<string[]> matcher = Array(EqualTo("a"), EqualTo("b"), EqualTo("c"));
            string[] values = {"a", "c", "c"};

            // When
            TestHelper.AssertDoesNotMatch(matcher, values);

            // Then - No Exception
        }

        [Fact]
        public void SmallerSizedValueArray_ArrayEqualTo_ReturnsFalse()
        {
            // Given
            IMatcher<string[]> matcher = Array(EqualTo("a"), EqualTo("b"), EqualTo("c"));
            string[] values = {"a", "b"};

            // When
            TestHelper.AssertDoesNotMatch(matcher, values);

            // Then - No Exception
        }

        [Fact]
        public void LargerSizedValueArray_ArrayEqualTo_ReturnsFalse()
        {
            // Given
            IMatcher<string[]> matcher = Array(EqualTo("a"), EqualTo("b"), EqualTo("c"));
            string[] values = {"a", "b", "c", "d"};

            // When
            TestHelper.AssertDoesNotMatch(matcher, values);

            // Then - No Exception
        }

        [Fact]
        public void SmallerSizedMatcherArray_ArrayEqualTo_ReturnsFalse()
        {
            // Given
            IMatcher<string[]> matcher = Array(EqualTo("a"), EqualTo("b"));
            string[] values = {"a", "b", "c"};

            // When
            TestHelper.AssertDoesNotMatch(matcher, values);

            // Then - No Exception
        }

        [Fact]
        public void LargerSizedMatcherArray_ArrayEqualTo_ReturnsFalse()
        {
            // Given
            IMatcher<string[]> matcher = Array(EqualTo("a"), EqualTo("b"), EqualTo("c"), EqualTo("d"));
            string[] values = {"a", "b", "c"};

            // When
            TestHelper.AssertDoesNotMatch(matcher, values);

            // Then - No Exception
        }

        [Fact]
        public void ArrayEqualToAEqualToB_ArrayEqualTo_HasReadableDescription()
        {
            // Given
            IMatcher<string[]> matcher = Array(EqualTo("a"), EqualTo("b"));

            // When
            TestHelper.AssertDescription("[\"a\", \"b\"]", matcher);

            // Then - No Exception
        }

        [Fact]
        public void ArrayEqualToAEqualToB_ArrayEqualTo_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<string[]> matcher = Array(EqualTo("a"), EqualTo("b"));
            string[] actual = {"a", "c"};

            // When
            TestHelper.AssertMismatchDescription("element <1> was \"c\"", matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void CustomMatcher_ArrayEqualTo_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<object> matcher = Array(new CustomMatcher(), EqualTo("a"));
            string[] actual = {"a", "c"};

            // When
            TestHelper.AssertMismatchDescription("element <0> didn't match", matcher, actual);

            // Then - No Exception
        }

        private class CustomMatcher : Matcher<string>
        {
            public override bool Matches(object item) { return false; }

            public override void Describe(IDescription description) { description.AppendText("c"); }

            public override void DescribeMismatch(object item, IDescription description)
            {
                description.AppendText("didn't match");
            }
        };
    }
}
