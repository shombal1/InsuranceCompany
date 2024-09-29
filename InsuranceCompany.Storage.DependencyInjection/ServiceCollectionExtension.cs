using System.Reflection;
using InsuranceCompany.Domain.UseCases;
using InsuranceCompany.Domain.UseCases.CreateProduct;
using InsuranceCompany.Storage.Storages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceCompany.Storage.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInsuranceCompanyStorage(this IServiceCollection services,string dbConnectionStringPostgres)
    {
        services
            .AddScoped<ICreateProductStorage, CreateProductStorage>();
        
        services.AddDbContextPool<InsuranceCompanyDbContext>(
            options => { options.UseNpgsql(dbConnectionStringPostgres); });

        services.AddAutoMapper(config => 
            config.AddMaps(Assembly.GetAssembly(typeof(InsuranceCompanyDbContext))));
        
        services.AddSingleton(TimeProvider.System);
        services.AddSingleton<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}