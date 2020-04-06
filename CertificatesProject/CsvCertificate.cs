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
            List<Certificate> list = new List<Certificate>();
            Certificate certificate;
            using (var reader = new StreamReader(path))
            {

                CultureInfo mycultureinfotesp = new CultureInfo("es-ES");
                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    certificate = new Certificate();
                    certificate.Name = (String)values[0];
                    certificate.Course = (String)values[1];
                    certificate.Dateini = DateTime.Parse((String)values[2], mycultureinfotesp);
                    certificate.Dateend = DateTime.Parse((String)values[3], mycultureinfotesp);
                    certificate.Hours = (String)values[4];
                    certificate.Date = DateTime.Parse((String)values[5], mycultureinfotesp);
                    certificate.Email = (String)values[6];

                    list.Add(certificate);
                }

            }

            return list;
        }
    }
}
