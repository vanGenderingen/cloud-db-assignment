using System;

namespace cloud_databases_cvgen.Models
{
    public class Mortage : Entity
    {
        public double MaximumMortage { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool MailSent { get; set; }
    }
}
