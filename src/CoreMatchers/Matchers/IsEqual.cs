using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsEqual<T> : Matcher<T>
    {
        private readonly T _expectedValue;

        public IsEqual(T expectedValue)
        {
            _expectedValue = expectedValue;
        }

        public override void Describe(IDescription description)
        {
            description.AppendValue(_expectedValue);
        }

        public override bool Matches(object actual)
        {
            return areEqual(actual, _expectedValue);
        }

        private bool areEqual(object actual, object expected)
        {
            if (actual == null)
            {
                return expected == null;
            }

            if (expected != null && isArray())
            {
                //dynamic expectedArray = expected;
                //dynamic actualArray = actual;
                //return Enumerable.SequenceEqual(actualArray, expectedArray);

                // https://github.com/dotnet/roslyn/issues/12045
                throw new NotImplementedException("Cannot implement dynamic types until issue is solved.");
            }
            
            return actual.Equals(expected);
        }

        private bool isArray()
        {
            return typeof(T).IsArray;
        }
    }
}
