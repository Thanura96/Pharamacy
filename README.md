# Pharmacy Management System

A desktop Pharmacy Management System built with **C#**, **.NET Framework 4.6**, **Windows Forms**, and **MongoDB**.

## Features

- Secure login and dashboard navigation
- Medicine management (add, update, delete, search)
- Customer management (add, search)
- Sales processing with automatic stock reduction
- Inventory monitoring (low stock and expiry checks)
- Business reports with tabbed views
- File-based application logging
- Centralized validation and exception handling

## Architecture

The project follows a layered architecture:

```
Forms (UI)
   ↓
Services (Business Logic)
   ↓
Repositories (Data Access)
   ↓
MongoDB (PharmacyDB)
```

### Design Principles

- **Encapsulation** — Services hide business rules from the UI
- **Abstraction** — Interfaces such as `IInventoryService` and `IValidationService`
- **Inheritance** — Shared behavior in `BaseForm`
- **Repository Pattern** — MongoDB CRUD isolated in repository classes

## Navigation Flow

```
LoginForm → DashboardForm
              ├── MedicineForm
              ├── CustomerForm
              ├── SalesForm
              └── ReportForm
```

## Default Login

| Field | Value |
|-------|-------|
| Username | `Admin` |
| Password | `admin123` |

## Sample Seed Data

On first login, the system seeds MongoDB if collections are empty:

**Medicines**
- Paracetamol
- Amoxicillin
- Vitamin C

**Customers**
- John Doe
- Jane Smith
- Robert Johnson
- Emily Davis

## Documentation

- [Installation Guide](docs/INSTALLATION.md)
- [Database Setup Guide](docs/DATABASE_SETUP.md)
- [User Manual](docs/USER_MANUAL.md)

## Running Tests

Open the solution in Visual Studio and run **Test Explorer** for the `PharmacySystem.Tests` project.

Test coverage includes:
- Medicine module (add, update, delete, search)
- Customer module (add, search)
- Sales module (calculate total, complete sale, stock reduction)
- Inventory module (low stock, expiry checks)
- Validation service

## Logging

Application logs are written to:

```
%LOCALAPPDATA%\PharmacySystem\Logs\pharmacy_YYYYMMDD.log
```

## Requirements

- Windows 10 or later
- Visual Studio 2015 or later
- .NET Framework 4.6
- MongoDB 4.x or later

## Project Structure

```
PharmacySystem/
├── Core/              Application context and wiring
├── Database/          MongoDB connection
├── Forms/             WinForms UI
├── Infrastructure/    Global exception handling
├── Logging/           File logger
├── Models/            Domain models
├── Repositories/      Data access layer
├── Services/          Business logic
└── Utilities/         Helpers and seed data

PharmacySystem.Tests/  Unit tests
docs/                  Project documentation
```

## License

Educational project for pharmacy management coursework and demonstrations.
