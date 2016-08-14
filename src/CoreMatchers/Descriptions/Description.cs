using JPopadak.CoreMatchers.Matchers;
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

        public IDescription AppendText(string text)
        {
            appendString(text);
            return this;
        }

        public IDescription AppendList(string before, string separator, string after, params IDescribable[] args)
        {
            return appendList(before, separator, after, args);
        }

        public IDescription AppendValue<T>(T value)
        {
            if (value == null)
            {
                AppendText("null");
            }
            else
            {
                AppendText("\"");
                AppendText(value.ToString());
                AppendText("\"");
            }
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

        private IDescription appendList(String start, String separator, String end, params IDescribable[] describables)
        {
            bool separate = false;

            appendString(start);
            foreach (IDescribable describable in describables)
            {
                if (separate)
                {
                    appendString(separator);
                }
                AppendDescribable(describable);

                separate = true;
            }

            appendString(end);
            return this;
        }
    }
}
