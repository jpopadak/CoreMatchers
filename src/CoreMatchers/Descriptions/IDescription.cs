using System.Collections.Generic;

namespace JPopadak.CoreMatchers.Descriptions
{
    public interface IDescription
    {
        IDescription AppendText(string text);

        IDescription AppendList(string before, string separator, string after, params IDescribable[] args);

        IDescription AppendList(string before, string separator, string after, IEnumerable<IDescribable> args);
        
        IDescription AppendValueList<T>(string start, string separator, string end, IEnumerable<T> values);

        IDescription AppendValue(object value);

        IDescription AppendDescribable(IDescribable describable);
    }
}
