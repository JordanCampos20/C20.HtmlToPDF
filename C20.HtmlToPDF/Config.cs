namespace C20.HtmlToPDF;

public static class Config
{
    public static string ChromeDriverDirectory()
    {
#if DEBUG
        return $@"{Path.GetDirectoryName(
            System.Reflection.Assembly
                .GetExecutingAssembly().Location)}\Dependencies\chromedriver-win32\chromedriver.exe";
#else
        return $@"{Environment
            .GetFolderPath(Environment
                .SpecialFolder.UserProfile)}\.nuget\packages\c20.htmltopdf\1.0.5\Dependencies\chromedriver-win32\chromedriver.exe";
#endif
    }

    public static string ChromeBinaryLocation()
    {
#if DEBUG
        return $@"{Path.GetDirectoryName(
            System.Reflection.Assembly
                .GetExecutingAssembly().Location)}\Dependencies\chrome-win32\chrome.exe";
#else
        return $@"{Environment
            .GetFolderPath(Environment
                .SpecialFolder.UserProfile)}\.nuget\packages\c20.htmltopdf\1.0.5\Dependencies\chrome-win32\chrome.exe";
#endif
    }
}