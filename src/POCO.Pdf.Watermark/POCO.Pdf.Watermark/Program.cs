using System;
using System.Globalization;
using System.IO;

namespace POCO.Pdf.Watermark
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo pdfFileInfo = new FileInfo("c:\\temp\\input.pdf");

            byte[] fileBytes = WatermarkPdfHelper.WriteToPdf(pdfFileInfo
                , "This document was approved by Francisco Costa on " + DateTime.Now.ToString("dddd, MMMM d, yyyy", CultureInfo.GetCultureInfo("en-US")));

            File.WriteAllBytes("c:\\temp\\output.pdf", fileBytes);
        }
    }
}
