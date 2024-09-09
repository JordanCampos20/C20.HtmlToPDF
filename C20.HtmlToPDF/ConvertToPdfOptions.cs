using OpenQA.Selenium;

namespace C20.HtmlToPDF;

public static class ConvertToPdfOptionsSelenium
{
    public static PrintOptions Convert(this ConvertToPdfOptions convertToPdfOptions)
    {
        var printOrientation = 
            convertToPdfOptions._Orientation == 
            PrintOrientationOptions.Portrait ? 
                PrintOrientation.Portrait : PrintOrientation.Landscape;
        
        return new PrintOptions()
        {
            Orientation = printOrientation,
            PageDimensions =
            {
                Height = convertToPdfOptions._PageSize!.Height,
                HeightInInches = convertToPdfOptions._PageSize!.HeightInInches,
                Width = convertToPdfOptions._PageSize!.Width,
                WidthInInches = convertToPdfOptions._PageSize!.WidthInInches
            },
            PageMargins =
            {
                Bottom = convertToPdfOptions._Margins!.Bottom,
                Left = convertToPdfOptions._Margins!.Left,
                Right = convertToPdfOptions._Margins!.Right,
                Top = convertToPdfOptions._Margins!.Top
            },
            ScaleFactor = convertToPdfOptions._Scale,
            OutputBackgroundImages = convertToPdfOptions._Background,
            ShrinkToFit = convertToPdfOptions._ShrinkToFit
        };
    }
}

public class ConvertToPdfOptions
{
    public ConvertToPdfOptions()
    {
        
    }
    
    public ConvertToPdfOptions(
        double scale = 1.0,
        bool background = false,
        bool shrinkToFit = true,
        double defaultMarginSize = 1.0,
        double defaultPageHeight = 21.59,
        double defaultPageWidth = 27.94,
        double centimetersPerInch = 2.54,
        HashSet<object>? pageRanges = null,
        PrintOrientationOptions orientation = PrintOrientationOptions.Portrait,
        PrintOptions.Margins? margins = null,
        PrintOptions.PageSize? pageSize = null)
        {
            _Scale = scale; 
            _Background = background; 
            _ShrinkToFit = shrinkToFit; 
            _DefaultMarginSize = defaultMarginSize; 
            _DefaultPageHeight = defaultPageHeight; 
            _DefaultPageWidth = defaultPageWidth; 
            _CentimetersPerInch = centimetersPerInch; 
            _PageRanges = pageRanges ?? []; 
            _Orientation = orientation; 
            _Margins = margins ?? new PrintOptions.Margins(); 
            _PageSize = pageSize ?? new PrintOptions.PageSize(); 
        }
        
    public readonly double _Scale;
    public readonly bool _Background;
    public readonly bool _ShrinkToFit;
    public readonly double _DefaultMarginSize;
    public readonly double _DefaultPageHeight;
    public readonly double _DefaultPageWidth;
    public readonly double _CentimetersPerInch;
    public readonly HashSet<object>? _PageRanges;
    public readonly PrintOrientationOptions _Orientation;
    public readonly PrintOptions.Margins? _Margins;
    public readonly PrintOptions.PageSize? _PageSize;
}

public enum PrintOrientationOptions
{
    Portrait,
    Landscape
}