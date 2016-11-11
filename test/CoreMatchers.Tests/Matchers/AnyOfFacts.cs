using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class AnyOfFacts
    {
        [Fact]
        public void NullValue_AnyOf_IsNullSafe()
        {
            // Given
            Matcher matcher = AnyOf(EqualTo("irrelevant"), StartsWith("irr"));

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownType_AnyOf_IsUnknownTypeSafe()
        {
            // Given
            Matcher matcher = AnyOf(EqualTo("irrelevant"), StartsWith("irr"));

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void TestGoodWithStartsWithGooEndsWithOod_AnyOf_ReturnsTrue()
        {
            // Given
            Matcher matcher = AnyOf(StartsWith("goo"), EndsWith("ood"));

            // When
            TestHelper.AssertMatches(matcher, "good");

            // Then - No Exception
        }

        [Fact]
        public void TestMoodWithStartsWithGooEndsWithOod_AnyOf_ReturnsTrue()
        {
            // Given
            Matcher matcher = AnyOf(StartsWith("goo"), EndsWith("ood"));

            // When
            TestHelper.AssertMatches(matcher, "mood");

            // Then - No Exception
        }

        [Fact]
        public void TestGoonWithStartsWithGooEndsWithOod_AnyOf_ReturnsTrue()
        {
            // Given
            Matcher matcher = AnyOf(StartsWith("goo"), EndsWith("ood"));

            // When
            TestHelper.AssertMatches(matcher, "goon");

            // Then - No Exception
        }

        [Fact]
        public void TestFlanWithStartsWithGooEndsWithOod_AnyOf_ReturnsFalse()
        {
            // Given
            Matcher matcher = AnyOf(StartsWith("goo"), EndsWith("ood"));

            // When
            TestHelper.AssertDoesNotMatch(matcher, "flan");

            // Then - No Exception
        }

        [Fact]
        public void TestVlad_AnyOf_ReturnsFalse()
        {
            // Given
            Matcher matcher = AnyOf(StartsWith("goo"), EndsWith("ood"));

            // When
            TestHelper.AssertDoesNotMatch(matcher, "flan");

            // Then - No Exception
        }

        [Fact]
        public void TestVladManyMatchers_AnyOf_ReturnsTrue()
        {
            // Given
            Matcher matcher = AnyOf(StartsWith("g"), StartsWith("go"), EndsWith("d"), StartsWith("go"), StartsWith("goo"));

            // When
            TestHelper.AssertMatches(matcher, "vlad");

            // Then - No Exception
        }

        [Fact]
        public void TestFlanManyMatchers_AnyOf_ReturnsFalse()
        {
            // Given
            Matcher matcher = AnyOf(StartsWith("g"), StartsWith("go"), EndsWith("d"), StartsWith("go"), StartsWith("goo"));

            // When
            TestHelper.AssertDoesNotMatch(matcher, "flan");

            // Then - No Exception
        }

        [Fact]
        public void MixedMatcherTypes_AnyOf_ReturnsTrue()
        {
            // Given
            Matcher matcher = AnyOf(
                EqualTo(new SampleBaseClass("bad")),
                EqualTo(new SampleBaseClass("good")),
                EqualTo(new SampleSubClass("ugly")));

            // When
            TestHelper.AssertMatches(matcher, new SampleSubClass("good"));

            // Then - No Exception
        }

        [Fact]
        public void MultipleMatchers_AnyOf_HasReadableDescription()
        {
            // Given
            Matcher matcher = AnyOf(
                EqualTo("good"),
                EqualTo("bad"),
                EqualTo("ugly"));

            // When
            TestHelper.AssertDescription("(\"good\" or \"bad\" or \"ugly\")", matcher);

            // Then - No Exception
        }
    }
}
