using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public abstract class ShortcutCombinationMatcher<T> : Matcher<T>
    {
        private readonly IDescribable[] _matchers;

        protected ShortcutCombinationMatcher(params IMatcher<T>[] matchers)
        {
            _matchers = matchers;
        }

        protected bool matches(object value, bool shortcut)
        {
            foreach (var describable in _matchers)
            {
                var matcher = (IMatcher<T>) describable;
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
