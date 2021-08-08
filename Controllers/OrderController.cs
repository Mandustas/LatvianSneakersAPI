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
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get(int? Id = null)
        {
            var orders = _orderRepository.Get(Id);
            foreach (var order in orders)
            {
                foreach (var img in order.Images)
                {
                    img.Order = null;
                }
            }
            return Ok(orders);
        }

        [HttpGet("{id}", Name = "GetOrderById")]
        public ActionResult<Order> Get(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order != null)
            {
                return order;
            }
            return NotFound();
        }

        //[Authorize(Roles = "Координатор ПСР")]
        [Authorize]
        [HttpPost]
        public ActionResult<OrderCreateDTO> Create(OrderCreateDTO orderCreateDTO)
        {
            Order order = new Order();
            List<ImageOfOrder> imgs = new List<ImageOfOrder>();

            foreach (var img in orderCreateDTO.Images)
            {
                imgs.Add(new ImageOfOrder
                {
                    Path = img.Path,
                    IsVideo = img.IsVideo,
                });
            }
            order.Images = imgs;
            _orderRepository.Create(order);
            _orderRepository.SaveChanges();

            //var brandReadDto = _mapper.Map<Brand>(brand);

            return NoContent();

            //return CreatedAtRoute(nameof(Get), new { Id = brandReadDto.Id }, brandReadDto); //Return 201
        }

        [Authorize]
        [HttpPut("{id}")]
        ////[Authorize(Roles = "Координатор ПСР")]

        public ActionResult<Order> Update(int id, OrderCreateDTO orderCreateDTO)
        {
            var order = _orderRepository.GetWithImgsById(id);
            if (order == null)
            {
                return NotFound();
            }
            order.Images = null;
            List<ImageOfOrder> imgs = new List<ImageOfOrder>();

            foreach (var img in orderCreateDTO.Images)
            {
                imgs.Add(new ImageOfOrder
                {
                    Path = img.Path,
                    IsVideo = img.IsVideo,
                });
            }
            order.Images = imgs;

            _orderRepository.Update(order); //Best practice
            _orderRepository.SaveChanges();

            return NoContent();
        }

        ////[Authorize(Roles = "Координатор ПСР")]
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var order = _orderRepository.GetWithImgsById(id);
            if (order == null)
            {
                return NotFound();
            }

            _orderRepository.Delete(order);
            _orderRepository.SaveChanges();
            return NoContent();
        }
    }
}
