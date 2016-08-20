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
        public void NullValue_IsAnything_ReturnsTrue()
        {
            // Given
            Matcher<string> matcher = IsAnything<string>();

            // When
            TestHelper.AssertMatches(matcher, null);

            // Then - No Exception
        }

        [Fact]
        public void ObjectValue_IsAnything_ReturnsTrue()
        {
            // Given
            Matcher<string> matcher = IsAnything<string>();

            // When
            TestHelper.AssertMatches(matcher, new object());

            // Then - No Exception
        }

        [Fact]
        public void WhateverClassValue_IsAnything_ReturnsTrue()
        {
            // Given
            Matcher<string> matcher = IsAnything<string>();

            // When
            TestHelper.AssertMatches(matcher, new Whatever());

            // Then - No Exception
        }

        [Fact]
        public void StringValue_IsAnything_ReturnsTrue()
        {
            // Given
            Matcher<string> matcher = IsAnything<string>();

            // When
            TestHelper.AssertMatches(matcher, "stringValue");

            // Then - No Exception
        }

        [Fact]
        public void ObjectValueAndDescription_IsAnything_DescriptionMatchesNewDescriptioni()
        {
            // Given
            Matcher<string> matcher = IsAnything<string>("new description");

            // When
            TestHelper.AssertDescription("new description", matcher);

            // Then - No Exception
        }

        [Fact]
        public void ObjectValueAndDefaultDescription_IsAnything_DescriptioniIsANYTHINGText()
        {
            // Given
            Matcher<string> matcher = IsAnything<string>();

            // When
            TestHelper.AssertDescription("ANYTHING", matcher);

            // Then - No Exception
        }
    }
}
