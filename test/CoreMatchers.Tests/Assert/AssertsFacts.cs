using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Assert
{
    public class AssertsFacts
    {
        [Fact]
        public void ErrorValuesAndDescription_AssertsThat_FailsWithDescription()
        {
            // Given
            string expected = "expected";
            string actual = "actual";
            string description = "description";

            // When
            var ex = Xunit.Assert.Throws<ArgumentException>(() => Asserts.That(description, actual, EqualTo(expected)));

            // Then
            Xunit.Assert.StartsWith(description, ex.Message);
        }

        [Fact]
        public void ErrorValues_AssertsThat_FailsWithNoDescription()
        {
            // Given
            string expected = "expected";
            string actual = "actual";

            // When
            var ex = Xunit.Assert.Throws<ArgumentException>(() => Asserts.That(actual, EqualTo(expected)));

            // Then
            Xunit.Assert.Contains("Expected: \"" + expected, ex.Message);
            Xunit.Assert.Contains("But: was \"" + actual, ex.Message);
        }

        [Fact]
        public void FalseValue_AssertsThat_FailsWithBoolValue()
        {
            // Given
            string description = "description";
            bool errorValue = false;

            // When
            var ex = Xunit.Assert.Throws<ArgumentException>(() => Asserts.That(description, errorValue));

            // Then
            Xunit.Assert.StartsWith(description, ex.Message);
            Xunit.Assert.Contains("Expected: <" + true, ex.Message);
            Xunit.Assert.Contains("But: was <" + errorValue, ex.Message);
        }

        [Fact]
        public void Int32AndIntBaseType_AssertsThat_NoError()
        {
            // Given
            int actual = 1;
            Int32 expected = 1;

            // When
            Asserts.That(actual, EqualTo(expected));

            // Then - No Error
        }
    }
}
