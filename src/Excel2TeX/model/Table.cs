using System.Data;
using Excel2TeX.Model;

namespace Excel2TeX;

public class Table
{
    public DataTable DataTable { get; set; }
    public int X1 { get; set; } = 1;
    public int Y1 { get; set; } = 1;
    public int X2 { get; set; } = 1;
    public int Y2 { get; set; } = 1;
    public HashSet<string> ColorSet { get; set; }
    public int VSpace { get; set; } = 0;
    public Cell[][] Cells { get; set; }
    public MergedCell[] MergedCells { get; set; }
    public LineMatrix HLines { get; set; }
    public LineMatrix VLines { get; set; }
    public string TableTeX { get; set; }

    public Table(DataTable dataTable)
    {
        DataTable = dataTable;
        X2 = dataTable.Columns.Count;
        Y2 = dataTable.Rows.Count;

    }
}
