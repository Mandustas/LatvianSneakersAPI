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
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Review>> Get()
        {
            var reviews = _reviewRepository.Get();
            return Ok(reviews);
        }

        [HttpGet("{id}", Name = "GetReviewById")]
        public ActionResult<Review> Get(int id)
        {
            var review = _reviewRepository.GetById(id);
            if (review != null)
            {
                return review;
            }
            return NotFound();
        }

        //[Authorize(Roles = "Координатор ПСР")]
        [Authorize]
        [HttpPost]
        public ActionResult<ReviewCreateDTO> Create(ReviewCreateDTO reviewCreateDTO)
        {
            var review = _mapper.Map<Review>(reviewCreateDTO);
            _reviewRepository.Create(review);
            _reviewRepository.SaveChanges();

            //var brandReadDto = _mapper.Map<Brand>(brand);

            return NoContent();

            //return CreatedAtRoute(nameof(Get), new { Id = brandReadDto.Id }, brandReadDto); //Return 201
        }

        [Authorize]
        [HttpPut("{id}")]
        //[Authorize(Roles = "Координатор ПСР")]

        public ActionResult<Review> Update(int id, ReviewCreateDTO reviewCreateDTO)
        {
            var review = _reviewRepository.GetById(id);
            if (review == null)
            {
                return NotFound();
            }

            _mapper.Map(reviewCreateDTO, review);
            _reviewRepository.Update(review); //Best practice
            _reviewRepository.SaveChanges();

            return NoContent();
        }

        //[Authorize(Roles = "Координатор ПСР")]
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var review = _reviewRepository.GetById(id);
            if (review == null)
            {
                return NotFound();
            }

            _reviewRepository.Delete(review);
            _reviewRepository.SaveChanges();
            return NoContent();
        }
    }
}
