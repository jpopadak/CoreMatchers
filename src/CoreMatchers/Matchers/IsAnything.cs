using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsAnything<T> : Matcher<T>
    {
        private readonly string _message;

        public IsAnything()
            : this("ANYTHING")
        {
            // Do Nothing
        }

        public IsAnything(string message)
        {
            _message = message;
        }

        public override bool Matches(T actual)
        {
            return true;
        }

        public override void Describe(IDescription description)
        {
            description.AppendText(_message);
        }
    }
}
