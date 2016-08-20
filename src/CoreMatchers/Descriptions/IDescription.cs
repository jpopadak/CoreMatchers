using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Descriptions
{
    public interface IDescription
    {
        IDescription AppendText(string text);

        IDescription AppendList(string before, string separator, string after, params IDescribable[] args);

        IDescription AppendValue(object value);

        IDescription AppendDescribable(IDescribable describable);
    }
}
