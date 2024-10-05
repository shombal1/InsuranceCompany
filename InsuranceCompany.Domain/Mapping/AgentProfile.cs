using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.CreateAgentUseCase;

namespace InsuranceCompany.Domain.Mapping
{
    public class AgentProfile : Profile
    {
        public AgentProfile()
        {
            CreateMap<CreateAgentCommand, Agent>();
        }
    }
}
