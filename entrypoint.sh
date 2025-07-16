#!/bin/bash
# entrypoint.sh

# Arrête le script si une commande échoue
set -e

# Ces variables sont utilisées par pg_isready. Le PGPASSWORD évite un prompt de mot de passe.
DB_HOST="postgres"
DB_USER="confplan"
DB_NAME="confplan"
export PGPASSWORD="confplan"

echo "--- Waiting for database to be ready at ${DB_HOST}... ---"

# Boucle jusqu'à ce que la base de données soit prête
until pg_isready -h "$DB_HOST" -U "$DB_USER" -d "$DB_NAME"; do
  >&2 echo "Postgres is unavailable - sleeping"
  sleep 2
done

>&2 echo "--- Postgres is up and running ---"

echo "--- Applying Entity Framework migrations via bundle... ---"

# Exécution des migrations en utilisant le bundle auto-contenu.
# La chaîne de connexion est lue depuis la variable d'environnement définie dans docker-compose.yml
./efbundle --connection "$ConnectionStrings__PostgresDBContext"

echo "--- Migrations applied successfully ---"

echo "--- Starting application... ---"

# 'exec' remplace le processus du script par celui de l'application .NET.
# C'est important pour que les signaux Docker (comme l'arrêt) soient bien gérés.
exec dotnet ConfPlan.Api.dll
