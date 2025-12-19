FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file first (better caching + correctness)
COPY DemoApi.csproj ./
RUN dotnet restore DemoApi.csproj

# Copy the rest of the source
COPY . .
RUN dotnet publish DemoApi.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DemoApi.dll"]
