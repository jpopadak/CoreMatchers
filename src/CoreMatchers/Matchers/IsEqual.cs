using System;
using JPopadak.CoreMatchers.Descriptions;
using System.Collections;

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
                Array expectedArray = (Array)expected;
                Array actualArray = (Array)actual;
                return checkArraysEqual(actualArray, expectedArray);
            }

            return actual.Equals(expected);
        }

        private static bool checkArraysEqual(Array actual, Array expected)
        {
            // Use GetEnumerator() so it can do the work of iterating
            // over the ranks and lengths of a mutli-dim array
            IEnumerator expectedEnumerator = expected.GetEnumerator();
            IEnumerator actualEnumerator = actual.GetEnumerator();

            while (true)
            {
                // Get to the next on in the array
                bool expectedCheck = expectedEnumerator.MoveNext();
                bool actualCheck = actualEnumerator.MoveNext();
                
                // We hit the end of one collection before the other
                if (expectedCheck != actualCheck)
                {
                    return false;
                }

                // We already checked if they were different,
                // so if one hits the end, they both must have 
                // hit the end of the collection with no mismatches
                if (!expectedCheck)
                {
                    return true;
                }
                
                // Check the values now
                object expectedValue = expectedEnumerator.Current;
                object actualValue = actualEnumerator.Current;

                // If one of them but not the other is null
                if ((expectedValue != null && actualValue == null) ||
                    (expectedValue == null && actualValue != null))
                {
                    return false;
                }

                // IF they are both null, they are the same!
                if (expectedValue == null && actualValue == null)
                {
                    continue;
                }

                // Do a normal Equals
                if (!(expectedValue.Equals(actualValue)))
                {
                    return false;
                }
            }
        }

        private bool isArray()
        {
            if (_expectedValue == null)
            {
                return false;
            }
            return _expectedValue.GetType().IsArray;
        }
    }
}
