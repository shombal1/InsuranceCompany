namespace InsuranceCompany.Domain.UseCases.SaveProductUseCase;

public record CreateProductRiskCommand(string Name,string Key,decimal? Premium,decimal? InsuranceSum,bool Active);