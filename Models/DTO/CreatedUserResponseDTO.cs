using System;

namespace cloud_databases_cvgen.Models.DTO
{
    public class CreatedUserResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double AnnualIncome { get; set; }
        public int LoanTerm { get; set; }
    }
}
