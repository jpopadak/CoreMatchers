using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class Is : Matcher
    {
        private readonly Matcher _matcher;

        public Is(Matcher matcher)
        {
            _matcher = matcher;
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("is ").AppendDescribable(_matcher);
        }

        public override void DescribeMismatch(object actual, IDescription description)
        {
            _matcher.DescribeMismatch(actual, description);
        }

        public override bool Matches(object actual)
        {
            return _matcher.Matches(actual);
        }
    }
}
