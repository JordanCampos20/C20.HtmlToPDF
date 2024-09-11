using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace C20.HtmlToPDF;

public static class ConvertToPdf
{
    public static string? ChromeDriverDirectory { get; set; } = Config.ChromeDriverDirectory();
    public static string? ChromeDirectory { get; set; } = Config.ChromeBinaryLocation();

    public static string ConverterHtml(string html, ConvertToPdfOptions convertToPdfOptions = null!)
    {
        return Converter(html, convertToPdfOptions, false);
    }
    
    public static string ConverterPage(string url, ConvertToPdfOptions convertToPdfOptions = null!)
    {
        return Converter(url, convertToPdfOptions, true);
    }
    
    private static string Converter(string html, ConvertToPdfOptions convertToPdfOptions, bool isPage)
    {
        ChromeOptions chromeOptions = new()
        {
            BinaryLocation = ChromeDirectory
        };

        chromeOptions.AddArguments("headless", "no-sandbox");

        WebDriver webDriver = new ChromeDriver(ChromeDriverDirectory, chromeOptions);

        var webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

        var actions = new Actions(webDriver);

        webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        webDriver.Manage().Window.Maximize();

        if (isPage)
        {
            webDriver.Navigate().GoToUrl(html);
        }
        else
        {
            var htmlBase64 = 
                Convert.ToBase64String(Encoding.UTF8.GetBytes(html));
            webDriver.Navigate()
                .GoToUrl($"data:text/html;base64,{htmlBase64}");
        }

        var printDocument = 
            webDriver.Print(convertToPdfOptions.Convert());

        var encodedString = printDocument.AsBase64EncodedString;
        
        webDriver.Close();
        
        webDriver.Dispose();

        return encodedString;
    }
}