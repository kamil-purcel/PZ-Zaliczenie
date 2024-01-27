using PdfSharpCore.Drawing;

namespace DatePrinter.Web.Models.Classes;

public class Template
{
    public Template(double xOffset, double yOffset, double rowHeight, double[] columnWidths)
    {
        XOffset = xOffset;
        YOffset = yOffset;
        RowHeight = rowHeight;
        ColumnWidths = columnWidths;
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public double XOffset { get; set; } // 1
    public double YOffset { get; set; } // 0

    public double RowHeight { get; set; } // 7

    // VerticalLineHeight
    public double[] ColumnWidths { get; set; }
    public double[] CenterOfColumn { get; set; }
    public string[] Labels { get; set; } // product, made, discard

    public double ConvertToPoint(double size)
    {
        return XUnit.FromMillimeter(size);
    }
}