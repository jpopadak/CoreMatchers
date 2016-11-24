namespace JPopadak.CoreMatchers.Descriptions
{
    public class SelfDescribingValue<T> : IDescribable
    {
        private T value;

        public SelfDescribingValue(T value)
        {
            this.value = value;
        }

        public void Describe(IDescription description)
        {
            description.AppendValue(value);
        }
    }
}
