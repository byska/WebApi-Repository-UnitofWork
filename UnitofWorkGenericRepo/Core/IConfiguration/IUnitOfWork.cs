using UnitofWorkGenericRepo.Core.IRepository;

namespace UnitofWorkGenericRepo.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        Task ComplateAsync();
    }
}
