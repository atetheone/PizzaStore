# PizzaStore API

PizzaStore est une API simple qui permet de gérer des pizzas en utilisant ASP.NET Core et Entity Framework Core. L'objectif de ce projet est de créer, lire, mettre à jour et supprimer des informations sur des pizzas, en utilisant SQLite comme base de données pour la persistance des données.

## Fonctionnalités
- **CRUD des Pizzas** : Création, lecture, mise à jour, et suppression de pizzas.
- **SQLite pour la persistance des données** : Les pizzas sont sauvegardées dans une base de données SQLite.
- **Swagger pour la documentation** : Swagger UI est utilisé pour documenter et tester l'API de manière interactive.

## Prérequis
- **.NET 6 SDK** : Pour compiler et exécuter l'application.
- **SQLite** : Utilisé pour la persistance des données.
- **Entity Framework Core** : Utilisé pour gérer la base de données et les migrations.

## Installation et Exécution
1. **Cloner le dépôt** :
   ```bash
   git clone https://github.com/atetheone/PizzaStore
   cd PizzaStore
   ```

2. **Installer les dépendances** :
    - Installer les packages nécessaires, incluant EF Core SQLite et EF Core Design :
      ```bash
      dotnet restore
      ```

3. **Configurer la Base de Données** :
    - Générer la migration initiale et mettre à jour la base de données :
      ```bash
      dotnet ef migrations add InitialCreate
      dotnet ef database update
      ```

4. **Lancer l'Application** :
    - Pour lancer l'application, exécutez :
      ```bash
      dotnet run
      ```
    - L'application sera accessible sur `http://localhost:5240` .

5. **Accéder à Swagger** :
    - Ouvrez un navigateur et allez à :
      ```
      https://localhost:7277/swagger
      ```
    - Utilisez Swagger pour tester les différents endpoints.

## Endpoints Disponibles

- **GET /pizzas** : Récupérer toutes les pizzas.
- **GET /pizza/{id}** : Récupérer une pizza par son ID.
- **POST /pizza** : Ajouter une nouvelle pizza.
    - Corps de la requête :
      ```json
      {
        "nom": "Margherita",
        "description": "Pizza classique avec mozzarella et basilic"
      }
      ```
- **PUT /pizza/{id}** : Mettre à jour une pizza existante.
    - Corps de la requête :
      ```json
      {
        "nom": "Pepperoni",
        "description": "Pizza à la mozzarella et pepperoni"
      }
      ```
- **DELETE /pizza/{id}** : Supprimer une pizza par son ID.

## Technologies Utilisées
- **ASP.NET Core** : Framework pour créer des APIs web.
- **Entity Framework Core** : ORM pour la gestion de la base de données.
- **SQLite** : Base de données locale légère.
- **Swagger** : Documentation interactive de l'API.

## Processus de Développement
- **Configuration Initiale** : Création du projet ASP.NET Core avec une API minimale et intégration de Swagger.
- **Ajout de SQLite** : Utilisation d'Entity Framework Core pour la connexion à une base de données SQLite. Configuration des migrations pour créer la base de données initiale.
- **Mise en Place des Endpoints CRUD** : Développement des routes pour gérer les pizzas (à partir de la création jusqu'à la suppression).
- **Test des Fonctionnalités** : Test de chaque endpoint via Swagger pour s'assurer que toutes les opérations CRUD fonctionnent correctement et que la persistance des données dans SQLite est effective.

## Auteurs
- **Até Tougué Aristide** : Développeur principal de l'application PizzaStore.

## Licence
Ce projet est sous licence MIT - consultez le fichier `LICENSE` pour plus de détails.

