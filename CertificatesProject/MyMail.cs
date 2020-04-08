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
		
		public bool send(Certificate certificate)
        {
			Parameters parameters = ParameterSingleton.Parameters;

			Console.WriteLine("Send Certificated...");
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Tecnofor", parameters.Emailfrom));
			message.To.Add(new MailboxAddress(certificate.Name, certificate.Email));
			message.Subject = "Certificate";

			var builder = new BodyBuilder();

			//StringBuilder stb = new StringBuilder();

			//stb.AppendLine("Estimado alumno,");
			//stb.AppendLine("Tecnofor tiene el placer de enviarle adjunto a este email su Certificado de asistencia al curso ");
			//stb.AppendFormat("<b>{0}</b>",certificate.Course);
			//stb.AppendLine("¡Esperamos volver a verle pronto en nuestras formaciones!");
			//stb.AppendLine("Saludos");




			builder.HtmlBody = makeHTMLBody(certificate.Course, builder, parameters);

			//builder.Attachments.Add(certificate.Certificatepathpdf_eng);
			builder.Attachments.Add(certificate.Certificatepathpdf_esp);

			message.Body = builder.ToMessageBody();
			try
			{
				using (var client = new SmtpClient())
				{
					client.Connect(parameters.Smtp, 587, SecureSocketOptions.StartTls);

					// Note: only needed if the SMTP server requires authentication
					client.Authenticate(parameters.Smtpuser, parameters.Smtppassword);

					client.Send(message);
					client.Disconnect(true);
				}

				Console.WriteLine("Send");
				//File.Delete(certificate.Certificatepathpdf_eng);
				File.Delete(certificate.Certificatepathpdf_esp);
				return true;
			}

			catch (Exception e)
			{

				Console.WriteLine("Error: "+e.Message);
				certificate.Sent = false;
				return false;

			}
			
			
        }


		private string makeHTMLBody(string course, BodyBuilder builder, Parameters parameters)
		{
			string htmlFilePath = parameters.Mailpath;

			var pathtecnofor = parameters.Imgtecnoforpath;
			var imagetecnofor = builder.LinkedResources.Add(pathtecnofor);
			imagetecnofor.ContentId = MimeUtils.GenerateMessageId();

			var pathtwitter = parameters.Imgtwitterpath;
			var imagetwitter = builder.LinkedResources.Add(pathtwitter);
			imagetwitter.ContentId = MimeUtils.GenerateMessageId();

			var pathtlinkedin = parameters.Imglinkedinpath;
			var imagelinkedinr = builder.LinkedResources.Add(pathtlinkedin);
			imagelinkedinr.ContentId = MimeUtils.GenerateMessageId();



			StringBuilder stb = new StringBuilder();


			stb.AppendFormat(File.ReadAllText(htmlFilePath), course, imagetwitter.ContentId, imagelinkedinr.ContentId, imagetecnofor.ContentId);

			//Console.WriteLine(stb.ToString());
			return stb.ToString();

		}
    }
}
