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
    [Route("api/banner")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IBannerRepository _bannerRepository;

        public BannerController(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }


        // GET: api/<BrandController>
        [HttpGet]
        public ActionResult<IEnumerable<Banner>> Get()
        {
            var banners = _bannerRepository.Get();
            banners = banners.OrderBy(o => o.Order);
            return Ok(banners);
        }
    }
}
