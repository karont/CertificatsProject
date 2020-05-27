using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesProject
{
    class Certificate
    {
        //private string name;

        //private string course;

        //private DateTime dateini;

        //private DateTime dateend;

        //private string hours;

        //private DateTime date;

        //private string email;

        //private string modality;


        private string certificatepathpdf_eng;

        private string certificatepathpdf_esp;

        private bool sent = true;
        private Dictionary<string, string> attributes = new Dictionary<string, string>();

        public Dictionary<string, string> Attributes { get => attributes; set => attributes = value; }
        //public string Name { get => name; set => name = value; }
        //public string Course { get => course; set => course = value; }
        //public DateTime Dateini { get => dateini; set => dateini = value; }
        //public DateTime Dateend { get => dateend; set => dateend = value; }
        //public string Hours { get => hours; set => hours = value; }
        //public DateTime Date { get => date; set => date = value; }
        //public string Modality { get => modality; set => modality = value; }
        //public string Email { get => email; set => email = value; }
        public string Certificatepathpdf_eng { get => certificatepathpdf_eng; set => certificatepathpdf_eng = value; }
        public string Certificatepathpdf_esp { get => certificatepathpdf_esp; set => certificatepathpdf_esp = value; }
        
        public bool Sent { get => sent; set => sent = value; }

        public override string ToString()
        {
            StringBuilder st = new StringBuilder();

            st.AppendLine("--- CERTIFICADO ---");
            foreach (var atribute in Attributes)
            {
                st.AppendFormat("    {0}: {1}", atribute.Key, atribute.Value  );
                st.AppendLine("");
            }
         
            //st.AppendFormat("    Name: {0}", name);
            //st.AppendLine("");
            //st.AppendFormat("    Course: {0}", course);
            //st.AppendLine("");
            //st.AppendFormat("    Dateini: {0} ", dateini);
            //st.AppendLine("");
            //st.AppendFormat("    Dateend: {0}", dateend);
            //st.AppendLine("");
            //st.AppendFormat("    Modality: {0}", Modality);
            //st.AppendLine("");
            //st.AppendFormat("    Hours: {0}", hours);
            //st.AppendLine("");
            //st.AppendFormat("    Date: {0}", date);
            //st.AppendLine("");
            //st.AppendFormat("    Email: {0}", email);
            st.AppendLine("");
            st.AppendFormat("    Certificatepathpdf_eng: {0}", certificatepathpdf_eng);
            st.AppendLine("");
            st.AppendFormat("    Certificatepathpdf_esp: {0}", certificatepathpdf_esp);
            st.AppendLine("");
            st.AppendLine("-------------------");


            return st.ToString();
        }
    }
}
