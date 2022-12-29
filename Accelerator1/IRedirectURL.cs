using Accelerator1.Model;

namespace Accelerator1
{
    public interface IRedirectURL
    {
        void Get(string shortUrlInput, AcceleratorContext _dbcontext);
        void Create(string website, AcceleratorContext _dbcontext);
    }
}
