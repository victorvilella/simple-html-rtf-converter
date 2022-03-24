# Simple HTML and RTF converter

## Instructions (with docker)
* docker build --tag html-converter .
* docker run -p 80:5000 html-converter

## Instructions (without docker)
* dotnet restpre
* dotnet publish -c Release -o out/
* dotnet out/Api.dll

## Endpoints
* POST in `http://localhost:5000/to_html` for convert RTF string to HTML string
* POST in `http://localhost:5000/to_rtf` for convert HTML string to RTF string
