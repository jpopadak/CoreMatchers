using System;
using JPopadak.CoreMatchers;
using JPopadak.CoreMatchers.Matchers;
using Xunit;
using static JPopadak.StandardMatchers.Matchers.Matchers;

namespace JPopadak.StandardMatchers.Tests.Matchers.Text
{
    public class HasToStringFacts
    {
        [Fact]
        public void NullValue_HasToString_IsNullSafe()
        {
            // Given
            IMatcher<string> matcher = HasToString("ValueDoesntMatter");

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_HasToString_IsTypeSafe()
        {
            // Given
            IMatcher<string> matcher = HasToString("ValueDoesntMatter");

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void StringValue_HasToStringSameValue_ReturnsTrue()
        {
            // Given
            string actual = "RandomString";
            IMatcher<string> matcher = HasToString(actual);

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Number15_HasToStringOf15_ReturnsTrue()
        {
            // Given
            const int actual = 15;
            IMatcher<string> matcher = HasToString("15");

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ToStringClass_HasToStringOfToStringClassHere_ReturnsTrue()
        {
            // Given
            ToStringClass actual = new ToStringClass();
            IMatcher<string> matcher = HasToString("ToStringClass Here");

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void FormattableClass_HasToStringOfFormattableClassHere_CallsIFormattableFirstReturnsTrue()
        {
            // Given
            FormattableClass actual = new FormattableClass();
            IMatcher<string> matcher = HasToString("FormattableClass Here");

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ConvertableClass_HasToStringOfConvertableClassHere_CallsIConvertableFirstReturnsTrue()
        {
            // Given
            ConvertableClass actual = new ConvertableClass();
            IMatcher<string> matcher = HasToString("ConvertableClass Here");

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        private class ToStringClass
        {
            public override string ToString()
            {
                return "ToStringClass Here";
            }
        }

        private class FormattableClass : ToStringClass, IFormattable
        {
            public string ToString(string format, IFormatProvider formatProvider)
            {
                return "FormattableClass Here";
            }
        }

        private class ConvertableClass : FormattableClass, IConvertible
        {
            public string ToString(IFormatProvider provider)
            {
                return "ConvertableClass Here";
            }

            #region Unused Members
            public TypeCode GetTypeCode()
            {
                throw new NotImplementedException();
            }

            public bool ToBoolean(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public byte ToByte(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public char ToChar(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public DateTime ToDateTime(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public decimal ToDecimal(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public double ToDouble(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public short ToInt16(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public int ToInt32(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public long ToInt64(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public sbyte ToSByte(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public float ToSingle(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public object ToType(Type conversionType, IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public ushort ToUInt16(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public uint ToUInt32(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public ulong ToUInt64(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            #endregion
        }
    }
}