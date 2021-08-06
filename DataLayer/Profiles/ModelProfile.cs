using AutoMapper;
using DataLayer.DTOs;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Profiles
{
    class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Model, ModelCreateDTO>();
            CreateMap<ModelCreateDTO, Model>();
            CreateMap<ModelUpdateDTO, Model>();
        }
    }
}
