namespace JPopadak.CoreMatchers.Matchers
{
    public class StringStartsWith : SubStringMatcher
    {
        public StringStartsWith(bool ignoringCase, string substring)
            : base("starting with", ignoringCase, substring)
        {
            // Do Nothing
        }

        protected override bool evalSubstringOf(string arg)
        {
            return converted(arg).StartsWith(converted(_substring));
        }
    }
}
