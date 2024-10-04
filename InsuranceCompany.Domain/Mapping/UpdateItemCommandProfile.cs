using AutoMapper;
using InsuranceCompany.Domain.Models.Items;
using InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;

namespace InsuranceCompany.Domain.Mapping;

public class UpdateItemCommandProfile : Profile
{
    public UpdateItemCommandProfile()
    {
        CreateMap<UpdateItemBaseCommand, ItemBase>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
        
        CreateMap<UpdateItemComboBoxCommand, ItemComboBox>()
            .IncludeBase<UpdateItemBaseCommand, ItemBase>();
        
        CreateMap<UpdateItemInputBoxCommand, ItemInputBox>()
            .IncludeBase<UpdateItemBaseCommand, ItemBase>();
    }
}