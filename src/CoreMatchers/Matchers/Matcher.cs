﻿using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public abstract class Matcher<T> : IMatcher<T>
    {
        public abstract void Describe(IDescription description);

        public abstract bool Matches(object actual);

        public virtual void DescribeMismatch(object actual, IDescription description)
        {
            description.AppendText("was ").AppendValue(actual);
        }

        public override string ToString()
        {
            Description description = new Description();
            description.AppendDescribable(this);
            return description.ToString();
        }
    }
}
