namespace TDDManifesto.Core.Katas.Kata4;

internal static class Kata4
{
    private const int _minSearchTxtLength = 2;
    private const string _returnAllCommand = "*";
    private static readonly HashSet<string> _dbCities = ["Paris", "Budapest", "Skopje", "Rotterdam", "Valencia", "Vancouver", "Amsterdam", "Vienna", "Sydney", "New York City", "London", "Bangkok", "Hong Kong", "Dubai", "Rome", "Istanbul"];
    internal static IEnumerable<string> CitySearch(string searchTxt)
    {
        if(searchTxt == _returnAllCommand) return _dbCities;
        
        if(searchTxt.Length < _minSearchTxtLength) return [];
        
        return _dbCities.Where(city => city.Contains(searchTxt, StringComparison.OrdinalIgnoreCase));
    }
}