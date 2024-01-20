using ExcelDataReader;
using System.Data;

namespace Excel2TeX;

public class ExcelIOService
{
    public DataTable? DataTable { get; set; }

    public ExcelIOService()
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
    }

    public DataTable ReadExcelFile(string filePath)
    {
        using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
        // Auto-detect format, supports:
        //  - Binary Excel files (2.0-2003 format; *.xls)
        //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
        using var reader = ExcelReaderFactory.CreateReader(stream);

        var result = reader.AsDataSet();
        DataTable = result.Tables[0];
        return DataTable;
    }
}