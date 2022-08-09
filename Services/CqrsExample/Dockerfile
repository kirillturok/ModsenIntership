#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/CqrsExample/CqrsExample.csproj", "Services/CqrsExample/"]
RUN dotnet restore "Services/CqrsExample/CqrsExample.csproj"
COPY . .
WORKDIR "/src/Services/CqrsExample"
RUN dotnet build "CqrsExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CqrsExample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CqrsExample.dll"]