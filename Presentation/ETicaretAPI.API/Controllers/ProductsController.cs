//using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories.ProductRepository;
using ETicaretAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository  _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {

            //Product p = await _productReadRepository.GetByIdAsync("91a1751a-4621-41a0-b60f-45309367f2e5",false);
            IQueryable< Product> p = _productReadRepository.GetAll();
            

            return Ok(p);
        }
        //[HttpGet]
        //public async Task Get()
        //{
        //    //await  _productWriteRepository.AddRangeAsync(new()
        //    //{
        //    //    new(){ Id=Guid.NewGuid(),Name="Product 1",CreatedDate=DateTime.UtcNow,Price=100,Stock=10},
        //    //    new(){ Id=Guid.NewGuid(),Name="Product 2",CreatedDate=DateTime.UtcNow,Price=200,Stock=20},
        //    //    new(){ Id=Guid.NewGuid(),Name="Product 3",CreatedDate=DateTime.UtcNow,Price=300,Stock=30}
        //    //});

        //    //await _productWriteRepository.SaveAsync();

        //    Product p = await _productReadRepository.GetByIdAsync("91a1751a-4621-41a0-b60f-45309367f2e5",false);
        //    p.Name = "Mehmet";
        //    await _productWriteRepository.SaveAsync();
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result=await _productReadRepository.GetByIdAsync(id);
            return Ok(result);
        }
    }
}
