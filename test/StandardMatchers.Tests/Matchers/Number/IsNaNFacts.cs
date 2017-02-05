using JPopadak.CoreMatchers;
using JPopadak.CoreMatchers.Matchers;
using Xunit;
using static JPopadak.StandardMatchers.Matchers.Matchers;

namespace StandardMatchers.Tests.Matchers.Number
{
    public class IsNaNFacts
    {
        [Fact]
        public void NullValue_NotANumber_IsNullSafe()
        {
            // Given
            IMatcher<double> matcher = NotANumber();

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_NotANumber_IsTypeSafe()
        {
            // Given
            IMatcher<double> matcher = NotANumber();

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void DoubleNaN_NotANumber_ReturnsTrue()
        {
            // Given
            IMatcher<double> matcher = NotANumber();
            double actual = double.NaN;

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void DoublePositiveValue_NotANumber_ReturnsFalse()
        {
            // Given
            IMatcher<double> matcher = NotANumber();
            double actual = 12.345;

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void DoubleNegativeValue_NotANumber_ReturnsFalse()
        {
            // Given
            IMatcher<double> matcher = NotANumber();
            double actual = -12.345;

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void DoublePositiveInfinity_NotANumber_ReturnsFalse()
        {
            // Given
            IMatcher<double> matcher = NotANumber();
            double actual = double.PositiveInfinity;

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void DoubleNegativeInfinity_NotANumber_ReturnsFalse()
        {
            // Given
            IMatcher<double> matcher = NotANumber();
            double actual = double.NegativeInfinity;

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void NotANumber_NotANumber_HasReadableDescription()
        {
            // Given
            IMatcher<double> matcher = NotANumber();

            // When
            TestHelper.AssertDescription("a double value of NaN", matcher);

            // Then - No Exception
        }

        [Fact]
        public void Double12_345_NotANumber_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<double> matcher = NotANumber();
            double actual = 12.345;

            // When
            TestHelper.AssertMismatchDescription("was <12.345>", matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void DoubleNegativeInfinity_NotANumber_HasReadableMismatchDescription()
        {
            // Given
            IMatcher<double> matcher = NotANumber();
            double actual = double.NegativeInfinity;

            // When
            TestHelper.AssertMismatchDescription("was <-∞>", matcher, actual);

            // Then - No Exception
        }
    }
}