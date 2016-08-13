﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class AnyOf<T> : ShortcutCombinationMatcher<T>
    {
        public AnyOf(params Matcher<T>[] matchers)
            : base(matchers)
        {
            // Do Nothing
        }

        public override void Describe(IDescription description)
        {
            describeTo(description, "or");
        }

        public override bool Matches(T actual)
        {
            return matches(actual, shortcut: true);
        }
    }
}
