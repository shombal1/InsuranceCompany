using System.Reflection;
using FluentValidation;
using InsuranceCompany.Domain.Monitoring;
using InsuranceCompany.Domain.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceCompany.Domain.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInsuranceCompanyDomain(this IServiceCollection services)
    {
        services
            .AddMediatR(cfg => cfg
                .AddOpenBehavior(typeof(MonitoringPipelineBehavior<,>))
                .RegisterServicesFromAssemblyContaining<IUnitOfWork>());
        
        services.AddAutoMapper(config => 
            config.AddMaps(Assembly.GetAssembly(typeof(IUnitOfWork))));

        
        services.AddValidatorsFromAssemblyContaining<IUnitOfWork>(includeInternalTypes: true);
        
        return services;
    }
}