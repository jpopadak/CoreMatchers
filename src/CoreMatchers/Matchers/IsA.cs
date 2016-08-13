using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsA<T> : Matcher<T>
    {
        private readonly Type _type;

        public IsA()
        {
            _type = typeof(T);
        }

        public override void Describe(IDescription description)
        {
            description.AppendText("an instance of ").AppendText(_type.Name);
        }

        public override bool Matches(T actual)
        {
            if (actual == null)
            {
                return false;
            }

            return _type.Equals(actual);
        }
    }
}
