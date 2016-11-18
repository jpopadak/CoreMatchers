using System;
using System.Collections.Generic;
using System.Text;

namespace JPopadak.CoreMatchers.Descriptions
{
    public class Description : IDescription
    {
        private StringBuilder builder = new StringBuilder();

        public IDescription AppendText(string text)
        {
            append(text);
            return this;
        }

        public IDescription AppendList(string before, string separator, string after, params IDescribable[] args)
        {
            return appendList(before, separator, after, args);
        }

        public IDescription AppendValue(object value)
        {
            if (value == null)
            {
                AppendText("null");
            }
            else if (value is string)
            {
                escapeValue((string)value);
            }
            else if (value is char)
            {
                append('"');
                escapeValue((char)value);
                append('"');
            }
            else if (value is short)
            {
                append("<");
                append(Convert.ToString(value));
                append("s>");
            }
            else if (value is long)
            {
                append("<");
                append(Convert.ToString(value));
                append("L>");
            }
            else if (value is float)
            {
                append("<");
                append(Convert.ToString(value));
                append("F>");
            }
            else
            {
                AppendText("<");
                AppendText(value.ToString());
                AppendText(">");
            }
            return this;
        }

        public IDescription AppendDescribable(IDescribable describable)
        {
            describable.Describe(this);
            return this;
        }

        protected void append(string value)
        {
            builder.Append(value);
        }

        protected void append(char value)
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

            append(start);
            foreach (IDescribable describable in describables)
            {
                if (separate)
                {
                    append(separator);
                }
                AppendDescribable(describable);

                separate = true;
            }

            append(end);
            return this;
        }

        private void escapeValue(string value)
        {
            append('"');
            forEach(value, escapeValue);
            append('"');
        }

        /// <summary>
        /// Outputs to buffer a escaped version of special chars
        /// </summary>
        private void escapeValue(char value)
        {
            switch (value)
            {
                case '"':
                    append("\\\"");
                    break;
                case '\n':
                    append("\\n");
                    break;
                case '\r':
                    append("\\r");
                    break;
                case '\t':
                    append("\\t");
                    break;
                case '\\':
                    append("\\\\");
                    break;
                default:
                    append(value);
                    break;
            }
        }

        private void forEach<T>(IEnumerable<T> enumerable, Action<T> function)
        {
            foreach (T value in enumerable)
            {
                function(value);
            }
        }
    }
}
