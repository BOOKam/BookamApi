FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/
# Try just copying everything first
COPY . .
RUN dotnet restore "BookamApi/BookamApi.csproj"
RUN dotnet build "BookamApi/BookamApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookamApi/BookamApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookamApi/BookamApi.dll"]
