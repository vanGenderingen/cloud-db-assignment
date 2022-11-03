using System;

namespace cloud_databases_cvgen.Models
{
    internal class Mortage : Entity
    {
        public double MaximumMortage { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool SendMail { get; set; }

    }
}
