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
                object[] expectedArray = (object[])expected;
                object[] actualArray = (object[])actual;
                return Enumerable.SequenceEqual(actualArray, expectedArray);
            }
            
            return actual.Equals(expected);
        }

        private bool isArray()
        {
            return typeof(T).IsArray;
        }
    }
}
