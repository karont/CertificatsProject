using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesProject
{
    class Parameters
    {
		private string emailfrom;
		private string smtp;
		private string smtpuser;
		private string smtppassword;
		private string mailpath;
		private string mailpath_eng;
		private string imgtwitterpath;
		private string imglinkedinpath;
		private string imgtecnoforpath;

		private string pdfpath;

		private string docpath;

		private string templatepath_esp;

		private string templatepath_eng;

		private string csvpath;

		private string log;

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
		public string Log { get => log; }
		public string Mailpath_eng { get => mailpath_eng; }

		public Parameters()
		{
			string executingpath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

			Console.WriteLine(executingpath);
			emailfrom = System.Configuration.ConfigurationManager.AppSettings["emailfrom"];
			smtp = System.Configuration.ConfigurationManager.AppSettings["smtp"];
			smtpuser = System.Configuration.ConfigurationManager.AppSettings["smtpuser"];
			smtppassword = System.Configuration.ConfigurationManager.AppSettings["smtppassword"];
			mailpath = executingpath + @System.Configuration.ConfigurationManager.AppSettings["mailpath"];
			mailpath_eng = executingpath + @System.Configuration.ConfigurationManager.AppSettings["mailpatheng"];
			imgtwitterpath = executingpath + @System.Configuration.ConfigurationManager.AppSettings["imgtwitterpath"];
			imglinkedinpath = executingpath + @System.Configuration.ConfigurationManager.AppSettings["imglinkedinpath"];
			imgtecnoforpath = executingpath + @System.Configuration.ConfigurationManager.AppSettings["imgtecnoforpath"];

			pdfpath = executingpath +@System.Configuration.ConfigurationManager.AppSettings["pdfpath"];

			docpath = executingpath + @System.Configuration.ConfigurationManager.AppSettings["docpath"];

			templatepath_esp = executingpath + @System.Configuration.ConfigurationManager.AppSettings["template_esp"];

			templatepath_eng = executingpath + @System.Configuration.ConfigurationManager.AppSettings["template_eng"];

			csvpath = executingpath + @System.Configuration.ConfigurationManager.AppSettings["csvpath"];
			log = executingpath + @System.Configuration.ConfigurationManager.AppSettings["outputlog"];

		}

		
	}
}
