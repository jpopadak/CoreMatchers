using System;
using System.Reflection;
using JPopadak.CoreMatchers.Descriptions;
using JPopadak.CoreMatchers.Contracts;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsA : DiagnosingMatcher<Type>
    {
        private readonly Type _type;

        public IsA(Type type)
        {
            Contract.NotNull(type);
            _type = type;
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("an instance of ").AppendText(_type.FullName);
        }

        protected override bool Matches(object actual, IDescription mismatchDescription)
        {
            if (actual == null)
            {
                mismatchDescription.AppendText("null");
                return false;
            }
            
            if (!_type.IsInstanceOfType(actual))
            {
                Type actualType = actual.GetType();
                mismatchDescription.AppendValue(actual).AppendText(" is an instance of ").AppendText(actualType.FullName);
                return false;
            }
            return true;
        }
    }
}
