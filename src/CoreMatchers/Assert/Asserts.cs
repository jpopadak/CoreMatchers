using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;
using System;

namespace JPopadak.CoreMatchers
{
    public static class Asserts
    {
        public static void That<T>(T actual, IMatcher<T> matcher)
        {
            That(string.Empty, actual, matcher);
        }
        
        public static void That<T>(string message, T actual, IMatcher<T> matcher)
        {
            if (!matcher.Matches(actual))
            {
                Description description = new Description();
                description.AppendText(message)
                    .AppendText("\nExpected: ")
                    .AppendDescribable(matcher)
                    .AppendText("\n     But: ");
                matcher.DescribeMismatch(actual, description);

                throw new ArgumentException(description.ToString());
            }
        }

        public static void That(string message, bool validation)
        {
            That(message, validation, Matchers.Matchers.EqualTo(true));
        }
    }
}
