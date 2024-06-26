﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine3.18

WORKDIR /app
LABEL org.opencontainers.image.authors="Sergio Villanueva <sergiovillanueva@protonmail.com>"
EXPOSE 8080

COPY ./src/Tattoo/bin/Release/net8.0/publish/ .

CMD ["dotnet", "Tattoo.dll"]
