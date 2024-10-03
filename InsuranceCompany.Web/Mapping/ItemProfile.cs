using AutoMapper;
using InsuranceCompany.Domain.Models.Items;
using InsuranceCompany.Domain.UseCases.SaveProductUseCase;
using InsuranceCompany.Web.Models.Item;
using InsuranceCompany.Web.Models.Product;

namespace InsuranceCompany.Web.Mapping;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<ItemBaseDto, ItemBaseCommand>();
        CreateMap<ItemComboBoxDto, ItemComboBoxCommand>()
            .IncludeBase<ItemBaseDto, ItemBaseCommand>();
        CreateMap<ItemInputBoxDto, ItemInputBoxCommand>()
            .IncludeBase<ItemBaseDto, ItemBaseCommand>();


        CreateMap<Domain.Models.Items.ComboBoxValue, Models.Item.ComboBoxValue>();
        
        CreateMap<ItemBase,ItemBaseDto>();
        
        CreateMap<ItemComboBox,ItemComboBoxDto>()
            .IncludeBase<ItemBase,ItemBaseDto>();
        CreateMap<ItemInputBox, ItemInputBoxDto>()
            .IncludeBase<ItemBase, ItemBaseDto>();
    }
}