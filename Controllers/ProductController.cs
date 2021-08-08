using DataLayer.DTOs;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        public ActionResult<IEnumerable<Product>> Get([FromQuery] int[] sizes, int? BrandId = null, int? ModelId = null, int? Id = null)
        {
            var validSizes = new List<Size>();

            foreach (var size in sizes)
            {
                validSizes.Add(_sizeRepository.GetById(size));
            }
            var products = _productRepository.Get(validSizes, BrandId, ModelId, Id).ToList();

            foreach (var product in products)
            {
                foreach (var size in product.Sizes)
                {
                    size.Products = null;
                    size.ProductSizes = null;
                }
                foreach (var image in product.Images)
                {
                    image.Product = null;
                }
                product.Brand.Models = null;
                product.Brand.Products = null;
                product.Model.Products = null;
                product.Model.Brand = null;
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

        //[Authorize(Roles = "Координатор ПСР")]
        [Authorize]
        [HttpPost]
        public ActionResult<ProductCreateDTO> Create(ProductCreateDTO productCreateDTO)
        {
            Product product = new Product();
            List<Image> imgs = new List<Image>();
            List<ProductSize> productSizes = new List<ProductSize>();

            foreach (var img in productCreateDTO.Images)
            {
                imgs.Add(new Image
                {
                    Path = img
                });
            }

            foreach (var size in productCreateDTO.Sizes)
            {
                productSizes.Add(new ProductSize
                {
                    SizeId = size
                });
            }

            product.BrandId = productCreateDTO.BrandId;
            product.DateCreate = DateTime.Now;
            product.Discount = productCreateDTO.Discount;
            product.IsNew = productCreateDTO.IsNew;
            product.IsPopular = productCreateDTO.IsPopular;
            product.IsSale = productCreateDTO.IsSale;
            product.ModelId = productCreateDTO.ModelId;
            product.Price = productCreateDTO.Price;
            product.Title = productCreateDTO.Title;
            product.Images = imgs;
            product.ProductSizes = productSizes;

            _productRepository.Create(product);
            _productRepository.SaveChanges();


            return NoContent();
        }

        [Authorize]
        [HttpPut("{id}")]
        //[Authorize(Roles = "Координатор ПСР")]

        public ActionResult<Product> Update(int id, ProductCreateDTO productCreateDTO)
        {
            var product = _productRepository.GetWithSizesAndImagesById(id);
            if (product == null)
            {
                return NotFound();
            }
            product.Images = null;
            product.ProductSizes = null;

            List<Image> imgs = new List<Image>();
            List<ProductSize> productSizes = new List<ProductSize>();

            foreach (var img in productCreateDTO.Images)
            {
                imgs.Add(new Image
                {
                    Path = img
                });
            }

            foreach (var size in productCreateDTO.Sizes)
            {
                productSizes.Add(new ProductSize
                {
                    SizeId = size
                });
            }

            product.BrandId = productCreateDTO.BrandId;
            product.Discount = productCreateDTO.Discount;
            product.IsNew = productCreateDTO.IsNew;
            product.IsPopular = productCreateDTO.IsPopular;
            product.IsSale = productCreateDTO.IsSale;
            product.ModelId = productCreateDTO.ModelId;
            product.Price = productCreateDTO.Price;
            product.Title = productCreateDTO.Title;
            product.Images = imgs;
            product.ProductSizes = productSizes;

            _productRepository.Update(product); //Best practice
            _productRepository.SaveChanges();

            return NoContent();
        }

        ////[Authorize(Roles = "Координатор ПСР")]
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = _productRepository.GetWithSizesAndImagesById(id);
            if (product == null)
            {
                return NotFound();
            }

            _productRepository.Delete(product);
            _productRepository.SaveChanges();
            return NoContent();
        }
    }
}
