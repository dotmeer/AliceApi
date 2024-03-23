FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

EXPOSE 8000

COPY . .

WORKDIR /dotmeer.AliceApi.Api
RUN dotnet restore "dotmeer.AliceApi.Api.csproj"
RUN dotnet build "dotmeer.AliceApi.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotmeer.AliceApi.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotmeer.AliceApi.Api.dll"]
