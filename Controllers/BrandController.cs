using AutoMapper;
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
    [Route("api/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        

        public BrandController(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
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

        //[Authorize(Roles = "Координатор ПСР")]
        [Authorize]
        [HttpPost]
        public ActionResult<BrandCreateDTO> Create(BrandCreateDTO brandCreateDTO)
        {
            var brand = _mapper.Map<Brand>(brandCreateDTO);
            _brandRepository.Create(brand);
            _brandRepository.SaveChanges();

            //var brandReadDto = _mapper.Map<Brand>(brand);

            return NoContent();

            //return CreatedAtRoute(nameof(Get), new { Id = brandReadDto.Id }, brandReadDto); //Return 201
        }

        [Authorize]
        [HttpPut("{id}")]
        //[Authorize(Roles = "Координатор ПСР")]

        public ActionResult<Brand> Update(int id, BrandCreateDTO brandCreateDTO)
        {
            var brand = _brandRepository.GetById(id);
            if (brand == null)
            {
                return NotFound();
            }

            _mapper.Map(brandCreateDTO, brand);
            _brandRepository.Update(brand); //Best practice
            _brandRepository.SaveChanges();

            return NoContent();
        }

        //[Authorize(Roles = "Координатор ПСР")]
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var brand = _brandRepository.GetById(id);
            if (brand == null)
            {
                return NotFound();
            }

            _brandRepository.Delete(brand);
            _brandRepository.SaveChanges();
            return NoContent();
        }
    }
}
