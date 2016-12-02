using JPopadak.CoreMatchers.Matchers;
using System.Collections.Generic;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.StandardMatchers.Matchers.Collections
{
    public class IsEmptyEnumerable<T> : TypeSafeMatcher<IEnumerable<T>>
    {
        protected override bool MatchesSafely(IEnumerable<T> item)
        {
            using (IEnumerator<T> enumerator = item.GetEnumerator())
            {
                return !enumerator.MoveNext();
            }
        }

        protected override void DescribeMismatchSafely(IEnumerable<T> enumerable, IDescription mismatchDescription)
        {
            mismatchDescription.AppendValueList("[", ",", "]", enumerable);
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("an empty IEnumerable");
        }
    }
}
