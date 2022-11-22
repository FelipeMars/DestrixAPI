FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS build
WORKDIR /src
COPY . ./
RUN dotnet restore "./Destrix.API/Destrix.API.csproj"
WORKDIR "/src/Destrix.API"
RUN dotnet build "Destrix.API.csproj" -c Release -o /app

FROM build AS publish
WORKDIR "/src/Destrix.API"
RUN dotnet publish "Destrix.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet Destrix.API.dll
