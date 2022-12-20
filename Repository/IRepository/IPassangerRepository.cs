using PassengerApi.Models;
using System.Linq.Expressions;

namespace PassengerApi.Repository.IRepository
{
    public interface IPassengerRepository
    {
        Task<List<Passenger>> GetAllAsync(Expression<Func<Passenger, bool>> filter = null);
            
        Task<Passenger> GetByIdAsync(Expression<Func<Passenger, bool>> filter =null);

        Task CreateAsync(Passenger entity);
        Task UpdateAsync(Passenger entity);
        Task RemoveAsync(Passenger entity);
        Task SaveAsync();

    }
}
