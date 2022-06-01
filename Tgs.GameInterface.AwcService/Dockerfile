#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BuildConfiguration=Release
RUN --mount=type=secret,id=nuget,dst=/pat cp /pat ~/.nuget/NuGet/NuGet.Config
RUN dotnet nuget remove source 'Microsoft Visual Studio Offline Packages' || true
WORKDIR /src
COPY ["NuGet.config", "."]
COPY ["Tgs.GameInterface.AwcService/Tgs.GameInterface.AwcService.csproj", "Tgs.GameInterface.AwcService/"]
COPY ["Tgs.GameInterface.AwcService.Repositories/Tgs.GameInterface.AwcService.Repositories.csproj", "Tgs.GameInterface.AwcService.Repositories/"]
COPY ["Tgs.GameInterface.AwcService.Core/Tgs.GameInterface.AwcService.Core.csproj", "Tgs.GameInterface.AwcService.Core/"]
RUN dotnet restore "Tgs.GameInterface.AwcService/Tgs.GameInterface.AwcService.csproj"
COPY . .
WORKDIR "/src/Tgs.GameInterface.AwcService"
RUN dotnet build "Tgs.GameInterface.AwcService.csproj" -c $BuildConfiguration -o /app/build

FROM build AS publish
ARG BuildConfiguration
RUN dotnet publish "Tgs.GameInterface.AwcService.csproj" -c $BuildConfiguration -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tgs.GameInterface.AwcService.dll"]