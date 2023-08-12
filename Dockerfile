FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EstoqueControlApp/EstoqueControlApp.csproj", "EstoqueControlApp/" ]
RUN dotnet restore "EstoqueControlApp/EstoqueControlApp.csproj"

WORKDIR "/src/EstoqueControlApp"
COPY EstoqueControlApp/. .
RUN dotnet build "EstoqueControlApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EstoqueControlApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "EstoqueControlApp.dll" ]