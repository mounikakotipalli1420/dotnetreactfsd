using System;
using System.Net;
using System.Net.Mail;

namespace FeedBackAppA.Services
{
    public class EmailSender
    {
        public void SendEmail(string toAddress, string subject, string body)
        {
            try
            {
                // Set up the SMTP client
                using (SmtpClient smtpClient = new SmtpClient("your-smtp-server.com"))
                {
                    smtpClient.Port = 587; // Specify the SMTP port (e.g., 587 for Gmail)
                    smtpClient.Credentials = new NetworkCredential("your-email@example.com", "your-email-password");
                    smtpClient.EnableSsl = true; // Enable SSL for secure connections

                    // Create the email message
                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress("your-email@example.com");
                        mailMessage.To.Add(toAddress);
                        mailMessage.Subject = subject;
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true; // Set to true if the body is in HTML format

                        // Send the email
                        smtpClient.Send(mailMessage);
                    }
                }

                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}