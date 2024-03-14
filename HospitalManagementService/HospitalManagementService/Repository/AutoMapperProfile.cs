using AutoMapper;
using HospitalManagementService.Models;
using HospitalManagementService.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementService.Repository
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<HospitalDTO, Hospital>().ReverseMap();
            CreateMap<FacilityDTO, Facility>().ReverseMap();
        }
    }
}
