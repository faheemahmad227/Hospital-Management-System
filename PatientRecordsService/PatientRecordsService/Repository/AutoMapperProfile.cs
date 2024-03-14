using AutoMapper;
using PatientRecordsService.DTO;
using PatientRecordsService.Models;

namespace PatientRecordsService.Repository
{
    public class AutoMapperProfile  :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PatientTreatmentDetailsDTO, PatientTreatmentDetails>().ReverseMap();
            CreateMap<TestRecordDTO, TestRecord>().ReverseMap();
        }
    }
}
