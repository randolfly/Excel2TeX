using Excel2TeX.Model;

namespace Excel2TeX.Util;

public static class CommonUtil
{
    // wrap !{}
    public static string WrapExcel(string text)
    {
        return $"  !{text}\n";
    }

    // wrap >{}
    public static string WrapGe(string text)
    {
        return $"  >{text}\n";
    }
}
