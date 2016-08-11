using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace JPopadak.CoreMatchers.Matchers
{
    public class EqualsTests
    {
        [Fact]
        public void ExNullActValid_Eq_ThrowsNpe()
        {
            // Given
            string expected = null;
            string actual = "Actual";

            // When
            var ex = Assert.Throws<ArgumentNullException>(() => actual.Eq(expected));

            // Then
            Assert.StartsWith("Value cannot be null", ex.Message);
            Assert.Contains("expected", ex.Message);
        }

        [Fact]
        public void ExAndActWithSameValue_Eq_True()
        {
            // Given
            string expected = "Value";
            string actual = "Value";

            // When
            bool equal = actual.Eq(expected);

            // Then
            Assert.True(equal);
        }

        [Fact]
        public void ExCapitalActLowerWithCase_Eq_False()
        {
            // Given
            string expected = "Value";
            string actual = "value";

            // When
            bool equal = actual.Eq(expected);

            // Then
            Assert.False(equal);
        }

        [Fact]
        public void Ex_int_Act_int_Same__Eq__True()
        {
            // Given
            int expected = 0;
            int actual = int.MaxValue;

            // When
            bool equal = actual.Eq(expected);

            // Then
            Assert.False(equal);
        }
    }
}
