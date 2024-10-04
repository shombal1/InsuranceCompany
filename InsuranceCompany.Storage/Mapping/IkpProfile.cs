using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Storage.Entities;

namespace InsuranceCompany.Storage.Mapping
{
    public class IkpProfile : Profile
    {
        public IkpProfile()
        {
            CreateMap<Ikp, IKPEntity>();
            CreateMap<IKPEntity, Ikp>();
        }
    }
}
