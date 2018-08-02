# Using wkhtmltopdf (dinktopdf) with Docker and Azure App Service

This repo demonstrates how to use DinkToPdf which is a Nuget package that acts as a wrapper around the very popular wkhtmltopdf library to provide HTML to PDF generation capabilities. 

## Issue

Many PDF generation solutions leverage User32/GDI32 and these are largely blocked in the Azure Web App sandbox. (https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#pdf-generation-from-html). 

## Solution

This example runs wkhtmltopdf as a Docker container which allows us to add the (Linux) system dependencies that are required to generate PDFs.

You could potentually deploy this solution and use it as a sort of "microservice" for generating PDF's based on HTML content.

Disclaimer:  This is a simple demo and may need to be modified by you for your specific use case (i.e. Custom Fonts, Authentication, etc).

Technologies Utilized:
* Azure App Service (Linux / Docker)
* Docker for Windows - Using Linux Containers
* .Net Core 2.1
* DinkToPdf (https://github.com/rdvojmoc/DinkToPdf) Nuget
* Docker

Example passing a url and having a PDF generated from it:
![alt text](https://github.com/adamhockemeyer/wkhtmltopdf-docker-azure-app-service/blob/master/HtmlToPDF/example.png "Example PDF")

