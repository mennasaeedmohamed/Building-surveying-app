﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Building.Dtos;
using Building.Models.Models;

namespace Building.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BuildingDto, Buildings>().ReverseMap();
          
        }

    }
}
