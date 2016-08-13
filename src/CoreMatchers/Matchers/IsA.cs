using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsA<T> : DiagnosingMatcher<T>
    {
        private readonly Type _type;

        public IsA(Type type)
        {
            _type = type;
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("an instance of ").AppendText(_type.Name);
        }

        protected override bool Matches(object actual, IDescription mismatchDescription)
        {
            if (actual == null)
            {
                mismatchDescription.AppendText("null");
                return false;
            }

            if (!(actual is T))
            {
                Type actualType = actual.GetType();
                mismatchDescription.AppendText("an instance of ").AppendText(actualType.Name);
                return false;
            }
            return true;
        }
    }
}
