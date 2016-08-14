using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers
{
    public class TestHelper
    {
        public static void AssertMatches<T>(Matcher<T> matcher, object arg)
        {
            AssertMatches("Expected match, but mismatched", matcher, arg);
        }

        public static void AssertMatches<T>(String message, Matcher<T> matcher, object arg)
        {
            bool matches = matcher.Matches(arg);
            if (!matches)
            {
                Xunit.Assert.True(matches, (message + " because: '" + mismatchDescription(matcher, arg) + "'"));
            }
        }
        
        public static void AssertDoesNotMatch<T>(Matcher<T> c, object arg)
        {
            AssertDoesNotMatch("Unexpected match", c, arg);
        }

        public static void AssertDoesNotMatch<T>(String message, Matcher<T> c, object arg)
        {
            Xunit.Assert.False(c.Matches(arg), message);
        }

        public static void AssertDescription<T>(String expected, Matcher<T> matcher)
        {
            Description description = new Description();
            description.AppendDescribable(matcher);

            Xunit.Assert.Equal(expected, description.ToString(), ignoreWhiteSpaceDifferences: true);
        }

        public static void AssertMismatchDescription<T>(String expected, Matcher<T> matcher, object arg)
        {
            Xunit.Assert.False(matcher.Matches(arg), "Precondition: Matcher should not match item.");
            Xunit.Assert.Equal(expected, mismatchDescription(matcher, arg), ignoreWhiteSpaceDifferences: true);
        }

        public static void AssertNullSafe<T>(Matcher<T> matcher)
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

        public static void AssertUnknownTypeSafe<T>(Matcher<T> matcher)
        {
            try
            {
                matcher.Matches(new UnknownType());
            }
            catch (Exception ex)
            {
                Xunit.Assert.True(false, "Matcher was not unknown type safe, because: " + ex);
            }
        }
        public void TestIsNullSafe<T>(Matcher<T> matcher)
        {
            AssertNullSafe(matcher);
        }

        public void TestCopesWithUnknownTypes<T>(Matcher<T> matcher)
        {
            matcher.Matches(new UnknownType());
        }

        private class UnknownType
        {
            // Do Nothing
        }

        private static string mismatchDescription<T>(Matcher<T> matcher, object arg)
        {
            Description description = new Description();
            matcher.DescribeMismatch(arg, description);
            return description.ToString().Trim();
        }
    }
}
