using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public interface IMatcher : IDescribable
    {
        bool Matches(object actual);

        void DescribeMismatch(object actual, IDescription description);
    }
}
