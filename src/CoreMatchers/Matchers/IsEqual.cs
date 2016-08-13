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

        public override bool Matches(T actual)
        {
            return areEqual(actual, _expectedValue);
        }

        private static bool areEqual(T actual, T expected)
        {
            if (actual == null)
            {
                return expected == null;
            }

            if (expected != null && isArray())
            {
                throw new NotImplementedException("Array compatibility is not completed.");
            }
            
            return actual.Equals(expected);
        }

        private static bool isArray()
        {
            return typeof(T).IsArray;
        }
    }
}
