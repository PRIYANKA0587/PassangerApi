using PassangerApi.Models;
using System.Linq.Expressions;

namespace PassangerApi.Repository.IRepository
{
    public interface IPassangerRepository
    {
        Task<List<Passanger>> GetAllAsync(Expression<Func<Passanger, bool>> filter = null);
            
        Task<Passanger> GetByIdAsync(Expression<Func<Passanger, bool>> filter =null);

        Task CreateAsync(Passanger entity);
        Task UpdateAsync(Passanger entity);
        Task RemoveAsync(Passanger entity);
        Task SaveAsync();

    }
}
