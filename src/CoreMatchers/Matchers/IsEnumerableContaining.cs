using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsEnumerableContaining<T> : Matcher<IEnumerable<T>>
    {
        private readonly Matcher<T> _matcher;

        public IsEnumerableContaining(Matcher<T> elementMatcher)
        {
            _matcher = elementMatcher;
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("an enumerable containing ")
                .AppendDescribable(_matcher);
        }

        public override bool Matches(IEnumerable<T> actual)
        {
            if (isEmpty(actual))
            {
                return false;
            }

            return doesOneMatch(actual);
        }

        public override void DescribeMismatch(IEnumerable<T> actual, IDescription description)
        {
            if (isEmpty(actual))
            {
                description.AppendText("was empty");
                return;
            }

            if (doesOneMatch(actual))
            {
                // Successful case
                return;
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
        }

        private bool isEmpty(IEnumerable<T> enumerable)
        {
            IEnumerator<T> enumerator = enumerable.GetEnumerator();
            return (!enumerator.MoveNext());
        }

        private bool doesOneMatch(IEnumerable<T> enumerable)
        {
            return enumerable.Any(_matcher.Matches);
        }
    }
}
