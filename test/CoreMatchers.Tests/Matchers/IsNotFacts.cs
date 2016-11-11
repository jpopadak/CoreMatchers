using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsNotFacts
    {
        [Fact]
        public void NullValue_Not_IsNullSafe()
        {
            // Given
            string actual = "value";
            Matcher matcher = Not(actual);

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnkonwnTypeValue_Not_IsUnknownTypeSafe()
        {
            // Given
            string actual = "value";
            Matcher matcher = Not(actual);

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void InvalidExpectedVsActualValue_Not_RetursTrue()
        {
            // Given
            string actual = "value";
            string expected = "ASDF";
            Matcher matcher = Not(expected);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ExpectedIsActualValue_Not_RetursTrue()
        {
            // Given
            string actual = "value";
            Matcher matcher = Not(actual);

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Value_Not_NegatedValueDescription()
        {
            // Given
            string actual = "value";
            Matcher matcher = Not(actual);

            // When
            TestHelper.AssertDescription("not \"value\"", matcher);

            // Then - No Exception
        }

        [Fact]
        public void InstanceOf_NotInstanceOf_NegatedInstanceDescription()
        {
            // Given
            Matcher matcher = Not(InstanceOf(typeof(string)));

            // When
            TestHelper.AssertDescription("not an instance of System.String", matcher);

            // Then - No Exception
        }
    }
}
