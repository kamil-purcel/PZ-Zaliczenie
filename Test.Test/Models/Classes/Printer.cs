using System.Diagnostics;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace DatePrinter.Web.Models.Classes;

public class Printer
{
    public void tmp(int copies)
    {
        GenerateSticker();

        var filePath = "/Users/kamilpurcel/Desktop/save/generated.pdf";
        var sticker = new Sticker(35, 35);
        Process.Start("lp",
            $"-d _192_168_0_190 -n {copies} -o orientation-requested=6 -o collate=true -o media=Custom.{sticker.Width}x{sticker.Height}mm \"{filePath}\"");

        // return View("Index");
    }

    private void GenerateSticker()
    {
        var sticker = new Sticker(35, 35);
        var template = new Template(1, 0, 7, new double[] { 14, 14, 7 });

        var document = new PdfDocument();

        var font = new XFont("Arial", 9);
        var boldFont = new XFont("Arial", 9, XFontStyle.Bold);

        var page = document.AddPage();
        page.Width = sticker.Width;
        page.Height = sticker.Height;

        using (var gfx = XGraphics.FromPdfPage(page))
        {
            // gfx.DrawLine(XPens.Black, columnWidths[0], 0, columnWidths[0],
            //     tem.lineHeight);
            // gfx.DrawLine(XPens.Black, columnWidths[0] + columnWidths[1], 0,
            //     columnWidths[0] + columnWidths[1],
            //     tem.lineHeight);
            //
            // for (int i = 0; i < tem.label.Length; i++)
            // {
            //     gfx.DrawString(tem.label[i], boldFont, XBrushes.Black, tem.tableX,
            //         tem.tableY + (i + 1) * tem.rowHeight);
            //         var centerXColumn = tem.tableX + columnWidths[0] + columnWidths[1] / 2;
            //         gfx.DrawString(dane.DateOne[i], font, XBrushes.Black, centerXColumn,
            //             tem.tableY + (i + 1) * tem.rowHeight);
            //         centerXColumn = tem.tableX + columnWidths[0] + columnWidths[1] + columnWidths[2] / 2;
            //         gfx.DrawString(dane.DateTwo[i], font, XBrushes.Black, centerXColumn,
            //             tem.tableY + (i + 1) * tem.rowHeight);
            //         
            //     if (i < tem.label.Length)
            //     {
            //         gfx.DrawLine(XPens.Black, 0, (tem.tableY + (i + 1) * tem.rowHeight), (tem.tableX + doc.Wight),
            //             (tem.tableY + (i + 1) * tem.rowHeight));
            //         gfx.DrawLine(XPens.Black, 0, (tem.tableY + (i + 1) * tem.rowHeight) + 7, (tem.tableX + doc.Wight),
            //             (tem.tableY + (i + 1) * tem.rowHeight) + 7);
            //     }
            // }
        }

        var filePath = "/Users/kamilpurcel/Desktop/save/generated.pdf";
        document.Save(filePath);
    }
}