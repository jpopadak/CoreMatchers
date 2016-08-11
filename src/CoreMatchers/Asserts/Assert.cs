using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Asserts
{
    public static class Assert
    {
        static void That<T>(T actual, Matcher<T> matcher)
        {
            That(string.Empty, actual, matcher);
        }
        
        static void That<T>(string message, T actual, Matcher<T> matcher)
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
    }
}
