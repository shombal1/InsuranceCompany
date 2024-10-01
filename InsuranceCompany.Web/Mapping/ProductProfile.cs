using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Web.Models;
using InsuranceCompany.Web.Models.Product;

namespace InsuranceCompany.Web.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(d => d.NameLob, s => s.MapFrom(f => f.NameLob));
    }
}