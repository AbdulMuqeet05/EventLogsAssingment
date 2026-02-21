# EventLogsFE

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 21.1.4.

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

## Run the application

1) docker-compose up --build -d
2) npm run start
