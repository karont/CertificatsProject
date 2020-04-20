using System;
using System.Collections.Generic;
using System.IO;
namespace CertificatesProject
{
    class Aplication
    {
        
        public void Run()
        {

            Console.WriteLine("Starting app");

            Parameters parameter = ParameterSingleton.Parameters;
            List<Certificate> listcertificatesfails = new List<Certificate>();
            List<Certificate> listcertificates = CsvCertificate.readCsv(parameter.Csvpath);

            PdfSI
            if(listcertificates.Count >= 1)
            {
                MyMail mail = new MyMail();
                PdfCertificate pdfcertificate = new PdfCertificate();
                foreach (Certificate certificate in listcertificates)
                {
                    Console.WriteLine("############################");
                    Console.WriteLine("New certificated");
                    Console.WriteLine(certificate.ToString());

                    pdfcertificate.createCertificate(certificate);


                    if (certificate.Certificatepathpdf_esp != "")
                    {
                        mail.send(certificate);

                    }


                    if (!certificate.Sent) listcertificatesfails.Add(certificate);
                    Console.WriteLine("############################");
                }

                Console.WriteLine("Fail List - Retry send ");
                foreach (Certificate certificatefail in listcertificatesfails)
                {


                    Console.WriteLine("----" + certificatefail.Name);

                    if (certificatefail.Certificatepathpdf_esp != "")
                    {
                        certificatefail.Sent = true;
                        mail.send(certificatefail);

                        if (certificatefail.Sent) listcertificatesfails.Remove(certificatefail);

                    }
                }
                Console.WriteLine("Fail List");
                foreach (Certificate certificatefail in listcertificatesfails)
                {


                    Console.WriteLine("----" + certificatefail.Name);

                }
            }

            else
            {
                Console.WriteLine("There are errors in the input csv format!! The correct format is:");
                Console.WriteLine("");
                Console.WriteLine("name | course | modality | dateini | dateend | hours | date | email");
                Console.WriteLine("");
            }

            
            

            Console.WriteLine("Finish app, presh any key to close");
            Console.ReadLine();
            //var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            //standardOutput.AutoFlush = true;
            //Console.SetOut(standardOutput);
        }
    }
}
