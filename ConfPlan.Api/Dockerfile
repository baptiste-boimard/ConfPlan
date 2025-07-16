# ConfPlan.Api/Dockerfile

# Étape 1: Build - Utilise le SDK complet pour construire l'application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copier les fichiers projet (.csproj) et le fichier solution (.sln)
COPY ["ConfPlan.sln", "."]
COPY ["ConfPlan.Api/ConfPlan.Api.csproj", "ConfPlan.Api/"]
COPY ["ConfPlan.Client/ConfPlan.Client.csproj", "ConfPlan.Client/"]
COPY ["ConfPlan.Shared/ConfPlan.Shared.csproj", "ConfPlan.Shared/"]

# Restaurer les dépendances en se basant uniquement sur les fichiers projet.
RUN dotnet restore "ConfPlan.sln"

# Copier tout le reste du code source (en respectant .dockerignore)
COPY . .

# Publier l'application API.
WORKDIR /src/ConfPlan.Api
RUN dotnet publish "ConfPlan.Api.csproj" -c Release -o /app/publish --no-restore


# Étape 2: Migrations - Crée un bundle de migration autonome
FROM build AS migrations
WORKDIR /src/ConfPlan.Api

# CORRECTION : Installer l'outil dotnet-ef et l'ajouter au PATH
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Crée un exécutable autonome pour les migrations nommé 'efbundle'.
# Cette commande va maintenant fonctionner car dotnet-ef est installé.
RUN dotnet ef migrations bundle --self-contained -r linux-x64 -o /app/efbundle


# Étape 3: Final - Commence avec l'image runtime légère d'ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Installer le client postgresql pour que le script d'entrée puisse utiliser 'pg_isready'
RUN apt-get update && apt-get install -y --no-install-recommends postgresql-client && rm -rf /var/lib/apt/lists/*

# Copier l'application publiée depuis l'étape de build
COPY --from=build /app/publish .

# Copier l'exécutable des migrations depuis l'étape des migrations
COPY --from=migrations /app/efbundle .

# Copier le script d'entrée qui va utiliser le bundle
COPY entrypoint.sh .
RUN chmod +x ./entrypoint.sh

# Définir le point d'entrée
ENTRYPOINT ["./entrypoint.sh"]
