using System.Collections;
using System.Collections.Generic;

namespace JPopadak.CoreMatchers.Descriptions
{
    public class SelfDescribingValueEnumerable<T> : IEnumerable<IDescribable>
    {
        private readonly List<SelfDescribingValue<T>> values;

        public SelfDescribingValueEnumerable(IEnumerable<T> values)
        {
            List<SelfDescribingValue<T>> describingValues = new List<SelfDescribingValue<T>>();
            foreach (T value in values)
            {
                describingValues.Add(new SelfDescribingValue<T>(value));
            }
            this.values = describingValues;
        }

        public IEnumerator<IDescribable> GetEnumerator()
        {
            return values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
