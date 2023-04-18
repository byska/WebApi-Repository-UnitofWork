using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitofWorkGenericRepo.Core.IConfiguration;
using UnitofWorkGenericRepo.Model;

namespace UnitofWorkGenericRepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        private ILogger<CategoryController> logger;


        public CategoryController(IUnitOfWork _unitOfWork, ILogger<CategoryController> _logger)
        {
            unitOfWork = _unitOfWork;
            logger = _logger;
        }
        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IActionResult> GetAll()
        {
            var allCategories = await unitOfWork.Categories.GetAll();
            return Ok(allCategories);
        }
        [HttpGet]
        [Route("GetCategory/{categoryid}")]
        public async Task<IActionResult> GetCategoryItem(int categoryid)
        {
            Category category = await unitOfWork.Categories.GetById(categoryid);
            if (category == null)
               return NotFound();
            return Ok(category);
        }
        [HttpPost]
        [Route("CreateNewCategory")]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.Categories.Add(category);
                await unitOfWork.ComplateAsync();
                return CreatedAtAction("GetCategoryItem", new {categoryid= category.Id }, category);
            }
            return new JsonResult("Get AN Error Creating New Category") { StatusCode = 500 };
        }
        [HttpPut]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> Update(int id,Category category)
        {
            if(id!=category.Id)
                return BadRequest();
            await unitOfWork.Categories.Update(category);
            await unitOfWork.ComplateAsync();
            return NoContent();
        }
    }
}
