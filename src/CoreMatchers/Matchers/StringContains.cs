namespace JPopadak.CoreMatchers.Matchers
{
    public class StringContains : SubStringMatcher
    {
        public StringContains(bool ignoringCase, string substring) 
            : base("containing", ignoringCase, substring)
        {
            // Do Nothing
        }

        protected override bool evalSubstringOf(string arg)
        {
            return converted(arg).Contains(converted(_substring));
        }
    }
}
