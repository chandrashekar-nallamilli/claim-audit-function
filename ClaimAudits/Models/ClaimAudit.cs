using System;

namespace ClaimAudits.Models
{
    public class ClaimAudit
    {
        public Guid Id { get; set; }
        public Guid ClaimId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public decimal DamageCost { get; set; }
    }
}