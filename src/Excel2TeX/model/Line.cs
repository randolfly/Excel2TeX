﻿namespace Excel2TeX.Model;

public class ClineRange(int start, int end)
{
    public int Start { get; set; } = start;
    public int End { get; set; } = end;
}

public class LineStyle
{
    public bool IsDash { get; set; }
    public int LineNumber { get; set; }
    public float LineWidth { get; set; }
    public (int, int) DashStyle { get; set; } = (1, 1);
}

public class Line(Table table, (int x, int y) index)
{
    // LineStyle dictionary
    public static Dictionary<string, LineStyle> LineStyleDict = new()
    {
        {
            "thin",
            new LineStyle
            {
                IsDash = false,
                LineNumber = 1,
                LineWidth = 0.4f,
                DashStyle = (1, 1)
            }
        },
        {
            "medium",
            new LineStyle
            {
                IsDash = false,
                LineNumber = 1,
                LineWidth = 0.6f,
                DashStyle = (1, 1)
            }
        },
        {
            "thick",
            new LineStyle
            {
                IsDash = false,
                LineNumber = 1,
                LineWidth = 0.8f,
                DashStyle = (1, 1)
            }
        },
        {
            "double",
            new LineStyle
            {
                IsDash = false,
                LineNumber = 2,
                LineWidth = 0.4f,
                DashStyle = (1, 1)
            }
        },
        {
            "hair",
            new LineStyle
            {
                IsDash = true,
                LineNumber = 1,
                LineWidth = 0.4f,
                DashStyle = (1, 1)
            }
        },
        {
            "dotted",
            new LineStyle
            {
                IsDash = true,
                LineNumber = 1,
                LineWidth = 0.4f,
                DashStyle = (1, 1)
            }
        },
        {
            "dashed",
            new LineStyle
            {
                IsDash = true,
                LineNumber = 1,
                LineWidth = 0.4f,
                DashStyle = (1, 1)
            }
        },
        {
            "dashDot",
            new LineStyle
            {
                IsDash = true,
                LineNumber = 1,
                LineWidth = 0.4f,
                DashStyle = (1, 1)
            }
        },
        {
            "dashDotDot",
            new LineStyle
            {
                IsDash = true,
                LineNumber = 1,
                LineWidth = 0.4f,
                DashStyle = (1, 1)
            }
        },
        {
            "mediumDashed",
            new LineStyle
            {
                IsDash = true,
                LineNumber = 1,
                LineWidth = 0.4f,
                DashStyle = (1, 1)
            }
        },
        {
            "mediumDashDot",
            new LineStyle
            {
                IsDash = true,
                LineNumber = 1,
                LineWidth = 0.4f,
                DashStyle = (1, 1)
            }
        },
        {
            "mediumDashDotDot",
            new LineStyle
            {
                IsDash = true,
                LineNumber = 1,
                LineWidth = 0.4f,
                DashStyle = (1, 1)
            }
        },
        {
            "slantDashDot",
            new LineStyle
            {
                IsDash = true,
                LineNumber = 1,
                LineWidth = 0.4f,
                DashStyle = (1, 1)
            }
        },
    };


    public Table Table { get; set; } = table;
    public (int x, int y) Index { get; set; } = index;
    public LineStyle? LineStyle { get; set; }

    public bool IsNone { get; set; } = true;
    public bool IsColored { get; set; } = false;

    // hline or vline
    public string Color { get; set; } = "white";
    // horizontal line in the first/last row
    public bool IsFirstHorizontalLine { get; set; } = false;
    public bool IsLastHorizontalLine { get; set; } = false;
    // vertical line in the first/last column
    public bool IsFirstVerticalLine { get; set; } = false;
    public bool IsLastVerticalLine { get; set; } = false;
    // ignore vertical line
    public bool IsIgnoreVerticalLine { get; set; } = false;
}

public class LineMatrix
{

    public Table Table { get; }
    public int XMax { get; set; }
    public int YMax { get; set; }
    // for hlines
    public int[] MaxWidth { get; set; } = [];
    // for vlines
    public int[] VLineMaxWidth { get; set; } = [];
    public Line[][] Borders { get; set; }
    public LineMatrix(Table table)
    {
        Table = table;
        XMax = table.X2 - 1;
        YMax = table.Y2 - 1;
        Borders = new Line[XMax][];
        for (var i = 0; i < XMax; i++)
        {
            for (var j = 0; j < YMax; j++)
            {
                Borders[i][j] = new Line(table, (i, j));
            }
        }
    }

    public void SetLines()
    {

    }

    public bool IsEmpty()
    {
        return true;
    }

    public bool IsFull()
    {
        return true;
    }

    public (int startIndex, int endIndex) CutRange()
    {
        return (0, 0);
    }

    public List<ClineRange> GetHLineRange()
    {
        return new List<ClineRange>();
    }

    public string GetHLineTeX()
    {
        return "";
    }

    public void SetVSpace()
    {

    }

    public string GetRowHLineTeX()
    {
        return "";
    }
}