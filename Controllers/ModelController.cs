using AutoMapper;
using DataLayer.DTOs;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LatvianSneakers.Controllers
{
    [Route("api/model")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public ModelController(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;

        }


        // GET: api/<BrandController>
        [HttpGet]
        public ActionResult<IEnumerable<Model>> Get(int? BrandId = null)
        {
            var models = _modelRepository.Get(BrandId);
            return Ok(models);
        }


        [HttpGet("{id}", Name = "GetModelById")]
        public ActionResult<Model> Get(int id)
        {
            var model = _modelRepository.GetById(id);
            if (model != null)
            {
                return model;
            }
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public ActionResult<ModelCreateDTO> Create(ModelCreateDTO modelCreateDTO)
        {
            var model = _mapper.Map<Model>(modelCreateDTO);
            _modelRepository.Create(model);
            _modelRepository.SaveChanges();

            //var brandReadDto = _mapper.Map<Brand>(brand);

            return NoContent();

            //return CreatedAtRoute(nameof(Get), new { Id = brandReadDto.Id }, brandReadDto); //Return 201
        }

        [Authorize]
        [HttpPut("{id}")]
        //[Authorize(Roles = "Координатор ПСР")]

        public ActionResult<Model> Update(int id, ModelUpdateDTO modelUpdateDTO)
        {
            var model = _modelRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            _mapper.Map(modelUpdateDTO, model);
            _modelRepository.Update(model); //Best practice
            _modelRepository.SaveChanges();

            return NoContent();
        }

        //[Authorize(Roles = "Координатор ПСР")]
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var model = _modelRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            _modelRepository.Delete(model);
            _modelRepository.SaveChanges();
            return NoContent();
        }
    }
    
}
