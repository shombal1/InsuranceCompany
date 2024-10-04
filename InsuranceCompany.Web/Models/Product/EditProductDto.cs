using InsuranceCompany.Domain.Models;
using InsuranceCompany.Web.Models.Agent;
using InsuranceCompany.Web.Models.Item;

namespace InsuranceCompany.Web.Models.Product;

public class EditProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }
    public string NameLOB { get; set; }
    public int LOBId { get; set; }
    
    public List<ItemBaseDto> Items { get; set; }
    public List<ProductRiskDto> Risks { get; set; }
    public List<LOBDto> LobsDto { get; set; }
    public List<GetAgentDto> AgentsDto { get; set; }
    
    public string Formula { get; set; }
}