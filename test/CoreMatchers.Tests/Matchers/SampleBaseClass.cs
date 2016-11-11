using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Matchers
{
    public class SampleBaseClass
    {
        private readonly string value;

        public SampleBaseClass(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
        }

        public override bool Equals(object obj)
        {
            SampleBaseClass sbc = obj as SampleBaseClass;
            return sbc != null && value.Equals(sbc.value);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}
