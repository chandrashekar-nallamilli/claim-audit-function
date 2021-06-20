using System;
using System.Threading.Tasks;
using ClaimAudits.Models;
using ClaimAudits.Services.DbContext;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ClaimAudits.Services.Functions
{
    public class ClaimAuditFunction
    {
        private readonly ClaimAuditContext _claimAuditContext;

        public ClaimAuditFunction(ClaimAuditContext claimAuditContext)
        {
            _claimAuditContext = claimAuditContext;
        }
        [FunctionName("ClaimAudits")]
        public async Task Run([ServiceBusTrigger("claims-queue", Connection = "ClaimsQueueConnection")] string myQueueItem, ILogger log)
        {
            try
            {
                var claimAudit = JsonConvert.DeserializeObject<ClaimAudit>(myQueueItem);
                claimAudit.ClaimId = claimAudit.Id;
                claimAudit.Id = Guid.NewGuid();
                await _claimAuditContext.ClaimAudits.AddAsync(claimAudit);
                await _claimAuditContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                log.LogError(e.Message);
                throw;
            }
        }
    }
}
