using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Matchers
{
    public class StringEndsWith : SubStringMatcher
    {
        public StringEndsWith(bool ignoringCase, string substring)
            : base("ending with", ignoringCase, substring)
        {
            // Do Nothing
        }

        protected override bool evalSubstringOf(string arg)
        {
            return converted(arg).EndsWith(converted(_substring));
        }
    }
}
