using NUnit.Framework.Internal;
using CoreKata4 = TDDManifesto.Core.Katas.Kata4.Kata4;

namespace TDDManifesto.NUnit.Katas.Kata4;

public class Kata4Test
{
    [Test]
    public void CitySearch_WhenSearchTxtIsTooShort_ThenReturnNoResults()
    {
        string searchTxt = "12";
        var result = CoreKata4.CitySearch(searchTxt);   
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void CitySearch_WhenSearchTxtIsValidAndExactlyEqualTheStartOfACityName_ThenReturnAllCitiesStartingWithTheSearchTxt(){
        string searchTxt = "Va";
        var result = CoreKata4.CitySearch(searchTxt);
        Assert.That(result, Is.EqualTo(["Valencia", "Vancouver"]));
    }
  
    [Test]
    public void CitySearch_WhenSearchTxtIsValidAndEqualExceptTheCaseOfTheStartOfACityName_ThenReturnAllCitiesStartingWithTheSearchTxt(){
        string searchTxt = "va";
        var result = CoreKata4.CitySearch(searchTxt);
        Assert.That(result, Is.EqualTo(["Valencia", "Vancouver"]));
    }

    [Test]
    public void CitySearch_WhenSearchTxtIsValidAndContainedInACityName_ThenReturnAllCitiesContainingTheSearchTxt(){
        string searchTxt = "ape";
        var result = CoreKata4.CitySearch(searchTxt);
        Assert.That(result, Is.EqualTo(["Budapest"]));
    }

    [Test]
    public void CitySearch_WhenSearchTxtIsValidAndEqualTheReturnAllCommand_ThenReturnAllCities(){
        string searchTxt = "*";
        var result = CoreKata4.CitySearch(searchTxt);
        Assert.That(result, Is.EqualTo(["Paris", "Budapest", "Skopje", "Rotterdam", "Valencia", "Vancouver", "Amsterdam", "Vienna", "Sydney", "New York City", "London", "Bangkok", "Hong Kong", "Dubai", "Rome", "Istanbul"]));
    }
}