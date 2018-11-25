FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY web_api_docker/web_api_docker.csproj web_api_docker/
RUN dotnet restore web_api_docker/web_api_docker.csproj
COPY . .
WORKDIR /src/web_api_docker
RUN dotnet build web_api_docker.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish web_api_docker.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "web_api_docker.dll"]
