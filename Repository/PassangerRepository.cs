using Microsoft.EntityFrameworkCore;
using PassangerApi.DataContext;
using PassangerApi.Models;
using PassangerApi.Repository.IRepository;
using System.Linq.Expressions;

namespace PassangerApi.Repository
{
    public class PassangerRepository : IPassangerRepository
    {
        private readonly PassangerDbContext _db;
        
        public PassangerRepository(PassangerDbContext db)
        {
            this._db = db;
           
        }

        public async Task CreateAsync(Passanger entity)
        {
            await _db.Passangers.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<Passanger>> GetAllAsync(Expression<Func<Passanger, bool>> filter = null)
        {
            IQueryable<Passanger> query = _db.Passangers;
            if(filter !=null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<Passanger> GetByIdAsync(Expression<Func<Passanger, bool>> filter = null)
        {
            IQueryable<Passanger> query = _db.Passangers;
            if(filter!=null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(Passanger entity)
        {
            _db.Passangers.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();   
        }

        public async Task UpdateAsync(Passanger entity)
        {
            _db.Passangers.Update(entity);
            await SaveAsync();
        }
    }
}
