using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public abstract class ShortcutCombinationMatcher : Matcher
    {
        private readonly Matcher[] _matchers;

        protected ShortcutCombinationMatcher(params Matcher[] matchers)
        {
            _matchers = matchers;
        }

        protected bool matches(object value, bool shortcut)
        {
            foreach (Matcher matcher in _matchers)
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
