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
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _IUnitOfWork;
        public ProductsController(IUnitOfWork IUnitOfWork)
        {
            _IUnitOfWork = IUnitOfWork;
        }
        [HttpGet]
        public List<Products> GetAll()
        {
            var ProductsList = _IUnitOfWork.productsRepo.GetProductsList();
            return ProductsList;
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductsDto productsDto)
        {
            var UserId = User.FindFirst("UserId").Value;

            Products product = new Products()
            {
                ProductNameAr = productsDto.ProductNameAr,
                ProductNameEn = productsDto.ProductNameEn,
                CreatedDate = DateTime.Now,
                CreatedBy = Convert.ToInt32(UserId),
                //  ImagePath = dbPath,
                BrandId = productsDto.BrandId,
                CategoryId = productsDto.CategoryId,
                Description = productsDto.Description,
                Price = productsDto.Price,
                Quantity = productsDto.Quantity,
            };
            _IUnitOfWork.productsRepo.Create(product);
            _IUnitOfWork.Complete();
            return Ok(product);
        }
        [HttpPost, DisableRequestSizeLimit]
        [Route("Upload")]
        public IActionResult Upload()
        {
            try
            {
                HttpRequest formData = HttpContext.Request;
                var file = Request.Form.Files[0];
                var productId = Convert.ToInt32(HttpContext.Request.Form["RefId"]);
                var folderName = Path.Combine("Resources", "Products");
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

                    var product = _IUnitOfWork.productsRepo.GetByID(productId);
                    product.ImagePath = dbPath;
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
