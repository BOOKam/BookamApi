# BookamApi

A RESTful API for a bus booking and reservation system built with ASP.NET Core 9.

## Overview

BookamApi is a backend service that enables users to search for bus routes, view available buses, and manage bookings. It provides a complete solution for bus transportation booking with user authentication, route management, and booking capabilities.

## Technologies

- **.NET 9** - Modern cross-platform framework
- **ASP.NET Core** - Web API framework
- **Entity Framework Core** - ORM for database operations
- **PostgreSQL** - Primary database (via Npgsql)
- **ASP.NET Core Identity** - User authentication and authorization
- **JWT (JSON Web Tokens)** - Secure API authentication
- **Swagger/OpenAPI** - API documentation
- **Docker** - Containerization support

## Features

- **User Authentication**
  - User registration with email confirmation
  - Admin registration
  - JWT-based login
  - Password security requirements

- **Route Management**
  - Create, read, update, and delete routes
  - Search routes by origin and destination
  - Route pricing

- **Bus Management**
  - Create, read, update, and delete buses
  - Bus capacity tracking
  - Departure and arrival times
  - Route assignment

- **User Profile Management**
  - Update user profile (name, phone, address, etc.)
  - View all users (admin)
  - Delete users (admin)

- **Booking System**
  - Booking management capabilities

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [PostgreSQL](https://www.postgresql.org/download/) database
- (Optional) [Docker](https://www.docker.com/get-started)

### Configuration

1. Clone the repository:
   ```bash
   git clone https://github.com/BOOKam/BookamApi.git
   cd BookamApi
   ```

2. Update the connection string in `BookamApi/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Your PostgreSQL connection string"
     },
     "JWT": {
       "Issuer": "your-issuer",
       "Audience": "your-audience",
       "SigningKey": "your-secret-key"
     }
   }
   ```

3. Apply database migrations:
   ```bash
   cd BookamApi
   dotnet ef database update
   ```

### Running the Application

#### Using .NET CLI

```bash
cd BookamApi
dotnet run
```

#### Using Docker

```bash
docker build -t bookamapi .
docker run -p 80:80 -p 443:443 bookamapi
```

The API will be available at `http://localhost:5000` (or the configured port).

## API Endpoints

### Account
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/account/register` | Register a new user |
| POST | `/api/account/admin/register` | Register a new admin |
| POST | `/api/account/login` | User login |
| GET | `/api/account/confirm` | Confirm email |

### Routes
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/route/getall` | Get all routes |
| GET | `/api/route/{id}` | Get route by ID |
| POST | `/api/route/create` | Create a new route |
| PUT | `/api/route/update/{id}` | Update a route |
| DELETE | `/api/route/delete/{id}` | Delete a route |
| GET | `/api/route/search` | Search routes by origin/destination |

### Buses
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/bus/getAll` | Get all buses |
| GET | `/api/bus/{id}` | Get bus by ID |
| POST | `/api/bus/create` | Create a new bus |
| PUT | `/api/bus/update/{id}` | Update a bus |
| DELETE | `/api/bus/delete/{id}` | Delete a bus |

### Users
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/user/all` | Get all users |
| PUT | `/api/user/profile/{username}` | Update user profile |
| DELETE | `/api/user/delete/{username}` | Delete a user |

## Project Structure

```
BookamApi/
├── Controllers/         # API controllers
├── Data/               # Database context
├── Dtos/               # Data transfer objects
├── Extensions/         # Extension methods
├── Interfaces/         # Service interfaces
├── Mappers/            # Object mappers
├── Migrations/         # EF Core migrations
├── Models/             # Entity models
├── Repositories/       # Data repositories
├── Services/           # Business logic services
├── Program.cs          # Application entry point
└── appsettings.json    # Configuration
```

## API Documentation

When running in development mode, Swagger UI is available at `/swagger` for interactive API documentation.

## License

This project is open source and available under the [MIT License](LICENSE).
