using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsSame<T> : Matcher<T>
    {
        private readonly T _value;

        public IsSame(T value)
        {
            _value = value;
        }

        public override bool Matches(object actual)
        {
            return object.ReferenceEquals(actual, _value);
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("sameInstance(")
                .AppendValue(_value)
                .AppendText(")");
        }
    }
}
