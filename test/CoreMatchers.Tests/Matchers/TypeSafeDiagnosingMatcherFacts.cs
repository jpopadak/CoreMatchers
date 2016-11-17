using JPopadak.CoreMatchers.Descriptions;
using Xunit;

namespace JPopadak.CoreMatchers.Matchers
{
    public class TypeSafeDiagnosingMatcherFacts
    {
        class StringMatcher : TypeSafeDiagnosingMatcher<string>
        {
            public override void Describe(IDescription description)
            {
                // Do Nothing
            }

            protected override bool MatchesSafely(string item, IDescription mismatchDescription)
            {
                mismatchDescription.AppendText("mismatching");
                return false;
            }
        }

        class TypeSafeDiagnosingMatcherSubClass<T> : TypeSafeDiagnosingMatcher<T>
        {
            public override void Describe(IDescription description)
            {
                description.AppendText("sub type");
            }

            protected override bool MatchesSafely(T item, IDescription mismatchDescription)
            {
                return true;
            }
        }

        class NotBuiltIn
        {
            public override string ToString() { return "NotBuiltIn"; }
        }

        class OtherNotBuiltIn
        {
            // Empty
        }


        [Fact]
        public void NullValue_DescribeMismatch_IncludesWasNull()
        {
            // Given
            StringMatcher matcher = new StringMatcher();
            string value = null;

            // When
            TestHelper.AssertMismatchDescription("was null", matcher, value);

            // Then - No exception
        }

        [Fact]
        public void DifferentTypeNullable_DescribeMismatch_IncludesType()
        {
            // Given
            StringMatcher matcher = new StringMatcher();
            int? value = null;

            // When
            TestHelper.AssertMismatchDescription("was null", matcher, value);

            // Then - No exception
        }

        [Fact]
        public void DifferentValueSameType_DescribeMismatch_IncludesTheMismatch()
        {
            // Given
            StringMatcher matcher = new StringMatcher();
            string value = "value";

            // When
            TestHelper.AssertMismatchDescription("mismatching", matcher, value);

            // Then - No exception
        }

        [Fact]
        public void DifferentType_DescribeMismatch_IncludesTheMismatch()
        {
            // Given
            StringMatcher matcher = new StringMatcher();
            char value = 'c';

            // When
            TestHelper.AssertMismatchDescription($"was Char (\"{value}\")", matcher, value);

            // Then - No exception
        }
    }
}
