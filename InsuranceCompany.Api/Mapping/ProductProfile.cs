using AutoMapper;
using InsuranceCompany.Api.Models;
using InsuranceCompany.Domain.Models;

namespace InsuranceCompany.Api.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(d => d.Name, s => s.MapFrom(f => f.Name));
    }
}