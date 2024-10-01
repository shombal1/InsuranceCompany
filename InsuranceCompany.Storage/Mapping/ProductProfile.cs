using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Storage.Entities;

namespace InsuranceCompany.Storage.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductEntity, Product>()
            .ForMember(d => d.Id, s => s.MapFrom(f => f.Id))
            .ForMember(d => d.Name, s => s.MapFrom(f => f.Name))
            .ForMember(d => d.Description, s => s.MapFrom(f => f.Description))
            .ForMember(d => d.NameLob, s => s.MapFrom(f => f.LOB.Name));
    }
}