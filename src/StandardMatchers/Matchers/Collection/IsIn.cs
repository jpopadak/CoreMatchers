using System.Collections.Generic;
using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers.Collections
{
    public class IsIn<T> : Matcher<T>
    {
        private readonly ICollection<T> _collection;

        public IsIn(ICollection<T> collection)
        {
            _collection = collection;
        }

        public IsIn(params T[] elements)
        {
            _collection = new List<T>(elements);
        }

        public override bool Matches(object actual)
        {
            if (actual is T casted)
            {
                return _collection.Contains(casted);
            }
            return false;
        }
        
        public override void Describe(IDescription description)
        {
            description.AppendText("one of ");
            description.AppendValueList("{", ", ", "}", _collection);
        }
    }
}