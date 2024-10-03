namespace InsuranceCompany.Web.Models.Product;

public class GetProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string NameLOB { get; set; }
    public bool Active { get; set; }
}