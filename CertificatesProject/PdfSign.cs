using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemBox.Pdf;
namespace CertificatesProject
{
    static class PdfSign
    {
        public static void sign(string pdfpath)
        {

            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            Parameters parameters = ParameterSingleton.Parameters;
            using (var document = PdfDocument.Load(@pdfpath))
            {
                // Add a visible signature field to the first page of the PDF document.
                var signatureField = document.Form.Fields.AddSignature(document.Pages[0], 350, 300, 250, 50);

                // Retrieve signature appearance settings to customize it.
                var signatureAppearance = signatureField.Appearance;

                // Show 'Reason' label and value.
                signatureAppearance.Reason = "Legal agreement";
                // Show 'Location' label and value.
                signatureAppearance.Location = "New York, USA";
                // Do not show 'Date' label nor value.
                signatureAppearance.DateFormat = string.Empty;

                // Initiate signing of a PDF file with the specified digital ID file and the password.
                signatureField.Sign(parameters.Signpath, parameters.Signpassword);

                // Finish signing of a PDF file.
    
                document.Save();
            }
        }
    }
}
