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
    [Route("api/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }


        // GET: api/<BrandController>
        [HttpGet]
        public ActionResult<IEnumerable<Brand>> Get()
        {
            var brands = _brandRepository.Get();
            return Ok(brands);
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}", Name = "GetBrandById")]
        public ActionResult<Brand> Get(int id)
        {
            var brand = _brandRepository.GetById(id);
            if (brand != null)
            {
                return brand;
            }
            return NotFound();
        }

        // POST api/<BrandController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BrandController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
