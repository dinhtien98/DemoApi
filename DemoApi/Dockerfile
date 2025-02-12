# Sử dụng SDK để build
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

# Copy file project và build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DemoApi.csproj", "./"]
RUN dotnet restore "DemoApi.csproj"
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Chạy ứng dụng
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DemoApi.dll"]
