using System.Reflection;
using InsuranceCompany.Domain.UseCases;
using InsuranceCompany.Domain.UseCases.CreateProductUseCase;
using InsuranceCompany.Domain.UseCases.EditProductUseCase;
using InsuranceCompany.Domain.UseCases.GetActiveProductsUseCase;
using InsuranceCompany.Domain.UseCases.GetProductsUseCase;
using InsuranceCompany.Domain.UseCases.SaveProductUseCase;
using InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;
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
            .AddScoped<IGetProductsStorage, GetProductsStorage>()
            .AddScoped<IGetLobsStorage,GetLobsStorage>()
            .AddScoped<ICreateItemStorage,CreateItemStorage>()
            .AddScoped<ICreateProductRiskStorage,CreateProductRiskStorage>()
            .AddScoped<ICreateProductStorage,CreateProductStorage>()
            .AddScoped<IGetFullProduct,GetFullProduct>()
            .AddScoped<IGetActiveProductsStorage,GetActiveProductsStorage>()
            .AddScoped<IGetIdItemsStorage,GetIdItemsStorage>()
            .AddScoped<IUpdateProductStorage,UpdateProductStorage>()
            .AddScoped<IDeleteItemStorage,DeleteItemStorage>()
            .AddScoped<IDeleteProductRiskStorage,DeleteProductRiskStorage>();
        
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