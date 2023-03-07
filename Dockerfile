FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy .csproj and restore as distinct layers
COPY "Api_Pedidos.sln" "Api_Pedidos.sln"
COPY "Api_Pedidos.csproj" "Api_Pedidos.csproj"

RUN dotnet restore "Api_Pedidos.sln"

# Copy everything else, and build
COPY . .
WORKDIR /app
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "Api_Pedidos.dll" ]