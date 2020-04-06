using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace CertificatesProject
{
    static class SendMail
    {
		static private string emailfrom = System.Configuration.ConfigurationManager.AppSettings["emailfrom"];
		static private string smtp = System.Configuration.ConfigurationManager.AppSettings["smtp"];
		static private string smtpuser = System.Configuration.ConfigurationManager.AppSettings["smtpuser"];
		static private string smtppassword = System.Configuration.ConfigurationManager.AppSettings["smtppassword"];
		public static bool send(Certificate certificate)
        {
			Console.WriteLine("Send Certificated...");
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Tecnofor", emailfrom));
			message.To.Add(new MailboxAddress(certificate.Name, certificate.Email));
			message.Subject = "Certificate";

			var builder = new BodyBuilder();


			builder.TextBody =  @"Your certificate";

			builder.Attachments.Add(certificate.Certificatepathpdf_eng);
			builder.Attachments.Add(certificate.Certificatepathpdf_esp);

			message.Body = builder.ToMessageBody();
			try
			{
				using (var client = new SmtpClient())
				{
					client.Connect(smtp, 587, false);

					// Note: only needed if the SMTP server requires authentication
					client.Authenticate(smtpuser, smtppassword);

					client.Send(message);
					client.Disconnect(true);
				}

				Console.WriteLine("Send");
				return true;
			}

			catch (Exception e)
			{

				Console.WriteLine("Error: "+e.Message);
				return false;

			}
			
			
        }
    }
}
