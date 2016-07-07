using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace ProjectShop
{
    public static class PDFCreator
    {
        public static void PDF_Creator(ObservableCollection<Product> T, Person Person)
        {
           
              var Control = new Control();
               var path = IfExistFile();


               Document doc = new Document(PageSize.LETTER, 10, 10, 42, 35);
               PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

               BaseFont arial = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\arial.ttf", "iso-8859-2", BaseFont.EMBEDDED);
               Font font = new Font(arial, 15f);
               Font font2 = new Font(arial, 13f);




               doc.Open();
               int row = 7;
               PdfPTable table = new PdfPTable(row);

               table.WidthPercentage = 100;
               Paragraph paragraph = new Paragraph(" Name: " + Person.Name + "\n Surename: " + Person.Surename + "\n Address: " 
                   + Person.Address + "\n Telephone: " + Person.Telephone + "\n",font2) { };
               paragraph.Alignment = 1;
               Paragraph paragraph2 = new Paragraph();
               paragraph2.SpacingBefore = 10f;
               paragraph2.SpacingAfter = 12f;
               Paragraph paragraph3 = new Paragraph(" Final Price: " + Control.FinalPrice(T) + "$", font2);


               PdfPCell cell0 = new PdfPCell(new Phrase("Order", font2));
               PdfPCell cell1 = new PdfPCell(new Phrase("Product", font2));
               PdfPCell cell2 = new PdfPCell(new Phrase("Quantity", font2));
               PdfPCell cell3 = new PdfPCell(new Phrase("Price", font2));
               PdfPCell cell4 = new PdfPCell(new Phrase("Color", font2));
               PdfPCell cell5 = new PdfPCell(new Phrase("Producent", font2));
               PdfPCell cell6 = new PdfPCell(new Phrase("Size", font2));
               PdfPCell cell7 = new PdfPCell(new Phrase("Extra warrenty", font2));


               cell0.BackgroundColor = new BaseColor(0, 200, 0);
               cell0.Colspan = row;
               cell0.HorizontalAlignment = cell1.HorizontalAlignment = cell2.HorizontalAlignment = cell3.HorizontalAlignment = cell4.HorizontalAlignment 
                   = cell5.HorizontalAlignment = cell6.HorizontalAlignment = cell7.HorizontalAlignment = 1;

               table.AddCell(cell0);
               table.AddCell(cell1);
               table.AddCell(cell2);
               table.AddCell(cell3);
               table.AddCell(cell4);
               table.AddCell(cell5);
               table.AddCell(cell6);
               table.AddCell(cell7);


               foreach (var item in T)
               {
                   PdfPCell cellT1 = new PdfPCell(new Phrase(item.Name,font2));
                   PdfPCell cellT2 = new PdfPCell(new Phrase(item.Quantity.ToString(),font2));
                   PdfPCell cellT3 = new PdfPCell(new Phrase(item.Price.ToString(),font2));
                   PdfPCell cellT4 = new PdfPCell(new Phrase(item.Color,font2));
                   PdfPCell cellT5 = new PdfPCell(new Phrase(item.Producent,font2));
                   PdfPCell cellT6 = new PdfPCell(new Phrase(item.SizeItem,font2));
                   PdfPCell cellT7 = new PdfPCell(new Phrase(item.WithWarrentyElementsCounter.ToString(),font2));


                   cellT1.HorizontalAlignment = cellT2.HorizontalAlignment = cellT3.HorizontalAlignment = cellT4.HorizontalAlignment = cellT5.HorizontalAlignment =
                   cellT6.HorizontalAlignment = cellT7.HorizontalAlignment = 1;

                   table.AddCell(cellT1);
                   table.AddCell(cellT2);
                   table.AddCell(cellT3);
                   table.AddCell(cellT4);
                   table.AddCell(cellT5);
                   table.AddCell(cellT6);
                   table.AddCell(cellT7);

               }

               doc.Add(paragraph);
               doc.Add(paragraph2);
               doc.Add(table);

               doc.Add(paragraph3);
               doc.Close();
               Process.Start(path);

           
           }
            
        private static string IfExistFile()
           {
               string path = "Order.pdf ";
               int numberOfOrder = 1;
               do
               {
                   if (File.Exists(path))
                   {
                       path = "Order" + numberOfOrder + ".pdf";
                       numberOfOrder++;
                   }
                   else
                       numberOfOrder = -1;
               }
               while (numberOfOrder != -1);
               return path;
           
        }
    }
}

