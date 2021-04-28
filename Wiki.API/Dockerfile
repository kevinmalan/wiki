#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Wiki.API/Wiki.API.csproj", "Wiki.API/"]
COPY ["Wiki.Core/Wiki.Core.csproj", "Wiki.Core/"]
COPY ["Wiki.Common/Wiki.Common.csproj", "Wiki.Common/"]
RUN dotnet restore "Wiki.API/Wiki.API.csproj"
COPY . .
WORKDIR "/src/Wiki.API"
RUN dotnet build "Wiki.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Wiki.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Wiki.API.dll"]