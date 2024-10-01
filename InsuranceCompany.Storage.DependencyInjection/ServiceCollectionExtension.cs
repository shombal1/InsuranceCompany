using System.Reflection;
using InsuranceCompany.Domain.UseCases;
using InsuranceCompany.Domain.UseCases.CreateProduct;
using InsuranceCompany.Storage.Storages;
using Microsoft.AspNetCore.Identity;
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

        services.AddDbContextPool<AuthenticationDbContext>(
            options => { options.UseNpgsql(dbConnectionStringPostgres); });

        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<AuthenticationDbContext>();

        services.AddAutoMapper(config => 
            config.AddMaps(Assembly.GetAssembly(typeof(InsuranceCompanyDbContext))));
        
        services.AddSingleton(TimeProvider.System);
        services.AddSingleton<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}