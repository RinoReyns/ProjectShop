using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace ProjectShop
{
    public class Control 
    {
        public int check(List<Product> T, string a)
        {
            foreach (var Products in T)
            {
                if ((0 == (String.Compare(a, Products.Name))))
                    return 1;
            }
            return 0;
        }

        public int check(ObservableCollection<Product> T, string a, string b, string c)
        {
            foreach (var Products in T)
            {
                if ((0 == (String.Compare(a, Products.Name))) & (0 == (String.Compare(b, Products.Color))) & 0 == (String.Compare(c, Products.SizeItem)))
                    return (T.IndexOf(Products));
            }
            return -1;
        }
        public string FinalPrice(ObservableCollection<Product> T)
        {
            double Price=0;
            foreach (var item in T)
            {
                Price+=item.Price;
            }
            return Price.ToString();
        }

        public void PDF_Creator(ObservableCollection<Product> T, Person Person)
        {
    
            var path = "order.pdf ";
            Document doc = new Document(PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();
       
              int row = 7;
            PdfPTable table = new PdfPTable(row);
            
            Paragraph paragraph = new Paragraph(" Name: " + Person.Name + "\n Surename: " + Person.Surename + "\n Address: " + Person.Address + "\n Telephone: " + Person.Telephone + "\n") {  };
            paragraph.Alignment = 1;
            Paragraph paragraph2 = new Paragraph("\n\n\n\n\n");
            PdfPCell cell = new PdfPCell(new Phrase("Order", new Font(Font.NORMAL, 15f, Font.NORMAL)))  ;
            PdfPCell cell1 = new PdfPCell(new Phrase("Product", new Font(Font.NORMAL, 11f, Font.NORMAL)));
            PdfPCell cell2 = new PdfPCell(new Phrase("Quantity", new Font(Font.NORMAL, 11f, Font.NORMAL)));
            PdfPCell cell3 = new PdfPCell(new Phrase("Price", new Font(Font.NORMAL, 11f, Font.NORMAL)));
            PdfPCell cell4 = new PdfPCell(new Phrase("Color", new Font(Font.NORMAL, 11f, Font.NORMAL)));
            PdfPCell cell5 = new PdfPCell(new Phrase("Producent", new Font(Font.NORMAL, 11f, Font.NORMAL)));
            PdfPCell cell6 = new PdfPCell(new Phrase("Size", new Font(Font.NORMAL, 11f, Font.NORMAL)));
            PdfPCell cell7 = new PdfPCell(new Phrase("Extra warrenty", new Font(Font.NORMAL, 11f, Font.NORMAL)));



            cell.BackgroundColor = new BaseColor(0,200,0);
            cell.Colspan = row;
            cell.HorizontalAlignment = cell1.HorizontalAlignment = cell2.HorizontalAlignment = cell3.HorizontalAlignment = cell4.HorizontalAlignment= cell5.HorizontalAlignment = 1;
            table.AddCell(cell);
            table.AddCell(cell1);
            table.AddCell(cell2);
            table.AddCell(cell3);
            table.AddCell(cell4);
            table.AddCell(cell5);
            table.AddCell(cell6);
            table.AddCell(cell7);




            foreach (var item in T)
            {
                PdfPCell cellT1 = new PdfPCell(new Phrase(item.Name));
                PdfPCell cellT2 = new PdfPCell(new Phrase(item.Quantity.ToString()));
                PdfPCell cellT3 = new PdfPCell(new Phrase(item.Price.ToString()));
                PdfPCell cellT4 = new PdfPCell(new Phrase(item.Color));
                PdfPCell cellT5 = new PdfPCell(new Phrase(item.Producent));
                PdfPCell cellT6 = new PdfPCell(new Phrase(item.SizeItem));
                PdfPCell cellT7 = new PdfPCell(new Phrase(item.WithWarrentyElementsCounter.ToString()));


                cellT1.HorizontalAlignment = cellT2.HorizontalAlignment = cellT3.HorizontalAlignment = cellT4.HorizontalAlignment= cellT5.HorizontalAlignment =
                cellT6.HorizontalAlignment=cellT7.HorizontalAlignment = 1;
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
            doc.Close();  
            Process.Start(path);           
        }
      
    }

    public static class Exit_Window
    {
        
        private static int k { get; set; } = 0;
        public static bool Exit( int i=0)
        {
            if (k == 0)
            {
                k = i;
                MessageBoxResult result = MessageBox.Show("Do you really want to end your shopping without order?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
                else if (result == MessageBoxResult.No)
                {
                    k = 0;
                    return true;
                }
            }
            return false;
        }

    }
}
        
    

