using System.Collections.Generic;
using System.Linq;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsEnumerableContaining<T> : TypeSafeDiagnosingMatcher<IEnumerable<T>>
    {
        private readonly IMatcher<T> _matcher;

        public IsEnumerableContaining(IMatcher<T> elementMatcher)
        {
            _matcher = elementMatcher;
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("an enumerable containing ")
                .AppendDescribable(_matcher);
        }

        private bool isEmpty(IEnumerable<T> enumerable)
        {
            using (IEnumerator<T> enumerator = enumerable.GetEnumerator())
            {
                return !enumerator.MoveNext();
            }
        }

        private bool doesOneMatch(IEnumerable<T> enumerable)
        {
            return enumerable.Any(_ => _matcher.Matches(_));
        }

        protected override bool MatchesSafely(IEnumerable<T> actual, IDescription description)
        {
            var enumerable = actual.ToList();
            if (isEmpty(enumerable))
            {
                description.AppendText("was empty");
                return false;
            }

            if (doesOneMatch(enumerable))
            {
                return true;
            }

            description.AppendText("mismatches were: [");

            bool isPastFirst = false;
            foreach (T item in enumerable)
            {
                if (isPastFirst)
                {
                    description.AppendText(", ");
                }
                _matcher.DescribeMismatch(item, description);

                isPastFirst = true;
            }

            description.AppendText("]");
            return false;
        }
    }
}
