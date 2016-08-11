using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Descriptions
{
    public interface IDescription
    {
        IDescription AppendText(string text);

        IDescription AppendValue<T>(T value);

        IDescription AppendDescribable(IDescribable describable);
    }
}
