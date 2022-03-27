# Products API

Contains endpoints for products. The API uses the following layers.

- Data
- Services
- Controllers
- Models
- Dtos

## Database
It uses Microsoft SQL Server. Only connection string is required.

Database is created from the app. Initial data is also set by the app.

## Data Layer

It consists of Repository pattern.

###### EF Core
EF Core is only used for database creation and migrations. 
Simple queries, CRUD operations for single tables are also done with EF Core.

###### Dapper
Dapper is used for complex SQL queries, which involve multiple tables and joins.

## Service Layer

Service layer uses the repositories from interfaces. 
Currently data layer only has SQL Server repository. 
But it can be replaced with another repository which uses another database e.g. Postgre SQL.

## Controllers Layer
It contains public endpoints. Receives requests from clients and sends them response.
Controllers use the Service layer. They do not know about any repository.
Controllers operate on the Dtos. They do not know about the Models

## Models Layer
It contains the database schema. Includes tables, keys, relationships etc.
Models are used by EF Core to store in database.
A product may use several entities in the database e.g. Product, ProductImage, Option etc.
Each model represents an actual table in the database.
Models are private. They are not exposed to the public client.

## Dtos Layer
It contains the schema to be used by external clients e.g. web app.
A product dto represents a product in single class. Internal columns may not be included.
Relationships and keys are also not included.
Dtos do not expose database schema to the client.
Dtos are public. They are exposed and published as schema in the web api.
There may be separate Dto for create, update and read.

