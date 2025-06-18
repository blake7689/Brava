using Brava.Interfaces;
using System.Net;
using System.Net.Mail;

public class SmtpEmailService : IEmailService
{
    public void Send(string to, string subject, string body)
    {
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("bravanutrients@gmail.com", "wgwo vqlf hilj auew"),
            EnableSsl = true,
        };

        var mail = new MailMessage
        {
            From = new MailAddress("bravanutrients@gmail.com"),
            Subject = subject,
            Body = body,
            IsBodyHtml = false
        };

        mail.To.Add(to);
        smtpClient.Send(mail);
    }
}
