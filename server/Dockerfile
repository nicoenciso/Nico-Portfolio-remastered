# Usa la imagen oficial de .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /server

COPY . .
RUN dotnet restore

RUN dotnet publish -c Release -o out

# Usa la imagen oficial de .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /server
COPY --from=build /server/out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "server.dll"]