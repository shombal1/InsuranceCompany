using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Storage.Entities;

namespace InsuranceCompany.Storage.Mapping
{
    public class AgentProfile : Profile
    {
        public AgentProfile()
        {
            CreateMap<Agent, AgentEntity>();
            CreateMap<AgentEntity, Agent>();
        }
    }
}
