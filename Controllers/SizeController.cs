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
    [Route("api/size")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISizeRepository _sizeRepository;
        public SizeController(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }
        // GET: api/<SizeController>
        [HttpGet]
        public ActionResult<IEnumerable<Size>> Get()
        {
            var sizes = _sizeRepository.Get();
            return Ok(sizes);
        }

        // GET api/<SizeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SizeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SizeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SizeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
