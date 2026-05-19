# Стадия 1: Сборка
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["n33.csproj", "./"]
RUN dotnet restore "nз3.csproj"
COPY . .
RUN dotnet build "nз3.csproj" -c Release -o /app/build

# Стадия 2: Публикация
FROM build AS publish
RUN dotnet publish "nз3.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Стадия 3: Запуск
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
RUN mkdir -p /app/data
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "nз3.dll"]