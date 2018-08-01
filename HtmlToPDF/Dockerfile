FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
RUN apt update
RUN apt install -y libgdiplus
RUN ln -s /usr/lib/libgdiplus.so /lib/x86_64-linux-gnu/libgdiplus.so
RUN apt-get install -y --no-install-recommends zlib1g fontconfig libfreetype6 libx11-6 libxext6 libxrender1 wget gdebi
RUN wget https://github.com/wkhtmltopdf/wkhtmltopdf/releases/download/0.12.5/wkhtmltox_0.12.5-1.stretch_amd64.deb
RUN gdebi --n wkhtmltox_0.12.5-1.stretch_amd64.deb
RUN apt install libssl1.0-dev
RUN ln -s /usr/local/lib/libwkhtmltox.so /usr/lib/libwkhtmltox.so
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY HtmlToPDF/HtmlToPDF.csproj HtmlToPDF/
RUN dotnet restore HtmlToPDF/HtmlToPDF.csproj
COPY . .
WORKDIR /src/HtmlToPDF
RUN dotnet build HtmlToPDF.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish HtmlToPDF.csproj -c Release -o /app

FROM base AS final
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HtmlToPDF.dll"]