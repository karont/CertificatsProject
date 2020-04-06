using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.Configuration;
namespace CertificatesProject
{
    class Aplication
    {

        private string pdfpath = System.Configuration.ConfigurationManager.AppSettings["pdfpath"];

        private string templatepath_esp = System.Configuration.ConfigurationManager.AppSettings["template_esp"];

        private string templatepath_eng = System.Configuration.ConfigurationManager.AppSettings["template_eng"];

        private string csvpath = System.Configuration.ConfigurationManager.AppSettings["csvpath"];
        public void Run()
        {


            Console.WriteLine("Starting app");

            List<Certificate> listcertificates = CsvCertificate.readCsv(@csvpath);

            foreach (Certificate certificate in listcertificates)
            {
                DocCertificate.createCertificate(@templatepath_esp, @templatepath_eng, @pdfpath, certificate);
                Console.WriteLine(certificate.ToString());
                SendMail.send(certificate);
            }
          
        }
    }
}
