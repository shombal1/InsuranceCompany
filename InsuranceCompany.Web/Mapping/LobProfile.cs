using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Web.Models;

namespace InsuranceCompany.Web.Mapping;

public class LobProfile : Profile
{
    public LobProfile()
    {
        CreateMap<LOB, LOBDto>();   
    }
}