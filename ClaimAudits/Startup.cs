using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using ClaimAudits;
using ClaimAudits.Services.DbContext;

[assembly: FunctionsStartup(typeof(Startup))]
namespace ClaimAudits
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string SqlConnection = Environment.GetEnvironmentVariable("SqlConnectionString");
            Console.WriteLine("SqlConnectionString : "+SqlConnection);
            builder.Services.AddDbContext<ClaimAuditContext>(x => x.UseSqlServer(SqlConnection));
        }
    }

    public class ClaimAuditContextFactory : IDesignTimeDbContextFactory<ClaimAuditContext>
    {
        public ClaimAuditContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ClaimAuditContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));

            return new ClaimAuditContext(optionsBuilder.Options);
        }
    }
}
