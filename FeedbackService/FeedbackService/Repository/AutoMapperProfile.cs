using AutoMapper;
using FeedbackService.Model;
using FeedbackService.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackService.Repository
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DoctorFeedbackDTO, DoctorFeedback>().ReverseMap();
            CreateMap<FacilityFeedbackDTO, FacilityFeedback>().ReverseMap();
        }
    }
}
