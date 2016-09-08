using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Matcher matcher = Anything();

            // When
            TestHelper.AssertMatches(matcher, null);

            // Then - No Exception
        }

        [Fact]
        public void ObjectValue_Anything_ReturnsTrue()
        {
            // Given
            Matcher matcher = Anything();

            // When
            TestHelper.AssertMatches(matcher, new object());

            // Then - No Exception
        }

        [Fact]
        public void WhateverClassValue_Anything_ReturnsTrue()
        {
            // Given
            Matcher matcher = Anything();

            // When
            TestHelper.AssertMatches(matcher, new Whatever());

            // Then - No Exception
        }

        [Fact]
        public void StringValue_Anything_ReturnsTrue()
        {
            // Given
            Matcher matcher = Anything();

            // When
            TestHelper.AssertMatches(matcher, "stringValue");

            // Then - No Exception
        }

        [Fact]
        public void ObjectValueAndDescription_Anything_DescriptionMatchesNewDescriptioni()
        {
            // Given
            Matcher matcher = Anything("new description");

            // When
            TestHelper.AssertDescription("new description", matcher);

            // Then - No Exception
        }

        [Fact]
        public void ObjectValueAndDefaultDescription_Anything_DescriptioniIsANYTHINGText()
        {
            // Given
            Matcher matcher = Anything();

            // When
            TestHelper.AssertDescription("ANYTHING", matcher);

            // Then - No Exception
        }
    }
}
