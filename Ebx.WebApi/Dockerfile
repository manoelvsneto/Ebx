FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt-get update && apt-get install -y telnet

WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Ebx.WebApi/Ebx.WebApi.csproj", "Ebx.WebApi/"]
COPY ["Ebx.Models/Ebx.Models.csproj", "Ebx.Models/"]
COPY ["Ebx.Data/Ebx.Data.csproj", "Ebx.Data/"]
COPY ["Ebx.Service/Ebx.Service.csproj", "Ebx.Service/"]
COPY ["Ebx.Repository/Ebx.Repository.csproj", "Ebx.Repository/"]
RUN dotnet restore "Ebx.WebApi/Ebx.WebApi.csproj"
COPY . .
WORKDIR "/src/Ebx.WebApi"
RUN dotnet build "Ebx.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ebx.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ebx.WebApi.dll"]