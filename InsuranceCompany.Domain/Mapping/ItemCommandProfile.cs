using AutoMapper;
using InsuranceCompany.Domain.Models.Items;
using InsuranceCompany.Domain.UseCases.SaveProductUseCase;

namespace InsuranceCompany.Domain.Mapping;

public class ItemCommandProfile : Profile
{
    public ItemCommandProfile()
    {
        CreateMap<ItemBaseCommand, ItemBase>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
        
        CreateMap<ItemComboBoxCommand, ItemComboBox>()
            .IncludeBase<ItemBaseCommand, ItemBase>();
        
        CreateMap<ItemInputBoxCommand, ItemInputBox>()
            .IncludeBase<ItemBaseCommand, ItemBase>();
    }
}