using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsSameFacts
    {
        [Fact]
        public void NullValue_IsSameInstance_IsNullSafe()
        {
            // Given
            int expected = 5;
            Matcher<int> matcher = IsSameInstance(expected);

            // When
            TestHelper.AssertNullSafe(matcher);
            
            // Then - No Exception
        }

        [Fact]
        public void UnknownType_IsSameInstance_IsUnknownTypeSafe()
        {
            // Given
            int expected = 5;
            Matcher<int> matcher = IsSameInstance(expected);

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void ExpectedAndActualObject_IsSameInstance_ReturnsTrue()
        {
            // Given
            object expected = new object();
            Matcher<object> matcher = IsSameInstance(expected);

            // When
            TestHelper.AssertMatches(matcher, expected);

            // Then - No Exception
        }

        [Fact]
        public void ExpectedObjectAndNewActualObject_IsSameInstance_ReturnsFalse()
        {
            // Given
            object expected = new object();
            object actual = new object();
            Matcher<object> matcher = IsSameInstance(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ExpectedAndActualObject_TheInstance_ReturnsTrue()
        {
            // Given
            object expected = new object();
            Matcher<object> matcher = TheInstance(expected);

            // When
            TestHelper.AssertMatches(matcher, expected);

            // Then - No Exception
        }

        [Fact]
        public void ExpectedObjectAndNewActualObject_TheInstance_ReturnsFalse()
        {
            // Given
            object expected = new object();
            object actual = new object();
            Matcher<object> matcher = TheInstance(expected);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ExpectedString_TheInstance_ReturnsDescriptionWithSameInstanceWithString()
        {
            // Given
            string expected = "string Value";
            Matcher<string> matcher = TheInstance(expected);

            // When
            TestHelper.AssertDescription("sameInstance(\"" + expected + "\")", matcher);

            // Then - No Exception
        }

        [Fact]
        public void ExpectedNull_TheInstance_ReturnsDescriptionWithSameInstanceWithNull()
        {
            // Given
            Matcher<string> matcher = TheInstance<string>(null);

            // When
            TestHelper.AssertDescription("sameInstance(null)", matcher);

            // Then - No Exception
        }
    }
}
