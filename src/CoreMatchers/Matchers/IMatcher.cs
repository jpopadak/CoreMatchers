using JPopadak.CoreMatchers.Descriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Matchers
{
    public interface IMatcher<T> : IDescribable
    {
        bool Matches(T actual);

        void DescribeMismatch(T actual, IDescription description);
    }
}
