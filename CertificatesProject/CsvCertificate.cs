using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace CertificatesProject
{
    static class CsvCertificate
    {

        public static List<Certificate> readCsv(string path)
        {
            bool fistrow = true;
            List<Certificate> list = new List<Certificate>();
            Certificate certificate;
            using (var reader = new StreamReader(path))
            {

                CultureInfo mycultureinfotesp = new CultureInfo("es-ES");
                
                while (!reader.EndOfStream)
                {
                    if(fistrow)
                    {
                        var line = reader.ReadLine();
                        fistrow = false;
                    }

                    else
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        certificate = new Certificate();
                        certificate.Name = (String)values[0];
                        certificate.Course = (String)values[1];
                        certificate.Modality = (String)values[2];
                        certificate.Dateini = DateTime.Parse((String)values[3], mycultureinfotesp);
                        certificate.Dateend = DateTime.Parse((String)values[4], mycultureinfotesp);
                        certificate.Hours = (String)values[5];
                        certificate.Date = DateTime.Parse((String)values[6], mycultureinfotesp);
                        certificate.Email = (String)values[7];

                        list.Add(certificate);
                    }
                    
                }

            }

            return list;
        }
    }
}
