# EventLogs Project (Fullstack)

This project consists of a .NET Core Backend and an Angular Frontend, orchestrated using Docker for easy setup and deployment.

## Project Structure

```text
.
├── EventLogs/          # Backend Application (.NET Core)
├── EventLogsFE/        # Frontend Application (Angular)
└── docker-compose.yml  # Root orchestration file
```

# EventLogsFE

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 21.1.4.

``` text
src/app/
├── core/                # Global singletons (Interceptors, Auth, Base Services)
│   └── interceptors/    # API Base URL & Header logic
├── shared/              # Reusable UI components (Tables, Spinners, Pagination)
├── features/            # Business logic modules
│       ├── models/      # TypeScript Interfaces (EventLog)
│       ├── services/    # Logic & State (BehaviorSubjects)
│       └── event-logs.component.ts
├── app.config.ts        # Application providers (HttpClient, Routing)
└── app.routes.ts        # Main routing configuration
```

## Run the application

1) docker-compose up --build -d
2) npm run start


# Event Logging System (.NET 9)

A real-time log generation and monitoring system built with **ASP.NET Core 9**. This project demonstrates Clean Architecture, thread-safe background processing, and containerization.

## Architecture

The solution is organized into Three distinct layers:

* **Application**: `IHostedService` background worker and service interfaces.
* **Infrastructure**: Implementation of the `IEventStore` using `ConcurrentQueue`.
* **Web API**: REST Controllers, Dependency Injection registration, and Docker setup.

---

## How to Run

### Option 1: Docker

Run the application in a containerized environment with a single command:

```bash
docker-compose up --build
```

### Option 2: Local .NET CLI

* **Run with IDE**: Run with IDE Visual Studio or Rider or VSCode.
* **Run with Command Line**: dotnet restore. dotnet run --project WebApplication1/WebApplication1.csproj.

---

