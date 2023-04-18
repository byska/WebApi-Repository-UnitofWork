using UnitofWorkGenericRepo.Core.IRepository;
using UnitofWorkGenericRepo.Data;
using UnitofWorkGenericRepo.Model;

namespace UnitofWorkGenericRepo.Core.Repository
{
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(DataContext _context,ILogger _logger):base (_context,_logger)
        {

        }
        public override async Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                return dbset.ToList();
            }
            catch(Exception ex) 
            { 
                logger.LogError(ex,"Category Repo GetAll method error",typeof(CategoryRepository));
                return new List<Category>();    
            }

        }
        public override async Task<bool> Update(Category entity)
        {
            try
            {
                Category category = dbset.Where(x => x.Id.Equals(entity.Id)).FirstOrDefault();
                if (category == null)
                {
                    return await Add(entity);
                   
                }
                category.CategoryName = entity.CategoryName;
                category.Description = entity.Description;
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Category Repo Update method error", typeof(CategoryRepository));
                return false;
               
            }
        }
        public override async Task<bool> Delete(int id)
        {
            try
            {
                Category category = dbset.Where(x => x.Id == id).FirstOrDefault();
                if(category == null)
                {
                    return false;
                }
                dbset.Remove(category);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex,"category repo category delete method error",typeof(CategoryRepository));
                return false;
            }
        }
    }
}
