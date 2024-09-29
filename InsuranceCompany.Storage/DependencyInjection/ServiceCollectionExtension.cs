using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceCompany.Storage.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInsuranceCompanyStorage(this IServiceCollection service,string dbConnectionStringPostgres)
    {
        service.AddDbContextPool<InsuranceCompanyDbContext>(
            options => { options.UseNpgsql(dbConnectionStringPostgres); });

        service.AddAutoMapper(config => 
            config.AddMaps(Assembly.GetAssembly(typeof(InsuranceCompanyDbContext))));
        
        service.AddSingleton(TimeProvider.System);
        
        return service;
    }
}