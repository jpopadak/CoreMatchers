using JPopadak.CoreMatchers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Matchers
{
    public abstract class SubStringMatcher : Matcher<string>
    {
        private readonly string _relationship;
        private readonly bool _ignoringCase;
        protected readonly string _substring;

        protected SubStringMatcher(string relationship, bool ignoringCase, string substring)
        {
            _relationship = relationship;
            _ignoringCase = ignoringCase;
            _substring = substring;

            Contract.NotNull(_substring);
        }
    }
}
