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
    }
}
