# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.csproj ./wx-api-rewards-customer-hub
RUN dotnet restore

# copy everything else and build app
COPY . ./wx-api-rewards-customer-hub
WORKDIR /source/wx-api-rewards-customer-hub
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "wx-api-rewards-customer-hub.dll"]