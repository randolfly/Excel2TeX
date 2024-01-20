// See https://aka.ms/new-console-template for more information
using Excel2TeX;

var excelFile = @"D:\tmp\desktop\tmp\C#\Excel2TeX\test\table.xlsx";
var excelIOService = new ExcelIOService();
var table = excelIOService.ReadExcelFile(excelFile);
Console.WriteLine(table.Rows.Count);