# Individual Tax Calculator

 This application allows a user to calculate an individual's tax based on their postal code and annual income. It has been purposefully over-engineered to practice applying DDD and Clean Architecture concepts.

 Below is a list of techniques and patterns used, as well as a list of outstanding things that should be implemented at some point. There is also a guide on how to run the application.

## How to run the application

The application is a self-contained MVC web application. You will need SQL localdb to be installed and when you launch the site, the database migrations will automatically run (the database will also automatically be created).

## Concepts

- DDD
- Clean Architecture
- Testing and Test harnessing
- Builder pattern
- Strategy pattern
- SOLID principles

## Technologies and packages

- Dotnet 7
- NUnit
- FluentAssertions
- NSubstitute
- Bogus
- Dapper
- FluentMigrator
- Bootstrap

## TODO

- Add AutoMapper
- Add SQL tests with real database (instance per test fixture)
- Add E2E tests from controller down to gateways
- Add missing CRUD elements for supporting database tables (allow managing of tables)
- Add client-side validation
- Add missing value object and entity validation
- Introduce Null Object pattern
