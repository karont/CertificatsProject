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

            MyMail mail = new MyMail();
            PdfCertificate pdfcertificate = new PdfCertificate();
            foreach (Certificate certificate in listcertificates)
            {
                pdfcertificate.createCertificate(certificate);
                Console.WriteLine(certificate.ToString());
                mail.send(certificate);
            }

            Console.WriteLine("Finish app, presh any key to close");
            Console.ReadLine();
          
        }
    }
}
