using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LatvianSneakers.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ISizeRepository _sizeRepository;

        public ProductController(
            IProductRepository productRepository,
            ISizeRepository sizeRepository
            )
        {
            _productRepository = productRepository;
            _sizeRepository = sizeRepository;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get([FromQuery] int[] sizes, int? BrandId = null, int? ModelId = null, bool? isNew = null, bool? PriceOrder = null)
        {
            var validSizes = new List<Size>();

            foreach (var size in sizes)
            {
                validSizes.Add(_sizeRepository.GetById(size));
            }
            var products = _productRepository.Get(validSizes, BrandId, ModelId, isNew, PriceOrder).ToList();

            foreach (var product in products)
            {
                foreach (var size in product.Sizes)
                {
                    size.Products = null;
                    size.ProductSizes = null;
                }
                product.ProductSizes = null;
            }

            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}", Name = "GetOperationById")]
        public ActionResult<Product> Get(int id)
        {
            var product = _productRepository.GetById(id);
            if (product != null)
            {
                return product;
            }
            return NotFound();
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
