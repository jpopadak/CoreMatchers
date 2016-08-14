using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;
using Xunit;
using JPopadak.CoreMatchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class TypeSafeMatcherFacts
    {
        class TypeSafeMatcherSubClass<T> : TypeSafeMatcher<T>
        {
            public override void Describe(IDescription description)
            {
                description.AppendText("The match ");
            }

            protected override bool MatchesSafely(T item)
            {
                return false;
            }
        }

        [Fact]
        public void GivenDifferntTypeOfNullString_Matches_EnsuresValueIsNullAndReturnsFalse()
        {
            // Given
            TypeSafeMatcherSubClass<int> matcher = new TypeSafeMatcherSubClass<int>();
            string value = null;

            // When
            bool matches = matcher.Matches(value);

            // Then
            Xunit.Assert.False(matches);
        }

        [Fact]
        public void GivenDifferntTypeOfString_Matches_EnsuresTypeIsUnsafeAndReturnsFalse()
        {
            // Given
            TypeSafeMatcherSubClass<int> matcher = new TypeSafeMatcherSubClass<int>();
            string value = "asdf";

            // When
            bool matches = matcher.Matches(value);

            // Then
            Xunit.Assert.False(matches);
        }

        [Fact]
        public void NullValue_DescribeMismatch_IncludesWasNull()
        {
            // Given
            TypeSafeMatcherSubClass<string> matcher = new TypeSafeMatcherSubClass<string>();
            string value = null;

            // When
            TestHelper.AssertMismatchDescription("was null", matcher, value);

            // Then - No exception
        }

        [Fact]
        public void DifferentTypeNullable_DescribeMismatch_IncludesType()
        {
            // Given
            TypeSafeMatcherSubClass<string> matcher = new TypeSafeMatcherSubClass<string>();
            int? value = null;

            // When
            TestHelper.AssertMismatchDescription("was null", matcher, value);

            // Then - No exception
        }

        [Fact]
        public void DifferentValueSameType_DescribeMismatch_IncludesTheMismatch()
        {
            // Given
            TypeSafeMatcherSubClass<string> matcher = new TypeSafeMatcherSubClass<string>();
            string value = "differentValue";

            // When
            TestHelper.AssertMismatchDescription($"was \"{value}\"", matcher, value);

            // Then - No exception
        }

        [Fact]
        public void DifferentType_DescribeMismatch_IncludesTheMismatch()
        {
            // Given
            TypeSafeMatcherSubClass<string> matcher = new TypeSafeMatcherSubClass<string>();
            char value = 'c';

            // When
            TestHelper.AssertMismatchDescription($"was a Char (\"{value}\")", matcher, value);

            // Then - No exception
        }
    }
}
