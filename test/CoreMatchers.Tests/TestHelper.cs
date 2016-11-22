using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;
using System;

namespace JPopadak.CoreMatchers
{
    public class TestHelper
    {
        public static void AssertMatches<T>(IMatcher<T> matcher, object arg)
        {
            AssertMatches("Expected match, but mismatched", matcher, arg);
        }

        public static void AssertMatches<T>(string message, IMatcher<T> matcher, object arg)
        {
            bool matches = matcher.Matches(arg);
            if (!matches)
            {
                Xunit.Assert.True(matches, $"{message} because: \'{mismatchDescription(matcher, arg)}\'");
            }
        }
        
        public static void AssertDoesNotMatch<T>(IMatcher<T> c, object arg)
        {
            AssertDoesNotMatch("Unexpected match", c, arg);
        }

        public static void AssertDoesNotMatch<T>(string message, IMatcher<T> c, object arg)
        {
            Xunit.Assert.False(c.Matches(arg), message);
        }

        public static void AssertDescription<T>(string expected, IMatcher<T> matcher)
        {
            Description description = new Description();
            description.AppendDescribable(matcher);

            Xunit.Assert.Equal(expected, description.ToString(), ignoreWhiteSpaceDifferences: true);
        }

        public static void AssertMismatchDescription<T>(string expected, IMatcher<T> matcher, object arg)
        {
            Xunit.Assert.False(matcher.Matches(arg), "Precondition: Matcher should not match item.");
            Xunit.Assert.Equal(expected, mismatchDescription(matcher, arg), ignoreWhiteSpaceDifferences: true);
        }

        public static void AssertNullSafe<T>(IMatcher<T> matcher)
        {
            try
            {
                matcher.Matches(null);
            }
            catch
            {
                Xunit.Assert.True(false, "Matcher was not null safe");
            }
        }

        public static void AssertUnknownTypeSafe<T>(IMatcher<T> matcher)
        {
            try
            {
                matcher.Matches(new UnknownType());
            }
            catch (Exception ex)
            {
                Xunit.Assert.True(false, $"Matcher was not unknown type safe, because: {ex}");
            }
        }
        public void TestIsNullSafe<T>(IMatcher<T> matcher)
        {
            AssertNullSafe(matcher);
        }

        public void TestCopesWithUnknownTypes<T>(IMatcher<T> matcher)
        {
            matcher.Matches(new UnknownType());
        }

        private class UnknownType
        {
            // Do Nothing
        }

        private static string mismatchDescription<T>(IMatcher<T> matcher, object arg)
        {
            Description description = new Description();
            matcher.DescribeMismatch(arg, description);
            return description.ToString().Trim();
        }
    }
}
