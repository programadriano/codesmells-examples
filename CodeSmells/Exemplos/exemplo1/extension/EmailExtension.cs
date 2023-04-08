using System.Net.Mail;
using System.Text.RegularExpressions;

namespace CodeSmells.Exemplos.exemplo1.extension
{
    public static class EmailExtension
    {
        public static bool IsValid(this Email email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email.Value);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
