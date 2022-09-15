#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["gRPC.Demo.Server/gRPC.Demo.Server.csproj", "gRPC.Demo.Server/"]
RUN dotnet restore "gRPC.Demo.Server/gRPC.Demo.Server.csproj"
COPY . .
WORKDIR "/src/gRPC.Demo.Server"
RUN dotnet build "gRPC.Demo.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gRPC.Demo.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gRPC.Demo.Server.dll"]