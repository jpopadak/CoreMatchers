﻿using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class Is<T> : Matcher<T>
    {
        private readonly IMatcher<T> _matcher;

        public Is(IMatcher<T> matcher)
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
