using JPopadak.CoreMatchers.Descriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Matchers
{
    public abstract class DiagnosingMatcher : Matcher
    {
        public sealed override bool Matches(object item)
        {
            return Matches(item, new Description());
        }
        
        public sealed override void DescribeMismatch(object item, IDescription mismatchDescription)
        {
            Matches(item, mismatchDescription);
        }

        protected abstract bool Matches(object item, IDescription mismatchDescription);
    }
}
