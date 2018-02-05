namespace JPopadak.CoreMatchers.Descriptions
{
    public class SelfDescribingValue<T> : IDescribable
    {
        private readonly T value;

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
