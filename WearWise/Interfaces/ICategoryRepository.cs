
using WearWise.Models;

namespace WearWise.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(Category category);
    }
}
