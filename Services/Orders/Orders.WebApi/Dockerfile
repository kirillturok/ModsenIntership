#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Orders/Orders.WebApi/Orders.WebApi.csproj", "Services/Orders/Orders.WebApi/"]
RUN dotnet restore "Services/Orders/Orders.WebApi/Orders.WebApi.csproj"
COPY . .
WORKDIR "/src/Services/Orders/Orders.WebApi"
RUN dotnet build "Orders.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Orders.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Orders.WebApi.dll"]