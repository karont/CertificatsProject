using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.Globalization;

namespace CertificatesProject
{
    class PdfCertificate
    {
        public bool createCertificate( Certificate certificate)
        {

            Parameters parameters = ParameterSingleton.Parameters;
            //if(parameters.Templatepath_emg != "")
            //{
            //    certificate.Certificatepathpdf_eng = createCert(parameters.Templatepath_esp, parameters.Pdfpath, parameters.Docpath, certificate, new CultureInfo("en-US"), "eng");
            //}

            if (parameters.Templatepath_esp != "")
            {
                Console.WriteLine("Creating pdf esp");
                certificate.Certificatepathpdf_esp = createCert(parameters.Templatepath_esp, parameters.Pdfpath, parameters.Docpath, certificate, new CultureInfo("es-ES"), "esp");
            }      

            return true;
        }

        private string createCert(string template, string pdfpath,string docpath, Certificate certificate, CultureInfo mycultureinfot, string prefix)
        {

            Object oMissing = System.Reflection.Missing.Value;

            Object oTemplatePath = template;

            

            Application wordapp = new Application();
            Document worddoc = new Document();
            Document worddoctemplate = new Document();

            try
            {
                worddoc = wordapp.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);


                foreach (Field mymergefield in worddoc.Fields)
                {


                    Range rngFieldCode = mymergefield.Code;

                    String fieldText = rngFieldCode.Text;


                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {

                        Int32 endMerge = fieldText.IndexOf("\\");

                        Int32 fieldNameLength = fieldText.Length - endMerge;

                        String fieldName = fieldText.Substring(11, endMerge - 11);

                        fieldName = fieldName.Trim();


                        switch (fieldName)
                        {
                            case "name":
                                mymergefield.Select();
                                wordapp.Selection.TypeText(certificate.Name);
                                break;

                            case "course":
                                mymergefield.Select();
                                wordapp.Selection.TypeText(certificate.Course);
                                break;

                            case "dateini":
                                mymergefield.Select();
                                wordapp.Selection.TypeText(certificate.Dateini.ToString("dd MMMM", mycultureinfot));
                                break;

                            case "dateend":
                                mymergefield.Select();
                                wordapp.Selection.TypeText(certificate.Dateend.ToString("dd MMMM yyyy", mycultureinfot));
                                break;

                            case "hours":
                                mymergefield.Select();
                                wordapp.Selection.TypeText(certificate.Hours);
                                break;

                            case "date":
                                mymergefield.Select();
                                wordapp.Selection.TypeText(certificate.Date.ToString("dd MMMM yyyy", mycultureinfot));
                                break;

                            case "modality":
                                mymergefield.Select();
                                wordapp.Selection.TypeText(certificate.Modality);
                                break;
                            default:
                                break;
                        }

                    }

                }
                StringBuilder pdfpathc = new StringBuilder();
                pdfpathc.AppendFormat(pdfpath + "{0}_{1}.pdf", certificate.Name, prefix);
                
                worddoc.SaveAs(docpath);
                //wordApp.Documents.Open("C:\\Users\\aquesada\\Proyectos\\.NET\\Project1\\Project1\\doc\\myfile.doc");
                worddoc.ExportAsFixedFormat(pdfpathc.ToString(), WdExportFormat.wdExportFormatPDF, false, WdExportOptimizeFor.wdExportOptimizeForOnScreen,
                        WdExportRange.wdExportAllDocument, 1, 1, WdExportItem.wdExportDocumentContent, true, true,
                        WdExportCreateBookmarks.wdExportCreateHeadingBookmarks, true, true, false, ref oMissing);
                worddoc.Close();
                wordapp.Application.Quit();

                //PdfSign.sign(pdfpathc.ToString());
                Console.WriteLine("Created pdf");
                return pdfpathc.ToString();

                
            }

            catch (Exception e)
            {
                worddoc.Close();
                wordapp.Application.Quit();
                Console.WriteLine("Created pdf FAIL: "+e.Message);

                certificate.Sent = false;
                return "";
            }
           
        }


    }
}
