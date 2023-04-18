using System.Linq.Expressions;

namespace UnitofWorkGenericRepo.Core.IRepository
{
    public interface IGenericRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<bool> Add(T entity);
        Task<bool> Delete(int id);
        Task<bool> Update(T entity);
        Task<IEnumerable<T>> Find(Expression<Func<T,bool>> prop);
    }
}
