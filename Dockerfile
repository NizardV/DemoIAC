# Base image pour .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Base image pour le build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /demoiac

# Installer Node.js
RUN apt-get update && apt-get install -y curl && \
    curl -fsSL https://deb.nodesource.com/setup_18.x | bash - && \
    apt-get install -y nodejs

# Copier les fichiers .csproj et restaurer les dépendances
COPY ./demoiac/DemoIAC.Server/DemoIAC.Server.csproj ./DemoIAC.Server/
COPY ./demoiac/DemoIAC.Tools/DemoIAC.Tools.csproj ./DemoIAC.Tools/
RUN dotnet restore "./DemoIAC.Server/DemoIAC.Server.csproj"

# Copier le reste des fichiers et construire le projet
COPY ./demoiac/DemoIAC.Server ./DemoIAC.Server/
COPY ./demoiac/DemoIAC.Tools ./DemoIAC.Tools/
WORKDIR /demoiac/DemoIAC.Server
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

# Préparer le front-end
WORKDIR /frontend
COPY ./demoiac/demoiac.client/package.json ./
COPY ./demoiac/demoiac.client ./
RUN npm install
RUN npm run build

# Image finale
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DemoIAC.Server.dll"]
