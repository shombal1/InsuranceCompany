using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Storage.Entities;

namespace InsuranceCompany.Storage.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductEntity, Product>()
            .ForMember(d => d.Name, s => s.MapFrom(f => f.Name));
    }
}