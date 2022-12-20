using Microsoft.EntityFrameworkCore;
using PassengerApi.DataContext;
using PassengerApi.Models;
using PassengerApi.Repository.IRepository;
using System.Linq.Expressions;

namespace PassengerApi.Repository
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly PassengerDbContext _db;
        
        public PassengerRepository(PassengerDbContext db)
        {
            this._db = db;
           
        }

        public async Task CreateAsync(Passenger entity)
        {
            await _db.Passengers.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<Passenger>> GetAllAsync(Expression<Func<Passenger, bool>> filter = null)
        {
            IQueryable<Passenger> query = _db.Passengers;
            if(filter !=null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<Passenger> GetByIdAsync(Expression<Func<Passenger, bool>> filter = null)
        {
            IQueryable<Passenger> query = _db.Passengers;
            if(filter!=null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(Passenger entity)
        {
            _db.Passengers.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();   
        }

        public async Task UpdateAsync(Passenger entity)
        {
            _db.Passengers.Update(entity);
            await SaveAsync();
        }
    }
}
