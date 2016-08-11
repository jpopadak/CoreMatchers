using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsNull<T> : Matcher<T>
    {
        public override bool Matches(T actual)
        {
            return actual == null;
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("null");
        }
    }
}
