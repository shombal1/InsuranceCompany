using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Web.Models;

namespace InsuranceCompany.Web.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(d => d.Name, s => s.MapFrom(f => f.Name));
    }
}