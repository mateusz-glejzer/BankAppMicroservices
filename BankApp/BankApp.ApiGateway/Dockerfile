FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BankApp.ApiGateway/BankApp.ApiGateway.csproj", "BankApp.ApiGateway/"]
RUN dotnet restore "BankApp.ApiGateway/BankApp.ApiGateway.csproj"
COPY . .
WORKDIR "/src/BankApp.ApiGateway"
RUN dotnet build "BankApp.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankApp.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankApp.ApiGateway.dll"]
