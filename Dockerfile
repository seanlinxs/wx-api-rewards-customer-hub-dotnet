# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY ./. ./wx-api-rewards-customer-hub

# nuget restore
WORKDIR /source/wx-api-rewards-customer-hub
RUN dotnet restore

# build app
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
ENV ASPNETCORE_URLS=http://+:8080
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "wx-api-rewards-customer-hub.dll"]