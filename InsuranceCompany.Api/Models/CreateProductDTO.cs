namespace InsuranceCompany.Api.Models;

public class CreateProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public LobDto Lob { get; set; }
}