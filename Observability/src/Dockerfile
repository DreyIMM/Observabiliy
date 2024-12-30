
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app



FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OBSLI.Api/OBSLI.Api.csproj", "src/OBSLI.Api/"]
COPY ["OBSI.Infra/OBSI.Infra.csproj", "src/OBSI.Infra/"]
RUN dotnet restore "src/OBSLI.Api/OBSLI.Api.csproj"
COPY . .
WORKDIR "/src/OBSLI.Api"
RUN dotnet build "./OBSLI.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OBSLI.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


EXPOSE 8080
EXPOSE 8081


ENTRYPOINT ["dotnet", "OBSLI.Api.dll"]