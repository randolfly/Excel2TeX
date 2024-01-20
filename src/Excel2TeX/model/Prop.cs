namespace Excel2TeX.Model;

public class TextProp(Table table)
{
    public Table Table { get; } = table;
    public string Text { get; set; } = string.Empty;
    public bool i { get; set; } = false;
    public bool b { get; set; } = false;
    public string Color { get; set; } = "000000";

    public void SetProp(Cell cell)
    {

    }

    public string FormatText(Cell cell)
    {
        return "";
    }

    public string GetCellTeX(Cell cell)
    {
        return "";
    }
}


public class BorderLine(Table table)
{
    public Table Table { get; } = table;
    public LineStyle? LineStyle { get; set; }
    public string Color { get; set; } = string.Empty;

    public void SetProp()
    {

    }
}

public class Border(Table table)
{
    public Table Table { get; } = table;
}