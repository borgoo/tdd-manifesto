using System.Globalization;

namespace TDDManifesto.Core.Katas.Kata5;

internal static class Kata5
{
    private static readonly CultureInfo _cultureInfo = new("en-US");

    private const string _emptyBarcode = "";
    private const string _notFoundBarcode = "99999";

    private static readonly Dictionary<string, string> _errorMap = new()
    {
        { _notFoundBarcode, "Error: barcode not found" },
        { _emptyBarcode, "Error: empty barcode" }
    };

    private static readonly Dictionary<string, decimal> _validMap = new()
    {
        { "12345",7.25m },
        { "23456", 12.50m }
    };


    internal static string ScanBarcode(string barcode){
        if(_validMap.TryGetValue(barcode, out decimal value)) return value.ToString("C2", _cultureInfo);
        return _errorMap[barcode];
    }

    internal static string Total(string[] totals) 
        => totals.Where(_validMap.ContainsKey).Sum(num => _validMap[num]).ToString("C2", _cultureInfo);

    }