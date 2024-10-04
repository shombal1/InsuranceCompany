using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.CreateFaceUseCase;

namespace InsuranceCompany.Domain.Mapping
{
    public class FaceProfile : Profile
    {
        public FaceProfile()
        {
            CreateMap<CreateFaceCommand, Face>();
        }
    }
}
