using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class AnyOf : ShortcutCombinationMatcher
    {
        public AnyOf(params Matcher[] matchers)
            : base(matchers)
        {
            // Do Nothing
        }

        public AnyOf(IEnumerable<Matcher> matchers)
            : this(matchers.ToArray())
        {
            // Do Nothing
        }

        public override void Describe(IDescription description)
        {
            describeTo(description, "or");
        }

        public override bool Matches(object actual)
        {
            return matches(actual, shortcut: true);
        }
    }
}
