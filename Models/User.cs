using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloud_databases_cvgen.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public double AnnualIncome { get; set; }
        public int LoanTerm { get; set; }
        public Mortage Mortage { get; set; }
    }
}
