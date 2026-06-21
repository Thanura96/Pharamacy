# Pharmacy Management System

A desktop Pharmacy Management System built with **C#**, **.NET Framework 4.6**, **Windows Forms**, and **MongoDB**. The application supports role-based access for **Admin** and **Customer** users.

## Features

### Admin Portal

- Dashboard with summary cards (total sales, medicines, low stock, active orders)
- Expiry alerts (medicines expiring within 30 days and already expired)
- Medicine management (add, update, delete, search) with dosage, supplier, discount, and prescription flags
- Customer management (add, update, search) with full contact and login credentials
- Counter sales processing with automatic stock reduction
- Order management (view orders, update status, view prescriptions)
- Tabbed reports (sales, stock, customer order history) with PDF and Excel export

### Customer Portal

- Self-service registration
- Medicine search with filters, sorting, and add-to-cart
- Shopping cart with discount calculation and prescription upload
- Online checkout with stock validation and order placement
- Order tracking and order history export (PDF / Excel)
- Profile view

### Platform

- Centralized validation (`ValidationService`)
- Global exception handling (`GlobalExceptionHandler`)
- File-based logging (`LogService`)
- MongoDB persistence with automatic seed data

## Architecture

The project follows a layered architecture wired through `PharmacyAppContext`:

```
Forms (UI)
   ↓
Services (Business Logic + Interfaces)
   ↓
Repositories (Data Access + IRepository<T>)
   ↓
MongoDB (PharmacyDB)
```

### Design Principles

| Principle | Implementation |
|-----------|----------------|
| **Encapsulation** | Business rules live in services; forms delegate to `PharmacyAppContext` |
| **Inheritance** | `User` → `Admin`, `Customer`; all forms inherit `BaseForm` |
| **Abstraction** | `IValidationService`, `IInventoryService`, `ICartService`, `IExportService`, `INotificationService`, `IOrderRepository`, `IRepository<T>` |
| **Repository pattern** | MongoDB CRUD isolated in repository classes |

### Key Services

| Service | Purpose |
|---------|---------|
| `MedicineService` | Medicine CRUD and admin search |
| `CustomerService` | Customer CRUD and search |
| `SaleService` | Admin counter-sales transactions |
| `CartService` | Customer shopping cart |
| `MedicineSearchService` | Customer medicine search with filters |
| `ValidationService` | Input and order validation |
| `InventoryService` | Stock, low-stock, and expiry checks |
| `DashboardService` | Admin dashboard metrics |
| `ReportService` | Admin reporting data |
| `ExportService` | PDF and Excel order export |
| `ExpiryNotificationService` | Expiry alerts |
| `LogService` | Centralized file logging |

## Navigation Flow

```
LoginForm
├── RegistrationForm (customer self-registration, modal)
│
├── [Admin role]
│   └── AdminDashboardForm
│         ├── MedicineForm
│         ├── CustomerForm
│         ├── SalesForm
│         ├── OrderManagementForm
│         ├── ReportsForm
│         └── Exit
│
└── [Customer role]
    └── CustomerDashboardForm
          ├── SearchMedicineForm
          ├── MyCartForm
          ├── MyOrdersForm
          ├── CustomerProfileForm
          └── Logout → LoginForm
```

## Default Login Credentials

### Admin

| Field | Value |
|-------|-------|
| Username | `admin` |
| Password | `admin123` |

Select **Admin** on the login screen before signing in.

### Sample Customers (seeded)

| Username | Password | Name |
|----------|----------|------|
| `johndoe` | `pass123` | John Doe |
| `janesmith` | `pass123` | Jane Smith |
| `robertj` | `pass123` | Robert Johnson |
| `emilyd` | `pass123` | Emily Davis |

Select **Customer** on the login screen before signing in.

## Sample Seed Data

On first login, `DatabaseSeeder` inserts sample data when collections are empty.

**Medicines:** Paracetamol, Amoxicillin (prescription required), Vitamin C — each with dosage, supplier, and discount fields.

**Customers:** Four sample accounts with address, email, username, and password (see table above).

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
- Validation service (medicine, customer, order, registration)
- Export service (PDF and Excel file creation)
- System workflow scenarios (admin and customer paths)

## Logging

Application logs are written to:

```
%LOCALAPPDATA%\PharmacySystem\Logs\pharmacy_YYYYMMDD.log
```

Logged events include application startup, login, CRUD operations, sales, orders, exports, and unhandled exceptions.

## Requirements

- Windows 10 or later
- Visual Studio 2015 or later
- .NET Framework 4.6
- MongoDB 4.x or later

## Project Structure

```
PharmacySystem/
├── Core/              PharmacyAppContext (service wiring)
├── Database/          MongoDbContext
├── Forms/             WinForms UI (admin + customer portals)
├── Infrastructure/    GlobalExceptionHandler
├── Logging/           ILogger interface
├── Models/            Domain models (User, Medicine, Order, Sale, …)
├── Repositories/      Data access layer
├── Services/          Business logic and interfaces
└── Utilities/         Helpers, validation, and seed data

PharmacySystem.Tests/  Unit and workflow tests
docs/                  Project documentation
```

## License

Educational project for pharmacy management coursework and demonstrations.
