using InsuranceCompany.Domain.DependencyInjection;
using InsuranceCompany.Storage.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using InsuranceCompany.Web.Models.Item;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddInsuranceCompanyStorage(configuration.GetConnectionString("Postgres")!)
    .AddInsuranceCompanyDomain();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new ItemBaseDtoConverter());
    });

builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config => config.AddMaps(Assembly.GetExecutingAssembly()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

namespace InsuranceCompany.Web
{
    public partial class Program { }
}

