using DataLayer.Models;
using DataLayer.Repositories;
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

        public ModelController(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }


        // GET: api/<BrandController>
        [HttpGet]
        public ActionResult<IEnumerable<Model>> Get()
        {
            var models = _modelRepository.Get();
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
    }
    
}
