using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.CreateAgentUseCase;
using InsuranceCompany.Web.Models.Agent;

namespace InsuranceCompany.Web.Mapping
{
    public class AgentProfile : Profile
    {
        public AgentProfile()
        {
            CreateMap<CreateAgentDto, CreateAgentCommand>();

            CreateMap<Agent, CreateAgentDto>();
            CreateMap<Agent, GetAgentDto>();
        }
    }
}
