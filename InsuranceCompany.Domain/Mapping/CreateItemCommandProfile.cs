using AutoMapper;
using InsuranceCompany.Domain.Models.Items;
using InsuranceCompany.Domain.UseCases.SaveProductUseCase;

namespace InsuranceCompany.Domain.Mapping;

public class CreateItemCommandProfile : Profile
{
    public CreateItemCommandProfile()
    {
        CreateMap<CreateItemBaseCommand, ItemBase>()
            .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type));
        
        CreateMap<CreateItemComboBoxCommand, ItemComboBox>()
            .IncludeBase<CreateItemBaseCommand, ItemBase>();
        
        CreateMap<CreateItemInputBoxCommand, ItemInputBox>()
            .IncludeBase<CreateItemBaseCommand, ItemBase>();
    }
}