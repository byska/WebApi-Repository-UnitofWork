using UnitofWorkGenericRepo.Core.IConfiguration;
using UnitofWorkGenericRepo.Core.IRepository;
using UnitofWorkGenericRepo.Core.Repository;

namespace UnitofWorkGenericRepo.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public ICategoryRepository Categories { get; }
        private DataContext context;
        private ILogger logger;
        public UnitOfWork(DataContext _context,ILoggerFactory _loggerFactory)
        {
            context=_context;
            logger=_loggerFactory.CreateLogger("ApplicationLogs");
            Categories = new CategoryRepository(context, logger);
        }
        public async Task ComplateAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
