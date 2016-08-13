using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public abstract class Matcher<T> : IMatcher<T>
    {
        public abstract void Describe(IDescription description);

        public abstract bool Matches(object actual);

        public virtual void DescribeMismatch(object actual, IDescription description)
        {
            description.AppendText("was ").AppendValue(actual);
        }
    }
}
