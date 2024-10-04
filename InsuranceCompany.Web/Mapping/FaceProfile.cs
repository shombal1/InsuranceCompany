using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.CreateFaceUseCase;
using InsuranceCompany.Web.Models.Face;

namespace InsuranceCompany.Web.Mapping
{
    public class FaceProfile : Profile
    {
        public FaceProfile()
        {
            CreateMap<CreateFaceDto, CreateFaceCommand>();

            CreateMap<Face, GetFaceDto>();
        }
    }
}
