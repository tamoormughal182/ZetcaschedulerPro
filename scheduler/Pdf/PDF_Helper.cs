using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using System.IO;
using System.Reflection;
using iText.IO.Image;
using ZXing;
using ZXing.QrCode;

namespace scheduler.Pdf
{
    public class PDF_Helper
    {
        public static void CreatePDF(string pdfName, string xmlFileName, string QrCode)
        {
            
            try
            {
                //xmlFile = @"file:///D:/GIG_PROJECT/Gig_Auto/CastelCrypto/dll/xmlsample.xml";
                // xmlFile = @"D:\GIG_PROJECT\Gig_Auto\CastelCrypto\dll\xmlsample.xml";
                string xmlFile = @"C:\Repository\StandardInvoice\Tamoor310761410500003_20231104T00001_STDIN00002.xml";
                //C:\Repository\StandardInvoice  AttachA3PDF
                //pdfaName = @"D:\GIG_PROJECT\Gig_Auto\CastelCrypto\dll\attachPDFwithXML.pdf";
                string pdfaName = @"C:\Repository\AttachA3PDF\12000_1.pdf";
                  string folderPath = @"C:\Repository\dll_icon";
                string QRfolderPath = @"C:\Repository\QRCode\";
                string folderPath_QRCODEPICK = @"C:\Repository\QRCode\";
                // Register CodePagesEncodingProvider
                // Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                // Construct Fonts
                BaseFont baseFont = BaseFont.CreateFont(Path.Combine(folderPath, "VERDANA.TTF"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font font = new Font(baseFont, 12);

                // International Color Consortium (ICC) Profile
                ICC_Profile icc = ICC_Profile.GetInstance(Path.Combine(folderPath, "sRGB_CS_profile.icm"));

                // Create PDF Document
                Document document = new Document(PageSize.A4, 5f, 5f, 16f, 100f);

                // PdfAWriter with PDF/A-3B conformance
                PdfAWriter writer = PdfAWriter.GetInstance(document, new FileStream(pdfaName, FileMode.Create), PdfAConformanceLevel.PDF_A_3B);

                // Open the document
                document.Open();

                // Set output intents for color management
                writer.CreateXmpMetadata();
                writer.SetOutputIntents("Custom", "", "http://www.color.org", "sRGB IEC61966-2.1", icc);

                // Add document metadata
                document.AddAuthor("Author Name");
                document.AddTitle("Document Title");

                // Prepare PDF Attachment & its Properties
                PdfDictionary param = new PdfDictionary();
                param.Put(PdfName.MODDATE, new PdfDate());
                param.Put(PdfName.TITLE, new PdfString("Attachment Title"));

                PdfFileSpecification specification = PdfFileSpecification.FileEmbedded(writer, xmlFile, "Attachment.xml", null, "application/xml", param, 0);
                specification.Put(new PdfName("AFRelationship"), new PdfName("Data"));

                writer.AddFileAttachment("Description for Attachment", specification);

                // Add the attachment reference to the ExtraCatalog
                PdfArray array = new PdfArray();
                array.Add(specification.Reference);
                writer.ExtraCatalog.Put(new PdfName("AF"), array);

                /////////////////////
                ///
                string QrNAme = "1" + ".png";
                string base64ImageString = "ARNBTEVNTEFRIFRSQURJTkcgQ08uAg8zMTA3NjE0MTA1MDAwMDMDEzIwMjMtMTEtMDRUMTM6MDA6MDAECDYzMjUwLjAwBQQwLjAwBixFVnJkVzQyWlIydkZVekdaTDFhNE1iN1RZY1VMV29vZ05kajVhRHVJQ1RFPQdgTUVVQ0lRRGI0NGNQUkVnU1lvL1BjT0VvQzdFYmhSNGgwMFJPWEtubU5oekNxR3pXTUFJZ0tGdVdwQTBUaG1OWlpVUjJjK3hvRVRQM3JTSHdab2t5dkZudXFpYTc1bjA9CFgwVjAQBgcqhkjOPQIBBgUrgQQACgNCAAQSawzQL3l2MdtLDxDPjf9LKfKCxBepcUBqaDz8x87I2io0eXKkmjDV40uagBugjmCDcZBO1sHB0kAyXHcc0x5L";
                QRfolderPath = QRfolderPath + QrNAme;
                GenerateQrCode(base64ImageString, QRfolderPath);
                // HTML content
                //var imagePath_logo = Path.Combine(folderPath, "PDF_LOGO.PNG");
                //var image_logo = Image.GetInstance(imagePath_logo);
                //document.Add(image_logo); ;
                /////
                // Add an image from Base64 string
               
                //add qrcode
                //var imagePath_qrcode = Path.Combine(folderPath_QRCODEPICK, "1.png");
                //var image_qrcode = Image.GetInstance(imagePath_qrcode);
                //document.Add(image_qrcode);
                //////////////
                ///

                #region MyRegion
                // Create a table with two cells
                PdfPTable table = new PdfPTable(2);
                table.TotalWidth = document.PageSize.Width;
                //table.LockedWidth = true;

                

                // Right cell (Logo)
                PdfPCell cellLogo = new PdfPCell();
                var imagePath_logo = Path.Combine(folderPath, "PDF_LOGO.PNG");
                var image_logo = Image.GetInstance(imagePath_logo);
                image_logo.ScaleToFit(100f, 100f); // Set width and height
                cellLogo.AddElement(image_logo);
                table.AddCell(cellLogo);
                // Left cell (QR Code)
                PdfPCell cellQrCode = new PdfPCell();
                var imagePath_qrcode = Path.Combine(folderPath_QRCODEPICK, "1.png");
                var image_qrcode = Image.GetInstance(imagePath_qrcode);
                image_qrcode.ScaleToFit(100f, 100f); // Set width and height
                cellQrCode.AddElement(image_qrcode);

                table.AddCell(cellQrCode);
                // Add the table to the document
                document.Add(table);
                #endregion
                #region HTML
                // HTML content
                

                #endregion
                // Add content to the PDF
                document.Add(new Paragraph("Please Subscribe to my tamoor 310761410500003_20231104T00001_STDIN00003", font));
                //footer
                var imagePath_Footer = Path.Combine(folderPath, "PDF_Fotter.PNG");
                var image_Footer = Image.GetInstance(imagePath_Footer);
                // Scale the image to fit within the page width
                image_Footer.ScaleToFit(document.PageSize.Width, document.PageSize.Height);

                document.Add(image_Footer);
                // Close the document
                document.Close();
                writer.Close();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public static void CreatePDF2(string pdfName, string xmlFileName, string QrCode)
        {

            try
            {
                string existingPdfPath = @"C:\Repository\AttachA3PDF\12000_1.pdf";
                string xmlFilePath = @"C:\Repository\StandardInvoice\Tamoor310761410500003_20231104T00001_STDIN00002.xml";
                
                string attachmentDescription = "Description for Attachment";
                // Create a new stream for the modified PDF
                // Check if the existing PDF file is not empty
                if (new FileInfo(existingPdfPath).Length == 0)
                {
                    Console.WriteLine("Error: Existing PDF file is empty.");
                    return;
                }

                // Create a new stream for the modified PDF
                try
                {
                    using (var existingFileStream = new FileStream(existingPdfPath, FileMode.Open, FileAccess.ReadWrite))
                    {
                        using (var stamper = new PdfStamper(new PdfReader(existingFileStream), existingFileStream))
                        {
                            // Prepare PDF Attachment & its Properties
                            PdfDictionary param = new PdfDictionary();
                            param.Put(PdfName.MODDATE, new PdfDate());
                            param.Put(PdfName.TITLE, new PdfString("Attachment Title"));

                            PdfFileSpecification specification = PdfFileSpecification.FileEmbedded(stamper.Writer, xmlFilePath, "Attachment.xml", null, "application/xml", param, 0);
                            specification.Put(new PdfName("AFRelationship"), new PdfName("Data"));

                            stamper.AddFileAttachment(attachmentDescription, specification);

                            // You can add more modifications if needed

                            // Close the stamper
                            stamper.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions here
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
             

            }
            catch (Exception ex)
            {

                throw;
            }

        }
        //public static void attachXMLonPDF(string pdfName, string xmlFileName, string QrCode)
        //{

        //    try
        //    {
        //        //xmlFile = @"file:///D:/GIG_PROJECT/Gig_Auto/CastelCrypto/dll/xmlsample.xml";
        //        // xmlFile = @"D:\GIG_PROJECT\Gig_Auto\CastelCrypto\dll\xmlsample.xml";
        //        string xmlFile = @"C:\Repository\StandardInvoice\Tamoor310761410500003_20231104T00001_STDIN00002.xml";
        //        //C:\Repository\StandardInvoice  AttachA3PDF
        //        //pdfaName = @"D:\GIG_PROJECT\Gig_Auto\CastelCrypto\dll\attachPDFwithXML.pdf";
        //        string pdfaName = @"C:\Repository\AttachA3PDF\12000_1.pdf";
        //        string folderPath = @"C:\Repository\dll_icon";
        //        string QRfolderPath = @"C:\Repository\QRCode\";
        //        string folderPath_QRCODEPICK = @"C:\Repository\QRCode\";
        //        // Register CodePagesEncodingProvider
        //        string existingPdfPath = @"C:\Repository\AttachA3PDF\existing.pdf";
                

        //        // Create a new stream for the modified PDF
        //        using (var newFileStream = new FileStream(@"C:\Repository\AttachA3PDF\modified.pdf", FileMode.Create, FileAccess.Write))
        //        {
        //            // Load existing PDF
        //            using (var existingFileStream = new FileStream(existingPdfPath, FileMode.Open, FileAccess.Read))
        //            {
        //                using (var existingPdfReader = new PdfReader(existingFileStream))
        //                {
        //                    // Create PdfAWriter with PDF/A-3B conformance
        //                    using (var writer = PdfAWriter.GetInstance(existingPdfReader, newFileStream, PdfAConformanceLevel.PDF_A_3B))
        //                    {
        //                        // Open the document
        //                        writer.SetFullCompression();

        //                        // Prepare PDF Attachment & its Properties
        //                        PdfDictionary param = new PdfDictionary();
        //                        param.Put(PdfName.MODDATE, new PdfDate());
        //                        param.Put(PdfName.TITLE, new PdfString("Attachment Title"));

        //                        PdfFileSpecification specification = PdfFileSpecification.FileEmbedded(writer, xmlFile, "Attachment.xml", null, "application/xml", param, 0);
        //                        specification.Put(new PdfName("AFRelationship"), new PdfName("Data"));

        //                        writer.AddFileAttachment("Description for Attachment", specification);

        //                        // Add more modifications if needed

        //                        // Close the writer
        //                        writer.Close();
        //                    }
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}
        // Helper class for decoding Base64 images
        public static class Base64Image
        {
            public static byte[] Decode(string base64String)
            {
                var base64Data = base64String.Substring(base64String.IndexOf(',') + 1);
                return Convert.FromBase64String(base64Data);
            }
        }
        static void GenerateQrCode(string data, string imagePath)
        {
            try
            {
                var barcodeWriter = new BarcodeWriter();
                barcodeWriter.Format = BarcodeFormat.QR_CODE;

                var encodingOptions = new QrCodeEncodingOptions
                {
                    Width = 300,
                    Height = 300
                };

                barcodeWriter.Options = encodingOptions;

                System.Drawing.Bitmap qrCodeBitmap = barcodeWriter.Write(data);

                // Save the QR code image
                qrCodeBitmap.Save(imagePath);
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}
