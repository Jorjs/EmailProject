using System.Runtime.Intrinsics.X86;
using MailKit.Security;

namespace EmailProject.EmailInfo
{
    public class EmailSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Template { get; set; }
        public string Subject { get; set; }
        public string SendEmail { get; set; }
        public string SSP { get; set; }
        public SecureSocketOptions SecureSocketOption
        {
            get
            {
                return SSP switch
                {
                    "none" => SecureSocketOptions.None,
                    "ssl" => SecureSocketOptions.SslOnConnect,
                    "starttls" => SecureSocketOptions.StartTls,
                    _ => SecureSocketOptions.Auto
                };
            }
        }
    }
}
