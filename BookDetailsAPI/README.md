
# Book Details API

## Overview

The Book Details API is a RESTful API for managing book details. It integrates with the Google Books API to fetch book information based on ISBN or title. The API also allows adding book details to a database and supports searching for books by title.

## Features

* Fetch book details by ISBN from Google Books API.

* Search books by title (full or partial).

* Store book details in a database (SQL Server).

* Retrieve all stored books.

* Integrate with Blazor front-end applications.

## Technologies Used
* ASP.NET Core: Backend framework for building the API
* Entity Framework Core: ORM for database interactions.
* SQL Server: Database for persisting book details.
* Google Books API: External API for fetching book data.
* AutoMapper: Object mapping for converting DTOs and database models.
* Swashbuckle: Integration for Swagger UI.

## Installation Steps
1. Clone the repository
```
git clone <repository-url>
cd BookDetailsAPI
```
2. Setup the Database
* Update the ``` appsettings.json``` with your SQL Server connection string

```
"ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=BookDetails;User Id=your_user;Password=your_password;"
}
```
* Run migrations to create the database schema
```
dotnet ef database update
```
3. Run the application
```
dotnet run
```

## Endpoints
1. Fetch Book by ISBN
  * GET ```api/Books/{isbn}```
  * Description: Fetch book details by ISBN from Google Books API and store the data in the database

2. Search Book by Title
  * GET ```api/Books/search?title={title}```
  * Description: Searches books by title from Google Books API and store them in the database

3. Retrieve all stored Books
  * GET ```/api/Books```
  * Description: Retrieves all stored books from the database
