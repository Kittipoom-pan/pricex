using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;
        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public async Task SendEmailAsync(Message message)
        {
            //var emailMessage = CreateEmailMessage(message);
            var emailMessage = EmailMessage(message);

            await SendAsync(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.Add(MailboxAddress.Parse(message.To));
            // send multiple 
            //emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            //emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { 
                Text = string.Format("<html>" +
                                     "<head> " +
                                         "<meta http - equiv = \"Content-Type\" content = \"text/html; charset=utf-8\" > " +
                                     "</head> " +
                                     "<b>Template :</b> {1} <br>"+
                                     "{0} " +              
                                     "</html> "
                                    , message.Content, message.Template) };

            return emailMessage;
        }

        private MimeMessage EmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            // send multiple 
            emailMessage.To.AddRange(message.ToMutiple);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = string.Format("<html>" +
                                     "<head> " +
                                         "<meta http - equiv = \"Content-Type\" content = \"text/html; charset=utf-8\" > " +
                                     "</head> " +
                                     "<b>Template :</b> {1} <br>" +
                                     "{0} " +
                                     "</html> "
                                    , message.Content, message.Template)
            };

            return emailMessage;
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
