using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Dynamic;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() { Id = Guid.NewGuid(), Name ="Product1", Price = 100, CreatedDate = DateTime.UtcNow, Stock =10 },
            //    new() { Id = Guid.NewGuid(), Name ="Product2", Price = 200, CreatedDate = DateTime.UtcNow, Stock =20 },
            //    new() { Id = Guid.NewGuid(), Name ="Product3", Price = 300, CreatedDate = DateTime.UtcNow, Stock =30 }
            //});
            //var count = await _productWriteRepository.SaveAsync();
            Product p = await _productReadRepository.GetByIdAsync("fcd732ae-eddc-4601-9054-e3fcc123bdc0");
            p.Name = "Ahmet";  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product =await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }




    }

}

