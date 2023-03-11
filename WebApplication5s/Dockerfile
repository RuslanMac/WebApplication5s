#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["WebApplication5s/WebApplication5s.csproj", "WebApplication5s/"]
RUN dotnet restore "WebApplication5s/WebApplication5s.csproj"
COPY . .
WORKDIR "/src/WebApplication5s"
RUN dotnet build "WebApplication5s.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplication5s.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication5s.dll"]