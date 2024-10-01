using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using InsuranceCompany.Storage;
using Microsoft.AspNetCore.Identity;

namespace InsuranceCompany.Web.Data
{
    public class ApplicationDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseNpgsql("Host=localhost;User Id=admin;Password=admin;Database=INSURANCE_COMPANY;Port=5432");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
