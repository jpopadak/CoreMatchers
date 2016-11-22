using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsAnythingFacts
    {
        private class Whatever
        {
            // Do Nothing
        }

        [Fact]
        public void NullValue_Anything_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = Anything<object>();

            // When
            TestHelper.AssertMatches(matcher, null);

            // Then - No Exception
        }

        [Fact]
        public void ObjectValue_Anything_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = Anything<object>();

            // When
            TestHelper.AssertMatches(matcher, new object());

            // Then - No Exception
        }

        [Fact]
        public void WhateverClassValue_Anything_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = Anything<object>();

            // When
            TestHelper.AssertMatches(matcher, new Whatever());

            // Then - No Exception
        }

        [Fact]
        public void StringValue_Anything_ReturnsTrue()
        {
            // Given
            IMatcher<object> matcher = Anything<object>();

            // When
            TestHelper.AssertMatches(matcher, "stringValue");

            // Then - No Exception
        }

        [Fact]
        public void ObjectValueAndDescription_Anything_DescriptionMatchesNewDescriptioni()
        {
            // Given
            IMatcher<object> matcher = Anything<object>("new description");

            // When
            TestHelper.AssertDescription("new description", matcher);

            // Then - No Exception
        }

        [Fact]
        public void ObjectValueAndDefaultDescription_Anything_DescriptioniIsANYTHINGText()
        {
            // Given
            IMatcher<object> matcher = Anything<object>();

            // When
            TestHelper.AssertDescription("ANYTHING", matcher);

            // Then - No Exception
        }
    }
}
