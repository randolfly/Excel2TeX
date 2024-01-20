using System.Runtime.CompilerServices;

namespace Excel2TeX.Model;

public class MergedCell(int index, (int y1, int x1, int y2, int x2) bounds)
{
    public int Index { get; } = index;
    public int Y1 { get; set; } = bounds.y1;
    public int Y2 { get; set; } = bounds.y2;
    public int X1 { get; set; } = bounds.x1;
    public int X2 { get; set; } = bounds.x2;

    public bool IsMerged(int row, int col)
    {
        if ((row >= X1) && (row <= Y2) && (col >= Y1) && (col <= Y2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string GetCellType(int row, int col)
    {
        if ((X1 != X2) && (Y1 != Y2))
        {
            if (row == X1)
            {
                if (col == Y1)
                {
                    return "block_firstline_begin";
                }
                else
                {
                    return "block_firstline_other";
                }
            }
            if (col == Y1)
            {
                return "block_placeholder_begin";
            }
            if (col == Y2)
            {
                return "block_placeholder_end";
            }
            else
            {
                return "block_placeholder_other";
            }
        }
        if (X1 == X2)
        {
            if (col == Y1)
            {
                return "multicolumn_begin";
            }
            else
            {
                return "multicolumn_other";
            }

        }
        if (Y1 == Y2)
        {
            if (row == X1)
            {
                return "multirowcell_begin"
            }
            else
            {
                return "multirowcell_other";
            }



        }
        return string.Empty;
    }

    public bool IsEnd(int MaxCol) => Y2 == MaxCol;
    public (int x1, int y1) GetHead => (X1, Y1);
    public bool IsControl(int row, int col) => (row == X2) && (col == Y1);
    public bool IsIgnored(int row, int col) => (row == X2) && (col > Y1);
    public bool IsOneRow => X1 == X2;
}
