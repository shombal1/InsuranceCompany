using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.CreateContractUseCase;
using InsuranceCompany.Web.Models.Contract;

namespace InsuranceCompany.Web.Mapping
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<CreateContractDto, CreateContractCommand>();
            CreateMap<Contract, CreateContractDto>();

            CreateMap<Contract, GetContractDto>();
        }
    }
}
