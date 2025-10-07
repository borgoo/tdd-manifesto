using CoreKata5 = TDDManifesto.Core.Katas.Kata5.Kata5;
namespace TDDManifesto.NUnit.Katas.Kata5;

public class Kata5Test
{
    [TestCase("12345", "$7.25")]
    [TestCase("23456", "$12.50")]
    [TestCase("99999", "Error: barcode not found")]
    [TestCase("", "Error: empty barcode")]
    public void ScanBarcode_WhenBarcodeIs12345_ThenReturnPrice725(string barcode, string expectedResult)
    {
        var result = CoreKata5.ScanBarcode(barcode);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Total_WhenAllBarcodesAreValid_ThenReturnTotal(){
        string[] barrcodes = ["12345", "23456"];
        var result = CoreKata5.Total(barrcodes);
        Assert.That(result, Is.EqualTo("$19.75"));
    }
 
    [Test]
    public void Total_WhenNotAllBarcodesAreValid_ThenReturnTheSumOfTheValidBarcodes(){
        string[] barrcodes = ["12345", "","23456", "99999"];
        var result = CoreKata5.Total(barrcodes);
        Assert.That(result, Is.EqualTo("$19.75"));
    }

    [Test]
    public void Total_WhenAllBarcodesAreInValid_ThenReturn0(){
        string[] barrcodes = ["","99999"];
        var result = CoreKata5.Total(barrcodes);
        Assert.That(result, Is.EqualTo("$0.00"));
    }
}
  