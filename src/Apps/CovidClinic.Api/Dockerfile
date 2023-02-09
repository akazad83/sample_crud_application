#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#ENV ASPNETCORE_URLS=https://+:5006;http://+:5005
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Apps/CovidClinic.Api/CovidClinic.Api.csproj", "src/Apps/CovidClinic.Api/"]
COPY ["src/Common/CovidClinic.Infrastructure/CovidClinic.Infrastructure.csproj", "src/Common/CovidClinic.Api.Infrastructure/"]
COPY ["src/Common/CovidClinic.Application/CovidClinic.Application.csproj", "src/Common/CovidClinic.Api.Application/"]
COPY ["src/Common/CovidClinic.Domain/CovidClinic.Domain.csproj", "src/Common/CovidClinic.Api.Domain/"]
RUN dotnet restore "src/Apps/CovidClinic.Api/CovidClinic.Api.csproj"
COPY . .
WORKDIR "/src/src/Apps/CovidClinic.Api"
RUN dotnet build "CovidClinic.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CovidClinic.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CovidClinic.Api.dll"]