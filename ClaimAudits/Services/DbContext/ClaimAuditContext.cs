using Microsoft.EntityFrameworkCore;

namespace ClaimAudits.Services.DbContext
{
    public class ClaimAuditContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ClaimAuditContext(DbContextOptions<ClaimAuditContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Models.ClaimAudit> ClaimAudits { get; set; }
    }
}