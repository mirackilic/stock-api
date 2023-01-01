FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /src
COPY . .
WORKDIR /src/Stock.API/
RUN dotnet restore
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 as runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Stock.API.dll"]