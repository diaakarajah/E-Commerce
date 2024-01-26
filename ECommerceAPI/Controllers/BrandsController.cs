using BusinessLayer.Unity;
using DataAccessLayer.Entity;
using ECommerceAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IUnitOfWork _IUnitOfWork;

        public BrandsController(IUnitOfWork UnitOfWork)
        {
            _IUnitOfWork = UnitOfWork;
        }
        [HttpGet]
        [Authorize]
        public List<Brands> GetAll()
        {
            var BrandList = _IUnitOfWork.brandRepo.GetAll().ToList();
            return BrandList;
        }
        [HttpPost]

        public IActionResult CreateBrand([FromBody] BrandsDto brandsDto)
        {
            var UserId = User.FindFirst("UserId").Value;


            Brands barand = new Brands()
            {
                BrandNameAr = brandsDto.BrandNameAr,
                BrandNameEn = brandsDto.BrandNameEn,
                CreatedDate = DateTime.Now,
                CreatedBy = Convert.ToInt32(UserId)
        };
        _IUnitOfWork.brandRepo.Create(barand);
            _IUnitOfWork.Complete();
            return Ok(barand);
    }
        [HttpPost, DisableRequestSizeLimit]
        [Route("Upload")]
        public IActionResult Upload()
        {
            try
            {
                HttpRequest formData = HttpContext.Request;
                var file = Request.Form.Files[0];
                var brandId =Convert.ToInt32(HttpContext.Request.Form["RefId"]);
                var folderName = Path.Combine("Resources", "Brands");
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

                   var brand= _IUnitOfWork.brandRepo.GetByID(brandId);
                    brand.ImagePath = dbPath;
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
