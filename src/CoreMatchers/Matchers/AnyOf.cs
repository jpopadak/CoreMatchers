﻿using System.Collections.Generic;
using System.Linq;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class AnyOf<T> : ShortcutCombinationMatcher<T>
    {
        public AnyOf(params IMatcher<T>[] matchers) : base(matchers)
        {
            // Do Nothing
        }

        public AnyOf(IEnumerable<IMatcher<T>> matchers)
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
            return matches(actual, true);
        }
    }
}
