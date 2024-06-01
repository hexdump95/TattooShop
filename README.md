# Tattoo Shop

## Technologies and tools used
- Language: C#
- Framework: ASP.NET Core 8.0
- IDE: Rider
- Testing Framework: xUnit
- Database: Microsoft SQL Server
- Containerization: Docker
- CI/CD: Jenkins

## Run the project

### Define environment variables

#### Database connection:
```sh
ConnectionStrings__DefaultConnection="Server=localhost; User Id=SA; Password=P4ssword123#123; Database=webapp;TrustServerCertificate=True;"
```

#### Jwt:
```sh
Jwt__Key="12345678901234567890123456789012"
```
```sh
Jwt__Issuer="hexdump95"
```
```sh
Jwt__ExpiresAfterMinutes=180
```
