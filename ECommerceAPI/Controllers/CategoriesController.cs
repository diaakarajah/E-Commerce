using BusinessLayer.Unity;
using DataAccessLayer.Entity;
using ECommerceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _IUnitOfWork;

        public CategoriesController(IUnitOfWork IUnitOfWork)
        {
            _IUnitOfWork = IUnitOfWork;
                }
        [HttpGet]
        public List<Categories> GetAll()
        {
            var CategoriesList = _IUnitOfWork.categoriesRepo.GetAll().ToList();
            return CategoriesList;
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoriesDto categoriesDto)
        {
            var UserId = User.FindFirst("UserId").Value;

            Categories category = new Categories()
            {
                CategoryNameAr = categoriesDto.CategoryNameAr,
                CategoryNameEn = categoriesDto.CategoryNameEn,
                CreatedDate = DateTime.Now,
                CreatedBy = Convert.ToInt32(UserId),
            };
            _IUnitOfWork.categoriesRepo.Create(category);
            _IUnitOfWork.Complete();
            return Ok(category);
        }
        [HttpPost, DisableRequestSizeLimit]
        [Route("Upload")]
        public IActionResult Upload()
        {
            try
            {
                HttpRequest formData = HttpContext.Request;
                var file = Request.Form.Files[0];
                var categoryId = Convert.ToInt32(HttpContext.Request.Form["RefId"]);
                var folderName = Path.Combine("Resources", "Category");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    var category = _IUnitOfWork.categoriesRepo.GetByID(categoryId);
                    category.ImagePath = dbPath;
                    _IUnitOfWork.Complete();
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
