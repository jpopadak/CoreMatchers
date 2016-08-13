using JPopadak.CoreMatchers.Descriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Matchers
{
    public interface IMatcher<in T> : IDescribable
    {
        bool Matches(object actual);

        void DescribeMismatch(object actual, IDescription description);
    }
}
