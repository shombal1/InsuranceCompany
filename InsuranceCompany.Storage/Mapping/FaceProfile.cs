using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Storage.Entities;

namespace InsuranceCompany.Storage.Mapping
{
    public class FaceProfile : Profile
    {
        public FaceProfile()
        {
            CreateMap<Face, FaceEntity>();
            CreateMap<FaceEntity, Face>();
        }
    }
}
