namespace cloud_databases_cvgen.Models.DTO
{
    public class MortageResponseDTO
    {
        public double MaximumMortgage { get; set; }

        public DateTime ExpiresAt { get; set; }
        public bool MailSend { get; set; }
    }
}
