namespace InsuranceCompany.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string NameLOB { get; set; }
    public bool Active { get; set; }
    public string Formula { get; set; } 
}