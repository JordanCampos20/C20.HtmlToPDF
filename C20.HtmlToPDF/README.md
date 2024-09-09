# C20.HtmlToPDF
PT-BR:
funciona normalmente no Windows x86 e x64,
não foi implementado para os outros sistemas.

EN:
works normally on Windows x86 and x64,
it has not been implemented for other systems.

# Example
using C20.HtmlToPDF;

var fileBase64String = "";

var pathDocuments = 
    Environment.GetFolderPath(
        Environment.SpecialFolder.MyDocuments);

const string html = """
                    <!DOCTYPE html>
                        <html lang="pt-BR">
                            <head>
                                <meta charset="UTF-8">
                                <meta name="viewport" content="width=device-width, initial-scale=1.0">
                                <title>Document</title>
                            </head>
                            <body>
                                <p>Hello World...</p>
                            </body>
                        </html>
                    """;
        
fileBase64String = ConvertToPdf.ConverterHtml(html, new ConvertToPdfOptions(orientation: PrintOrientationOptions.Portrait));

File.WriteAllBytes($@"{pathDocuments}\example_html.pdf", Convert.FromBase64String(fileBase64String));

const string url = "https://www.google.com.br";
        
fileBase64String = ConvertToPdf.ConverterPage(url, new ConvertToPdfOptions(orientation: PrintOrientationOptions.Portrait));

File.WriteAllBytes($@"{pathDocuments}\example_page.pdf", Convert.FromBase64String(fileBase64String));