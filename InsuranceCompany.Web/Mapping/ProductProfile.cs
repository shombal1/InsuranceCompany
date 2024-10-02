using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.SaveProductUseCase;
using InsuranceCompany.Web.Models.Product;
using ComboBoxValue = InsuranceCompany.Domain.Models.Items.ComboBoxValue;

namespace InsuranceCompany.Web.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(d => d.NameLob, s => s.MapFrom(f => f.NameLob));

        CreateMap<SaveProductDto, SaveProductCommand>();
        CreateMap<ProductRiskDto, ProductRiskCommand>();
        CreateMap<Models.Item.ComboBoxValue, ComboBoxValue>();
    }
}