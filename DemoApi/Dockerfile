# Sử dụng image ASP.NET cho môi trường phát triển
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5004
EXPOSE 5005

# Cấu hình cho .NET SDK để phát triển
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug # Chuyển sang Debug mode cho phát triển
WORKDIR /src

# Copy file csproj và khôi phục các dependency
COPY ["DemoApi/DemoApi.csproj", "DemoApi/"]
RUN dotnet restore "./DemoApi/DemoApi.csproj"

# Copy toàn bộ mã nguồn vào container
COPY . .

# Build ứng dụng trong chế độ Debug
WORKDIR "/src/DemoApi"
RUN dotnet build "./DemoApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Sử dụng `dotnet watch` trong khi chạy ứng dụng để tự động cập nhật
FROM build AS final
WORKDIR /app

# Copy các tệp đã build sang container
COPY --from=build /app/build .

# Thiết lập entrypoint cho container để sử dụng dotnet watch (tự động build lại khi có thay đổi)
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5004"]

