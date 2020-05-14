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

            Console.WriteLine("Select certificate language:");
            Console.WriteLine("1 -> Spanish");
            Console.WriteLine("2 -> English");

            string selectlanguage = Console.ReadLine();

            switch (selectlanguage)
            {
                case "2":
                    Console.WriteLine("English selected");
                    break;

                case "1":
                default:
                    Console.WriteLine("Spanish selected");
                    break;
            }

            

            Parameters parameter = ParameterSingleton.Parameters;
            List<Certificate> listcertificatesfails = new List<Certificate>();
            List<Certificate> listcertificates = CsvCertificate.readCsv(parameter.Csvpath);

           
            if(listcertificates.Count >= 1)
            {
                MyMail mail = new MyMail();
                PdfCertificate pdfcertificate = new PdfCertificate();
                foreach (Certificate certificate in listcertificates)
                {
                    Console.WriteLine("############################");
                    Console.WriteLine("New certificated");
                    Console.WriteLine(certificate.ToString());

                    pdfcertificate.createCertificate(certificate, selectlanguage);


                    if (certificate.Certificatepathpdf_esp != null && certificate.Certificatepathpdf_esp != "")
                    {
                        mail.send(certificate, selectlanguage);

                    }

                    if (certificate.Certificatepathpdf_eng != null &&  certificate.Certificatepathpdf_eng != "")
                    {
                        mail.send(certificate, selectlanguage);

                    }


                    if (!certificate.Sent) listcertificatesfails.Add(certificate);
                    Console.WriteLine("############################");
                }

                Console.WriteLine("Fail List - Retry send ");
                foreach (Certificate certificatefail in listcertificatesfails)
                {


                    Console.WriteLine("----" + certificatefail.Name);

                    if (certificatefail.Certificatepathpdf_esp != null &&  certificatefail.Certificatepathpdf_esp != "")
                    {
                        certificatefail.Sent = true;
                        mail.send(certificatefail, selectlanguage);

                        if (certificatefail.Sent) listcertificatesfails.Remove(certificatefail);

                    }

                    if (certificatefail.Certificatepathpdf_eng != null && certificatefail.Certificatepathpdf_eng != "")
                    {
                        certificatefail.Sent = true;
                        mail.send(certificatefail, selectlanguage);

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
                Console.WriteLine("name | course | modality | dateini | dateend | hours | email");
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
