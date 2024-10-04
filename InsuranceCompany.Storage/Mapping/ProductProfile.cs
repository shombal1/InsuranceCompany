using System.Text.Json;
using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.Models.Items;
using InsuranceCompany.Storage.Entities;
using InsuranceCompany.Storage.Enums;

namespace InsuranceCompany.Storage.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductEntity, Product>()
            .ForMember(d => d.NameLOB, s => s.MapFrom(f => f.LOB.Name));

        CreateMap<ProductEntity, ActiveProduct>()
            .ForMember(d => d.NameLOB, s => s.MapFrom(f => f.LOB.Name));

        CreateMap<ProductEntity, FullProduct>()
            .ForMember(d => d.NameLOB, s => s.MapFrom(f => f.LOB.Name))
            .ForMember(d=>d.LOBId,s=>s.MapFrom(f=>f.LOBId))
            .ForMember(d => d.Risks, s => s.MapFrom(f => f.ProductRisks))
            .ForMember(d => d.Items, s => s.MapFrom(f => f.ProductMetafield));

        
        CreateMap<ProductRiskEntity, ProductRisk>();

        CreateMap<ProductMetafieldEntity, ItemBase>()
            .ConvertUsing(src => ConvertToItemBase(src));
        
    }
    
    private static ItemBase ConvertToItemBase(ProductMetafieldEntity src)
    {
        return (src.Type switch
        {
            ProductMetafieldType.ComboBox => JsonSerializer.Deserialize<ItemComboBox>(src.JsonData),
            ProductMetafieldType.InputBox => JsonSerializer.Deserialize<ItemInputBox>(src.JsonData),
            _ => throw new InvalidOperationException($"Unknown ProductMetafieldType: {src.Type}")
        })!;
    }
}