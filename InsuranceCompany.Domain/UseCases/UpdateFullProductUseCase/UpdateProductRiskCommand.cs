namespace InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;

public record UpdateProductRiskCommand(string Name,string Key,decimal? Premium,decimal? InsuranceSum,bool Active);