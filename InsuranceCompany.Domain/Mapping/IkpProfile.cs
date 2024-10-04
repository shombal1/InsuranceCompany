using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.CreateIkpUseCase;

namespace InsuranceCompany.Domain.Mapping
{
    public class IkpProfile : Profile
    {
        public IkpProfile()
        {
            CreateMap<CreateIkpCommand, Ikp>();
        }
    }
}
