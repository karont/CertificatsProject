using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Utils;
using MailKit.Security;
using System.IO;

namespace CertificatesProject
{
     class MyMail
    {
		
		public bool send(Certificate certificate, string selectlanguage)
        {
			Parameters parameters = ParameterSingleton.Parameters;

			Console.WriteLine("Send Certificated...");
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Tecnofor", parameters.Emailfrom));
			message.To.Add(new MailboxAddress(certificate.Attributes["name"], certificate.Attributes["email"]));

			string subject = "";
			string mailpath = "";
			string certificatepath = "";

			switch(selectlanguage)
			{
				case "2":
					subject = certificate.Attributes["course"] + " - Attendance certificate";
					mailpath = parameters.Mailpath_eng;
					certificatepath = certificate.Certificatepathpdf_eng;
					break;
				case "1":
				default:
					subject = certificate.Attributes["course"] + " - Certificado de asistencia";
					mailpath = parameters.Mailpath;
					certificatepath = certificate.Certificatepathpdf_esp;
					break;
			}
			message.Subject = subject;
			var builder = new BodyBuilder();
			builder.HtmlBody = makeHTMLBody(certificate.Attributes["course"], builder, mailpath, parameters.Imgtecnoforpath, parameters.Imgtwitterpath, parameters.Imglinkedinpath);

			//builder.Attachments.Add(certificate.Certificatepathpdf_eng);
			builder.Attachments.Add(certificatepath);


			message.Body = builder.ToMessageBody();
			try
			{
				using (var client = new SmtpClient())
				{
					client.Connect(parameters.Smtp, 465, SecureSocketOptions.SslOnConnect);

					// Note: only needed if the SMTP server requires authentication
					client.Authenticate(@parameters.Smtpuser, @parameters.Smtppassword);

					client.Timeout = 60000;
					client.Send(message);
					client.Disconnect(true);
				}

				Console.WriteLine("Send");
				//File.Delete(certificate.Certificatepathpdf_eng);
				File.Delete(certificatepath);
				return true;
			}

			catch (Exception e)
			{

				Console.WriteLine("Error: "+e.Message);
				certificate.Sent = false;
				return false;

			}
			
			
        }


		private string makeHTMLBody(string course, BodyBuilder builder, string htmlFilePath, string pathtecnofor, string pathtwitter, string pathtlinkedin)
		{
			
			var imagetecnofor = builder.LinkedResources.Add(pathtecnofor);
			imagetecnofor.ContentId = MimeUtils.GenerateMessageId();

			;
			var imagetwitter = builder.LinkedResources.Add(pathtwitter);
			imagetwitter.ContentId = MimeUtils.GenerateMessageId();

			
			var imagelinkedinr = builder.LinkedResources.Add(pathtlinkedin);
			imagelinkedinr.ContentId = MimeUtils.GenerateMessageId();



			StringBuilder stb = new StringBuilder();


			stb.AppendFormat(File.ReadAllText(htmlFilePath), course, imagetwitter.ContentId, imagelinkedinr.ContentId, imagetecnofor.ContentId);

			//Console.WriteLine(stb.ToString());
			return stb.ToString();

		}
    }
}
