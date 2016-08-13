using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public abstract class ShortcutCombinationMatcher<T> : Matcher<T>
    {
        private readonly Matcher<T>[] _matchers;

        protected ShortcutCombinationMatcher(params Matcher<T>[] matchers)
        {
            _matchers = matchers;
        }

        protected bool matches(T value, bool shortcut)
        {
            foreach (Matcher<T> matcher in _matchers)
            {
                if (matcher.Matches(value) == shortcut)
                {
                    return shortcut;
                }
            }

            return !shortcut;
        }

        public void describeTo(IDescription description, string operation)
        {
            description.AppendList("(", " " + operation + " ", ")", _matchers);
        }
    }
}
