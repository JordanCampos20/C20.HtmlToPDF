namespace C20.HtmlToPDF;

public static class Config
{
    public static string ChromeDriverDirectory()
    {
        return $@"{Path.GetDirectoryName(
            System.Reflection.Assembly
                .GetExecutingAssembly().Location)}\selenium\chromedriver-win32\chromedriver.exe";
    }

    public static string ChromeBinaryLocation()
    {
        return $@"{Path.GetDirectoryName(
            System.Reflection.Assembly
                .GetExecutingAssembly().Location)}\selenium\chrome-win32\chrome.exe";
    }
}