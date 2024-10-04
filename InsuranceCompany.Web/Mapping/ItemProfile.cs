using AutoMapper;
using InsuranceCompany.Domain.Models.Items;
using InsuranceCompany.Domain.UseCases.SaveProductUseCase;
using InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;
using InsuranceCompany.Web.Models.Item;

namespace InsuranceCompany.Web.Mapping;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<ItemBaseDto, CreateItemBaseCommand>();
        CreateMap<ItemComboBoxDto, CreateItemComboBoxCommand>()
            .IncludeBase<ItemBaseDto, CreateItemBaseCommand>();
        CreateMap<ItemInputBoxDto, CreateItemInputBoxCommand>()
            .IncludeBase<ItemBaseDto, CreateItemBaseCommand>();

        CreateMap<ItemBaseDto, UpdateItemBaseCommand>();
        CreateMap<ItemComboBoxDto, UpdateItemComboBoxCommand>()
            .IncludeBase<ItemBaseDto, UpdateItemBaseCommand>();
        CreateMap<ItemInputBoxDto, UpdateItemInputBoxCommand>()
            .IncludeBase<ItemBaseDto, UpdateItemBaseCommand>();

        CreateMap<Domain.Models.Items.ComboBoxValue, Models.Item.ComboBoxValue>();
        
        CreateMap<ItemBase,ItemBaseDto>();
        
        CreateMap<ItemComboBox,ItemComboBoxDto>()
            .IncludeBase<ItemBase,ItemBaseDto>();
        CreateMap<ItemInputBox, ItemInputBoxDto>()
            .IncludeBase<ItemBase, ItemBaseDto>();
    }
}