using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Storage.Entities;

namespace InsuranceCompany.Storage.Mapping;

public class LobProfile : Profile
{
    public LobProfile()
    {
        CreateMap<LOBEntity, LOB>();
    }
}