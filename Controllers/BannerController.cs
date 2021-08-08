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
    [Route("api/banner")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IMapper _mapper;

        public BannerController(
            IBannerRepository bannerRepository,
            IMapper mapper

            )
        {
            _bannerRepository = bannerRepository;
            _mapper = mapper;
        }


        // GET: api/<BrandController>
        [HttpGet]
        public ActionResult<IEnumerable<Banner>> Get()
        {
            var banners = _bannerRepository.Get();
            banners = banners.OrderBy(o => o.Order);
            return Ok(banners);
        }

        [HttpGet("{id}", Name = "GetBannerById")]
        public ActionResult<Banner> GetBannerById(int id)
        {
            var banner = _bannerRepository.GetById(id);
            if (banner != null)
            {
                return Ok(banner);
            }
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public ActionResult<BannerCreateAndUpdateDTO> Create(BannerCreateAndUpdateDTO bannerCreateAndUpdateDTO)
        {
            var banner = _mapper.Map<Banner>(bannerCreateAndUpdateDTO);
            _bannerRepository.Create(banner);
            _bannerRepository.SaveChanges();

            var bannerReadDto = _mapper.Map<Banner>(banner);


            return CreatedAtRoute(nameof(GetBannerById), new { Id = bannerReadDto.Id }, bannerReadDto); //Return 201
        }

        [Authorize]
        [HttpPut("{id}")]
        //[Authorize(Roles = "Координатор ПСР")]

        public ActionResult<Banner> Update(int id, BannerCreateAndUpdateDTO bannerCreateAndUpdateDTO)
        {
            var banner = _bannerRepository.GetById(id);
            if (banner == null)
            {
                return NotFound();
            }

            _mapper.Map(bannerCreateAndUpdateDTO, banner);
            _bannerRepository.Update(banner); //Best practice
            _bannerRepository.SaveChanges();

            return NoContent();
        }

        //[Authorize(Roles = "Координатор ПСР")]
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var banner = _bannerRepository.GetById(id);
            if (banner == null)
            {
                return NotFound();
            }

            _bannerRepository.Delete(banner);
            _bannerRepository.SaveChanges();
            return NoContent();
        }
    }
}
