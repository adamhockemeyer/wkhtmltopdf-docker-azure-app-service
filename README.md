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

## Try it out in 2 minutes!

You can try out this example quickly by using a Docker image that is built based on this repo and is published to Docker Hub.

1. Login to the [Azure Portal](portal.azure.com)
2. Create a new resource and select 'Web App'.
3. Fill in your app name, resource group, select 'Docker' for the OS, and pick your App Service Plan Size.
4. Finally under 'Configure Container' select 'Docker Hub' as the image source, keep the Repository Access on 'Public' and then enter '**hock2k5/wkhtmltopdf-netcore:latest**' into the box titled 'Image and optional tag (eg 'image:tag').
5. Click 'OK', and then click 'Create' and you are done!
6. Once you web app (app service) is created, you will need to visit the url based on the app name you selected to start the process of the docker image being pulled down into your web app.  This can take a few minutes.  You can check on the status by going into your web app, and under the 'Settings' blade on the left side, click on 'Container settings' and from their you can view the logs.  If nothing shows up under logs you may need to go to the 'Diagnostic logs' section under monitoring and enable logs.

![alt text](https://github.com/adamhockemeyer/wkhtmltopdf-docker-azure-app-service/blob/master/HtmlToPDF/azure-setup.png "Azure Setup")
