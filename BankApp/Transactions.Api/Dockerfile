FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Transactions.Api/Transactions.Api.csproj", "Transactions.Api/"]
RUN dotnet restore "Transactions.Api/Transactions.Api.csproj"
COPY . .
WORKDIR "/src/Transactions.Api"
RUN dotnet build "Transactions.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Transactions.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transactions.Api.dll"]
