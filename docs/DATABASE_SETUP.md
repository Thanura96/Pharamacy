# Database Setup Guide

## Overview

The **SmartMed Pharmacy** application uses **MongoDB** as its database backend.

| Setting | Value |
|---------|-------|
| Database Name | `PharmacyDB` |
| Default Connection | `mongodb://localhost:27017` |

## Collections

| Collection | Purpose |
|------------|---------|
| `Medicines` | Medicine inventory (name, category, price, stock, expiry, dosage, supplier, discount, prescription flag) |
| `Customers` | Registered customers (extends `User`: full name, email, phone, address, username, password) |
| `Sales` | Admin counter-sales transactions (legacy in-store sales) |
| `Orders` | Customer online orders (items, status, prescription path, discounts) |

There is no separate `Admins` collection. Admin login is validated in the application (`admin` / `admin123`).

## Install MongoDB

### Windows

1. Download MongoDB Community Server from [mongodb.com](https://www.mongodb.com/try/download/community)
2. Run the installer
3. Choose **Complete** installation
4. Install MongoDB as a Windows Service
5. Install MongoDB Compass (optional, useful for viewing data)

### Verify Installation

Open a command prompt and run:

```bash
mongod --version
```

Or confirm the MongoDB service is running in Windows Services.

## Connection Configuration

The application reads the connection string from `PharmacySystem/App.config`:

```xml
<connectionStrings>
  <add name="MongoDb" connectionString="mongodb://localhost:27017" />
</connectionStrings>
```

If `App.config` is unavailable at runtime, the application falls back to `mongodb://localhost:27017`.

## Database Initialization

The database is created automatically on first use. No manual schema setup is required.

When the application starts and connects to MongoDB:

1. `PharmacyDB` is created if it does not exist
2. Collections are created when data is inserted
3. `DatabaseSeeder` inserts sample data if a collection is empty

Seeding runs during login initialization, not on every startup.

## Sample Seed Data

### Medicines

| Name | Category | Price | Qty | Dosage | Supplier | Discount | Prescription |
|------|----------|-------|-----|--------|----------|----------|--------------|
| Paracetamol | Analgesics | 5.50 | 100 | 500mg | PharmaCorp Ltd | 5% | No |
| Amoxicillin | Antibiotics | 12.00 | 50 | 250mg | MedSupply Inc | 0% | **Yes** |
| Vitamin C | Supplements | 8.75 | 80 | 1000mg | HealthPlus | 10% | No |

### Customers

| Full Name | Username | Password | Email | Phone |
|-----------|----------|----------|-------|-------|
| John Doe | `johndoe` | `pass123` | john.doe@example.com | 5550199 |
| Jane Smith | `janesmith` | `pass123` | jane.smith@example.com | 5550144 |
| Robert Johnson | `robertj` | `pass123` | robert.j@example.com | 5550177 |
| Emily Davis | `emilyd` | `pass123` | emily.davis@example.com | 5550123 |

Each customer record also includes a Cardiff address.

### Orders and Sales

- **Orders** are created when customers complete checkout through the customer portal.
- **Sales** are created when admins process counter sales through the Sales module.

Neither collection is pre-seeded.

## Viewing Data with MongoDB Compass

1. Open MongoDB Compass
2. Connect to `mongodb://localhost:27017`
3. Open database `PharmacyDB`
4. Browse collections:
   - `Medicines`
   - `Customers`
   - `Sales`
   - `Orders`

## Resetting the Database

To start fresh:

1. Stop the application
2. Open MongoDB Compass or `mongosh`
3. Drop the database:

```javascript
use PharmacyDB
db.dropDatabase()
```

4. Restart the application and log in again
5. Sample medicines and customers will be re-seeded automatically

## Backup Recommendation

For production or coursework submissions, export collections periodically using MongoDB Compass or `mongodump`.

Example backup command:

```bash
mongodump --db PharmacyDB --out ./backup
```

## Common Issues

### Application runs in offline mode

- MongoDB service is not started
- Wrong host or port in `App.config`
- Firewall blocking port `27017`

Admin features that require the database will show an offline warning. Customer login and registration require an active database connection.

### Seed data does not appear

- Collections already contain documents (seeding only runs when a collection is empty)
- Drop the database and log in again to re-seed

### Stock not updating after a sale or order

- Confirm the transaction completed without validation errors
- **Counter sales** update stock via `SaleService` → `InventoryService`
- **Customer orders** update stock during checkout in `MyCartForm`
- Check the `Medicines` collection after a successful transaction
- Review application logs in `%LOCALAPPDATA%\PharmacySystem\Logs\`

### Order status not changing

- Admins update order status through **Order Management** (`OrderManagementForm`)
- Status values: `Pending`, `ReadyForPickup`, `Delivered`
