using FluentValidation;
using InsuranceCompany.Domain.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceCompany.Domain.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInsuranceCompanyDomain(this IServiceCollection services)
    {
        services
            .AddMediatR(cfg => cfg
                .RegisterServicesFromAssemblyContaining<IUnitOfWork>());
        
        services.AddValidatorsFromAssemblyContaining<IUnitOfWork>(includeInternalTypes: true);
        
        return services;
    }
}