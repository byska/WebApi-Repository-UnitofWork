using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UnitofWorkGenericRepo.Core.IRepository;
using UnitofWorkGenericRepo.Data;

namespace UnitofWorkGenericRepo.Core.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public DataContext context;
        public DbSet<T> dbset;
        public ILogger logger;

        public GenericRepository(DataContext _context, ILogger logger)
        {
            context = _context;
            dbset = context.Set<T>();
            this.logger = logger;
        }

        public async Task<bool> Add(T entity)
        {
            await dbset.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> Delete(int id)
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> prop)
        {
           return await dbset.Where(prop).ToListAsync();
        }

        public virtual Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(int id)
        {
            return await dbset.FindAsync(id);
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();

        }
    }
}
