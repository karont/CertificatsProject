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
            using (var reader = new StreamReader(path,Encoding.Default))
            {

                CultureInfo mycultureinfotesp = new CultureInfo("es-ES");

                List<string> firstrow = new List<string>();
                while (!reader.EndOfStream)
                {
                    if(fistrow)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');


                        firstrow = setFirstRow(values);
                        fistrow = false;
 
                    }

                    else
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        if(((String)values[0]) != "")
                        {
                            certificate = new Certificate();
                            int i = 0;
                            foreach (string value in values)
                            {
                                certificate.Attributes.Add(firstrow[i],value);
                                i++;
                            }
                            //certificate.Name = (String)values[0];
                            //certificate.Course = (String)values[1];
                            //certificate.Modality = (String)values[2];
                            //certificate.Dateini = DateTime.Parse((String)values[3], mycultureinfotesp);
                            //certificate.Dateend = DateTime.Parse((String)values[4], mycultureinfotesp);
                            //certificate.Hours = (String)values[5];
                            //certificate.Date = DateTime.Parse((String)values[4], mycultureinfotesp);
                            //certificate.Email = (String)values[6];
                            list.Add(certificate);
                        }
                        
                    }
                    
                }

            }

            return list;
        }

        private static List<string> setFirstRow(string[] values)
        {
            List<string> firstrow = new List<string>();

            foreach(string value in values)
            {
                firstrow.Add(value.ToLower());
            }

            return firstrow;
        }
        private static bool checkFirstRow (string[] values)
        {

            if ((String)values[0].ToLower() != "name")
                return false;

            if ((String)values[1].ToLower() != "course")
                return false;

            if ((String)values[2].ToLower() != "modality")
                return false;

            if ((String)values[3].ToLower() != "dateini")
                return false;

            if ((String)values[4].ToLower() != "dateend")
                return false;

            if ((String)values[5].ToLower() != "hours")
                return false;

            //if ((String)values[6].ToLower() != "date")
            //    return false;

            if ((String)values[6].ToLower() != "email")
                return false;



            return true;
        }
    }
}
