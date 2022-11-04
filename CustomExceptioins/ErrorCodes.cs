
namespace cloud_databases_cvgen.CustomExceptioins
{
    public class ErrorCodes
    {
        public static class MortgageExpired
        {
            public static string Key => "MortgageExpired";
            public static string Value => "The mortgage has been expired";
        }

        public static class MailNotSend
        {
            public static string Key => "MailNotSend";
            public static string Value => "The email couldn't be send.";
        }

        public static class NoMortageForUser
        {
            public static string Key => "NoMortage";
            public static string Value => "This user has no mortage";
        }
    }
}
