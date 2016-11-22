using System;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsAFacts
    {
        [Fact]
        public void NullValue_IsA_IsNullSafe()
        {
            // Given
            Type actual = typeof(int);
            IMatcher<Type> matcher = IsA(actual);

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownType_IsA_IsUnknownTypeSafe()
        {
            // Given
            Type actual = typeof(int);
            IMatcher<Type> matcher = IsA(actual);

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void Int_IsA_ReturnsTrue()
        {
            // Given
            Type actual = typeof(int);
            IMatcher<Type> matcher = IsA(actual);

            // When
            TestHelper.AssertMatches(matcher, 1);

            // Then - No Exception
        }

        [Fact]
        public void DoubleValue_IsA_ReturnsTrue()
        {
            // Given
            Type actual = typeof(double);
            IMatcher<Type> matcher = IsA(actual);

            // When
            TestHelper.AssertMatches(matcher, 1.1);

            // Then - No Exception
        }

        [Fact]
        public void DoubleExpectedObjectActual_IsA_ReturnsFalse()
        {
            // Given
            Type actual = typeof(double);
            IMatcher<Type> matcher = IsA(actual);

            // When
            TestHelper.AssertDoesNotMatch(matcher, new object());

            // Then - No Exception
        }

        [Fact]
        public void DoubleExpectedObjectActual_IsA_GivesFullClassInMismatchDescription()
        {
            // Given
            string text = "some text";
            Type actual = typeof(double);
            IMatcher<Type> matcher = IsA(actual);

            // When
            TestHelper.AssertMismatchDescription("\"" + text + "\" is an instance of System.String", matcher, text);

            // Then - No Exception
        }

        [Fact]
        public void PrimitiveBoolAndTrue_Any_ReturnsTrue()
        {
            // Given
            Type actual = typeof(bool);
            IMatcher<Type> matcher = Any(actual);

            // When
            TestHelper.AssertMatches(matcher, true);

            // Then - No Exception
        }

        [Fact]
        public void PrimitiveByteAnd0001_Any_ReturnsTrue()
        {
            // Given
            Type actual = typeof(byte);
            IMatcher<Type> matcher = Any(actual);

            // When
            TestHelper.AssertMatches(matcher, (byte)1);

            // Then - No Exception
        }

        [Fact]
        public void PrimitiveCharC_Any_ReturnsTrue()
        {
            // Given
            Type actual = typeof(char);
            IMatcher<Type> matcher = Any(actual);

            // When
            TestHelper.AssertMatches(matcher, 'C');

            // Then - No Exception
        }

        [Fact]
        public void PrimitiveDouble5Point0_Any_ReturnsTrue()
        {
            // Given
            Type actual = typeof(double);
            IMatcher<Type> matcher = Any(actual);

            // When
            TestHelper.AssertMatches(matcher, 5.0);

            // Then - No Exception
        }

        [Fact]
        public void PrimitiveFloat5Point0F_Any_ReturnsTrue()
        {
            // Given
            Type actual = typeof(float);
            IMatcher<Type> matcher = Any(actual);

            // When
            TestHelper.AssertMatches(matcher, 5.0f);

            // Then - No Exception
        }

        [Fact]
        public void PrimitiveInt2_Any_ReturnsTrue()
        {
            // Given
            Type actual = typeof(int);
            IMatcher<Type> matcher = Any(actual);

            // When
            TestHelper.AssertMatches(matcher, 2);

            // Then - No Exception
        }

        [Fact]
        public void PrimitiveLong_Any_ReturnsTrue()
        {
            // Given
            Type actual = typeof(long);
            IMatcher<Type> matcher = Any(actual);

            // When
            TestHelper.AssertMatches(matcher, 4L);

            // Then - No Exception
        }

        [Fact]
        public void PrimitiveDouble_Any_ReturnsTrue()
        {
            // Given
            Type actual = typeof(short);
            IMatcher<Type> matcher = Any(actual);

            // When
            TestHelper.AssertMatches(matcher, (short)1);

            // Then - No Exception
        }
    }
}
