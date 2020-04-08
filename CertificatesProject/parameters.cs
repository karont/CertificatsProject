using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesProject
{
    class Parameters
    {
		private string emailfrom = System.Configuration.ConfigurationManager.AppSettings["emailfrom"];
		private string smtp = System.Configuration.ConfigurationManager.AppSettings["smtp"];
		private string smtpuser = System.Configuration.ConfigurationManager.AppSettings["smtpuser"];
		private string smtppassword = System.Configuration.ConfigurationManager.AppSettings["smtppassword"];
		private string mailpath = System.Configuration.ConfigurationManager.AppSettings["mailpath"];
		private string imgtwitterpath = System.Configuration.ConfigurationManager.AppSettings["imgtwitterpath"];
		private string imglinkedinpath = System.Configuration.ConfigurationManager.AppSettings["imglinkedinpath"];
		private string imgtecnoforpath = System.Configuration.ConfigurationManager.AppSettings["imgtecnoforpath"];

		private string pdfpath = System.Configuration.ConfigurationManager.AppSettings["pdfpath"];

		private string docpath = System.Configuration.ConfigurationManager.AppSettings["docpath"];

		private string templatepath_esp = System.Configuration.ConfigurationManager.AppSettings["template_esp"];

		private string templatepath_eng = System.Configuration.ConfigurationManager.AppSettings["template_eng"];

		private string csvpath = System.Configuration.ConfigurationManager.AppSettings["csvpath"];
		public string Emailfrom { get => emailfrom;}
		public string Smtp { get => smtp; }
		public string Smtpuser { get => smtpuser; }
		public string Smtppassword { get => smtppassword;}
		public string Mailpath { get => mailpath; }
		public string Imgtwitterpath { get => imgtwitterpath; }
		public string Imglinkedinpath { get => imglinkedinpath; }
		public string Imgtecnoforpath { get => imgtecnoforpath; }
		public string Pdfpath { get => pdfpath; }
		public string Docpath { get => docpath; }
		public string Templatepath_esp { get => templatepath_esp; }
		public string Templatepath_eng { get => templatepath_eng; }
		public string Csvpath { get => csvpath; }


		public Parameters()
		{
			string executingpath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

			Console.WriteLine(executingpath);
			emailfrom = System.Configuration.ConfigurationManager.AppSettings["emailfrom"];
			smtp = System.Configuration.ConfigurationManager.AppSettings["smtp"];
			smtpuser = System.Configuration.ConfigurationManager.AppSettings["smtpuser"];
			smtppassword = System.Configuration.ConfigurationManager.AppSettings["smtppassword"];
			mailpath = executingpath + @System.Configuration.ConfigurationManager.AppSettings["mailpath"];
			imgtwitterpath = executingpath + @System.Configuration.ConfigurationManager.AppSettings["imgtwitterpath"];
			imglinkedinpath = executingpath + @System.Configuration.ConfigurationManager.AppSettings["imglinkedinpath"];
			imgtecnoforpath = executingpath + @System.Configuration.ConfigurationManager.AppSettings["imgtecnoforpath"];

			pdfpath = executingpath +@System.Configuration.ConfigurationManager.AppSettings["pdfpath"];

			docpath = executingpath + @System.Configuration.ConfigurationManager.AppSettings["docpath"];

			templatepath_esp = executingpath + @System.Configuration.ConfigurationManager.AppSettings["template_esp"];

			templatepath_eng = executingpath + @System.Configuration.ConfigurationManager.AppSettings["template_eng"];

			csvpath = executingpath + @System.Configuration.ConfigurationManager.AppSettings["csvpath"];

	}

		
	}
}
