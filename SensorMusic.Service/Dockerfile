#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SensorMusic.Service/SensorMusic.Services.csproj", "SensorMusic.Service/"]
COPY ["SensorMusic.Infra.Data/SensorMusic.Infra.Data.csproj", "SensorMusic.Infra.Data/"]
COPY ["SensorMusic.Domain/SensorMusic.Domain.csproj", "SensorMusic.Domain/"]
COPY ["SensorMusic.Application/SensorMusic.Application.csproj", "SensorMusic.Application/"]
RUN dotnet restore "SensorMusic.Service/SensorMusic.Services.csproj"
COPY . .
WORKDIR "/src/SensorMusic.Service"
RUN dotnet build "SensorMusic.Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SensorMusic.Services.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SensorMusic.Services.dll"]
