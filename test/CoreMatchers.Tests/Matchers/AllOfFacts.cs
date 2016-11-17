using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class AllOfFacts
    {
        [Fact]
        public void NullValue_AllOf_IsNullSafe()
        {
            // Given
            Matcher matcher = AllOf(EqualTo("irrelevant"), StartsWith("irr"));

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownType_AllOf_IsUnknownTypeSafe()
        {
            // Given
            Matcher matcher = AllOf(EqualTo("irrelevant"), StartsWith("irr"));

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void TestGoodWithStartsWithGooEndsWithOod_AllOf_ReturnsTrue()
        {
            // Given
            Matcher matcher = AllOf(StartsWith("goo"), EndsWith("ood"));

            // When
            TestHelper.AssertMatches(matcher, "good");

            // Then - No Exception
        }

        [Fact]
        public void TestMoodWithStartsWithGooEndsWithOod_AllOf_ReturnsFalse()
        {
            // Given
            Matcher matcher = AllOf(StartsWith("goo"), EndsWith("ood"));

            // When
            TestHelper.AssertDoesNotMatch(matcher, "mood");

            // Then - No Exception
        }

        [Fact]
        public void TestGoonWithStartsWithGooEndsWithOod_AllOf_ReturnsFalse()
        {
            // Given
            Matcher matcher = AllOf(StartsWith("goo"), EndsWith("ood"));

            // When
            TestHelper.AssertDoesNotMatch(matcher, "goon");

            // Then - No Exception
        }

        [Fact]
        public void TestFredWithStartsWithGooEndsWithOod_AllOf_ReturnsFalse()
        {
            // Given
            Matcher matcher = AllOf(StartsWith("goo"), EndsWith("ood"));

            // When
            TestHelper.AssertDoesNotMatch(matcher, "fred");

            // Then - No Exception
        }

        [Fact]
        public void TestGoodWithManyValidMatchers_AllOf_ReturnsTrue()
        {
            // Given
            Matcher matcher = AllOf(StartsWith("g"), StartsWith("go"),
                EndsWith("d"), StartsWith("go"), StartsWith("goo"));
            
            // When
            TestHelper.AssertMatches(matcher, "good");

            // Then - No Exception
        }

        [Fact]
        public void TestGoonWithManyValidMatchers_AllOf_ReturnsFalse()
        {
            // Given
            Matcher matcher = AllOf(StartsWith("g"), StartsWith("go"),
                EndsWith("d"), StartsWith("go"), StartsWith("goo"));

            // When
            TestHelper.AssertDoesNotMatch(matcher, "goon");

            // Then - No Exception
        }

        [Fact]
        public void MixedMatcherTypes_AllOf_ReturnsFalse()
        {
            // Given
            Matcher matcher = AllOf(
                EqualTo(new SampleBaseClass("bad")), 
                Is(NotNullValue()),
                EqualTo(new SampleBaseClass("good")), 
                EqualTo(new SampleSubClass("ugly")));

            // When
            TestHelper.AssertDoesNotMatch(matcher, new SampleSubClass("good"));

            // Then - No Exception
        }

        [Fact]
        public void MultipleMatchers_AllOf_HasReadableDescription()
        {
            // Given
            Matcher matcher = AllOf(
                EqualTo("good"),
                EqualTo("bad"),
                EqualTo("ugly"));

            // When
            TestHelper.AssertDescription("(\"good\" and \"bad\" and \"ugly\")", matcher);

            // Then - No Exception
        }

        [Fact]
        public void MultipleMatchers_AllOf_DescriptionDescribingFirstFailingMatch()
        {
            // Given
            Matcher matcher = AllOf(
                EqualTo(new SampleBaseClass("bad")),
                Is(NotNullValue()),
                EqualTo(new SampleBaseClass("good")),
                EqualTo(new SampleSubClass("ugly")));

            // When
            TestHelper.AssertDoesNotMatch(matcher, new SampleSubClass("good"));

            // Then - No Exception
        }
    }
}
