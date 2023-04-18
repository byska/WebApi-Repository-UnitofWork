using Microsoft.EntityFrameworkCore;
using UnitofWorkGenericRepo.Model;

namespace UnitofWorkGenericRepo.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
