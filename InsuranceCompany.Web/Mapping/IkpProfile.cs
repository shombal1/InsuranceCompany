using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.CreateIkpUseCase;
using InsuranceCompany.Web.Models.Ikp;

namespace InsuranceCompany.Web.Mapping
{
    public class IkpProfile : Profile
    {
        public IkpProfile()
        {
            CreateMap<CreateIkpDto, CreateIkpCommand>();

            CreateMap<Ikp, GetIkpDto>();
        }
    }
}
