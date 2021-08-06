using AutoMapper;
using DataLayer.DTOs;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Profiles
{
    class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandCreateDTO>();
            CreateMap<BrandCreateDTO, Brand>();
        }
    }
}
