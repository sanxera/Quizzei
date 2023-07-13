# Quizzei
Jornada/TCC da faculdade SENAI.

# Setup para o projeto backend .NET

Para o funcionamento correto do projeto, instalar:

* .NET 7: https://dotnet.microsoft.com/pt-br/download/dotnet/7.0
* SQL Server: https://www.microsoft.com/pt-br/sql-server/sql-server-downloads
* OCR: https://ocrmypdf.readthedocs.io/en/latest/
    * Configurar caminho do OcrMyPdf no OcrService.cs
* AWS:
    * Criar conta na AWS e configurar um bucket público para as imagens
    * Deve criar duas pastas:
      * /Files
      * /Images
    * Gerar credências de secretKey e accessKey e configurar no appSettings.json



