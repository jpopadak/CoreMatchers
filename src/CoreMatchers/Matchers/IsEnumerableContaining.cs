using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsEnumerableContaining<T> : TypeSafeDiagnosingMatcher<IEnumerable<T>>
    {
        private readonly Matcher _matcher;

        public IsEnumerableContaining(Matcher elementMatcher)
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
            IEnumerator<T> enumerator = enumerable.GetEnumerator();
            return (!enumerator.MoveNext());
        }

        private bool doesOneMatch(IEnumerable<T> enumerable)
        {
            return enumerable.Any(_ => _matcher.Matches(_));
        }

        protected override bool MatchesSafely(IEnumerable<T> actual, IDescription description)
        {
            if (isEmpty(actual))
            {
                description.AppendText("was empty");
                return false;
            }

            if (doesOneMatch(actual))
            {
                return true;
            }

            description.AppendText("mismatches were: [");

            bool isPastFirst = false;
            foreach (T item in actual)
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
