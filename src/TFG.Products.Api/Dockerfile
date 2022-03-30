#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TFG.Products.Api/TFG.Products.Api.csproj", "src/TFG.Products.Api/"]
COPY ["src/TFG.Products.Infrastructure/TFG.Products.Infrastructure.csproj", "src/TFG.Products.Infrastructure/"]
COPY ["src/TFG.Products.Application/TFG.Products.Application.csproj", "src/TFG.Products.Application/"]
COPY ["src/TFG.Products.Domain/TFG.Products.Domain.csproj", "src/TFG.Products.Domain/"]
RUN dotnet restore "src/TFG.Products.Api/TFG.Products.Api.csproj"
COPY . .
WORKDIR "/src/src/TFG.Products.Api"
RUN dotnet build "TFG.Products.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TFG.Products.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TFG.Products.Api.dll"]
