using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace POCO.Pdf.Watermark
{
    public class WatermarkPdfHelper
    {
        public static byte[] WriteToPdf(FileInfo sourceFile, string watermarkText)
        {
            PdfReader reader = new PdfReader(sourceFile.FullName);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfStamper pdfStamper = new PdfStamper(reader, memoryStream);

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    Rectangle pageSize = reader.GetPageSizeWithRotation(i);

                    PdfContentByte pdfPageContents = pdfStamper.GetUnderContent(i);
                    pdfPageContents.BeginText();

                    BaseFont baseFont = BaseFont.CreateFont(BaseFont.COURIER_BOLD, Encoding.ASCII.EncodingName, false);
                    pdfPageContents.SetFontAndSize(baseFont, 10); 
                    pdfPageContents.SetRGBColorFill(255, 0, 0); 

                    float textAngle = 90.0f;

                    pdfPageContents.ShowTextAligned(PdfContentByte.ALIGN_CENTER, watermarkText, 25, pageSize.Width / 2, textAngle);

                    pdfPageContents.EndText();
                }

                pdfStamper.FormFlattening = true; 
                pdfStamper.Close(); 

                return memoryStream.ToArray();
            }
        }
    }
}
