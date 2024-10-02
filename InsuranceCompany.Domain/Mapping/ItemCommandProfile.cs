using AutoMapper;
using InsuranceCompany.Domain.Models.Items;
using InsuranceCompany.Domain.UseCases.SaveProductUseCase;

namespace InsuranceCompany.Domain.Mapping;

public class ItemCommandProfile : Profile
{
    public ItemCommandProfile()
    {
        CreateMap<ItemBaseCommand, ItemBase>();
        
        CreateMap<ItemComboBoxCommand, ItemComboBox>()
            .IncludeBase<ItemBaseCommand, ItemBase>();
        
        CreateMap<ItemInputBoxCommand, ItemInputBox>()
            .IncludeBase<ItemBaseCommand, ItemBase>();
    }
}