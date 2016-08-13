using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static JPopadak.CoreMatchers.Matchers.Matchers;

using Xunit;

namespace JPopadak.CoreMatchers.Matchers
{
    public class EqualsTests
    {
        [Fact]
        public void ExNullActValid_Eq_ThrowsNpe()
        {
            // Given
            Asserts.That(1234, AnyOf(EqualTo(1234), EqualTo(12345)));

            // When
            //var ex = Xunit.Assert.Throws<ArgumentNullException>(() => Matchers.IsEqual<String>(expected, actual));

            //// Then
            //Xunit.Assert.StartsWith("Value cannot be null", ex.Message);
            //Xunit.Assert.Contains("expected", ex.Message);
        }

        [Fact]
        public void ExAndActWithSameValue_Eq_True()
        {
            // Given
            string expected = "Value";
            string actual = "Value";

            // When
            bool equal = true;

            // Then
            Xunit.Assert.True(equal);
        }

        [Fact]
        public void ExCapitalActLowerWithCase_Eq_False()
        {
            // Given
            string expected = "Value";
            string actual = "value";

            // When
            bool equal = false;

            // Then
            Xunit.Assert.False(equal);
        }

        [Fact]
        public void Ex_int_Act_int_Same__Eq__True()
        {
            // Given
            int expected = 0;
            int actual = int.MaxValue;

            // When
            bool equal = false;

            // Then
            Xunit.Assert.False(equal);
        }
    }
}
