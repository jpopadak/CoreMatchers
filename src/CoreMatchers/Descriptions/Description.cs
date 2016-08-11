using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Descriptions
{
    public class Description : IDescription
    {
        private StringBuilder builder = new StringBuilder();
        private char lastChar = ' ';

        public IDescription AppendText(string text)
        {
            appendString(text);
            return this;
        }

        public IDescription AppendValue<T>(T value)
        {
            builder.Append("\"");
            builder.Append(value);
            builder.Append("\"");
            return this;
        }
 
        public IDescription AppendDescribable(IDescribable describable)
        {
            describable.Describe(this);
            return this;
        }

        protected void appendString(string value)
        {
            builder.Append(value);
        }

        public override string ToString()
        {
            return builder.ToString();
        }
    }
}
