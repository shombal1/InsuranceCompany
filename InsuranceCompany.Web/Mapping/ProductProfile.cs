using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.Models.Items;
using InsuranceCompany.Domain.UseCases.SaveProductUseCase;
using InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;
using InsuranceCompany.Web.Models.Item;
using InsuranceCompany.Web.Models.Product;
using ComboBoxValue = InsuranceCompany.Domain.Models.Items.ComboBoxValue;

namespace InsuranceCompany.Web.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, GetProductDto>()
            .ForMember(d => d.NameLOB, s => s.MapFrom(f => f.NameLOB));

        CreateMap<ActiveProduct, GetActiveProductDto>();

        CreateMap<UpdateFullProductDto, UpdateFullProductCommand>()
            .ForMember(d=>d.ProductId,opt=>opt.Ignore());
        CreateMap<ProductRiskDto, UpdateProductRiskCommand>();
        CreateMap<SaveProductDto, SaveProductCommand>();
        CreateMap<ProductRiskDto, CreateProductRiskCommand>();
        CreateMap<Models.Item.ComboBoxValue, ComboBoxValue>();

        CreateMap<ProductRisk, ProductRiskDto>();
        
        CreateMap<FullProduct, GetFullProductDto>()
            .ForMember(d => d.NameLOB, s => s.MapFrom(f => f.NameLOB))
            .ForMember(d => d.Items, s => s.MapFrom(f => f.Items))
            .ForMember(d => d.Risks, s => s.MapFrom(f => f.Risks));

        CreateMap<EditProduct,EditProductDto>()
            .ForMember(d => d.Items, s => s.MapFrom(f => f.Items))
            .ForMember(d => d.Risks, s => s.MapFrom(f => f.Risks))
            .ForMember(d => d.LobsDto, s => s.MapFrom(f => f.LOBs));

    }
}