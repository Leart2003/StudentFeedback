# Student Feedback

A student feedback web application built with ASP.NET Core MVC and Entity Framework Core. Authenticated users submit ratings and comments for academic subjects, and the application aggregates the responses into a sentiment chart.

## Features

- ASP.NET Core Identity registration and login
- Subject selection and feedback submission
- Five-point sentiment ratings
- Personal feedback history
- Aggregated stacked-bar results chart with Chart.js
- SQL Server persistence with Entity Framework Core migrations

## Tech stack

- C# / ASP.NET Core MVC `.NET 10`
- Entity Framework Core 10
- SQL Server
- ASP.NET Core Identity
- Razor views
- Bootstrap, jQuery, and jQuery Validation
- Chart.js 4.4.1

## Getting started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- A SQL Server instance, or an Azure SQL database
- Optional: Visual Studio 2026 or a compatible editor

### Configure the database

The application reads the `DefaultConnection` connection string from configuration.

For local development, create a user secret or environment variable without committing credentials:

```bash
cd StudentFeedback
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=StudentFeedback;Trusted_Connection=True;TrustServerCertificate=True"
```

Then apply the migrations:

```bash
dotnet ef database update
```

To use a different SQL Server connection, replace `StudentFeedback/appsettings.json` in an environment-specific deployment configuration or set `ConnectionStrings__DefaultConnection` as an environment variable.

### Run the application

```bash
dotnet restore
dotnet run --project StudentFeedback/StudentFeedback.csproj
```

The HTTPS launch profile is available at `https://localhost:7079`; the HTTP profile runs at `http://localhost:5229`.

Open `/Identity/Account/Register` to create an account, then sign in to submit feedback.

## Application structure

```text
StudentFeedback.slnx          Solution entry point
StudentFeedback/
  Areas/Identity/             ASP.NET Identity Razor pages
  Controllers/
    FeedbackController.cs     Feedback submission, history, and result aggregation
    HomeController.cs         Landing and error handling
  Data/
    ApplicationDbContext.cs   EF Core Identity and application DbSets
    Migrations/               Identity and application database migrations
  Models/
    Feedback.cs               Student feedback entity
    Subject.cs                Subject entity
    Sentiment.cs              Five-value feedback rating enum
    ResultsViewModel.cs       Chart result data
  Views/
    Feedback/                 Create and results Razor views
    Home/                     Home and privacy views
    Shared/                   Layout and shared partial views
  wwwroot/                    Static CSS, JavaScript, and client libraries
  appsettings.json            Database and logging configuration
  Program.cs                  Application setup and middleware pipeline
```

## How it works

`Program.cs` registers `ApplicationDbContext` with SQL Server, configures ASP.NET Core Identity, and enables MVC controllers and Razor Pages. `FeedbackController` requires authentication. It records the signed-in user's name, stores feedback against a subject, and provides a personal feedback history. The results action groups feedback by subject and sentiment and serializes the totals for the Chart.js stacked horizontal bar chart.

`ApplicationDbContext` extends `IdentityDbContext`, contains `Subject` and `Feedback` sets, and seeds five subjects, including four required subjects and one elective.

## Database migrations

Create a migration after changing EF Core entities:

```bash
dotnet ef migrations add <MigrationName> --project StudentFeedback/StudentFeedback.csproj
```

Apply migrations with:

```bash
dotnet ef database update --project StudentFeedback/StudentFeedback.csproj
```

## Development notes

- The `DefaultConnection` connection string is currently deployment-specific. Configure it locally through user secrets or environment variables.
- The Identity UI scaffolding is partially generated: the application has the Identity area and login partial, while ASP.NET Core Identity provides its account pages.
- `Views/Feedback/resultcshtml.cshtml` is the Razor view rendered by `FeedbackController.Results()`.

## License

No license has been specified for this repository.