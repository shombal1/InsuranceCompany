namespace InsuranceCompany.Domain.UseCases.SaveProductUseCase;

public record ProductRiskCommand(string Name,string Key,decimal? Premium,decimal? InsuranceSum,bool Active);