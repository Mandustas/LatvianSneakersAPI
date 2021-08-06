using AutoMapper;
using DataLayer.DTOs;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Profiles
{
    class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewCreateDTO>();
            CreateMap<ReviewCreateDTO, Review>();
        }
    }
}
