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
        
        public void Run()
        {

            Console.WriteLine("Starting app");

            Parameters parameter = ParameterSingleton.Parameters;
            List<Certificate> listcertificates = CsvCertificate.readCsv(parameter.Csvpath);

            List<Certificate> listcertificatesfails = new List<Certificate>();
            MyMail mail = new MyMail();
            PdfCertificate pdfcertificate = new PdfCertificate();
            foreach (Certificate certificate in listcertificates)
            {
                Console.WriteLine("############################");
                Console.WriteLine("New certificated");
                Console.WriteLine(certificate.ToString());

                pdfcertificate.createCertificate(certificate);
                

                if(certificate.Certificatepathpdf_esp != "")
                {
                    mail.send(certificate);

                }
                

                if (!certificate.Sent) listcertificatesfails.Add(certificate);
                Console.WriteLine("############################");
            }

            foreach(Certificate certificatefail in listcertificatesfails)
            {
                Console.WriteLine("Fail List");
                Console.WriteLine("----"+certificatefail.Name);
            }
            Console.WriteLine("Finish app, presh any key to close");
            Console.ReadLine();
          
        }
    }
}
