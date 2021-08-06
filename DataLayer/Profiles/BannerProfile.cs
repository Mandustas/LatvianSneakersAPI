using AutoMapper;
using DataLayer.DTOs;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Profiles
{
    class BannerProfile : Profile
    {
        public BannerProfile()
        {
            CreateMap<Banner, BannerCreateAndUpdateDTO>();
            CreateMap<BannerCreateAndUpdateDTO, Banner>();
        }
    }
}
