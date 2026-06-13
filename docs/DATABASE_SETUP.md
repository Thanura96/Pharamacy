# Database Setup Guide

## Overview

The Pharmacy Management System uses **MongoDB** as its database backend.

| Setting | Value |
|---------|-------|
| Database Name | `PharmacyDB` |
| Default Connection | `mongodb://localhost:27017` |

## Collections

| Collection | Purpose |
|------------|---------|
| `Medicines` | Medicine inventory records |
| `Customers` | Registered customer records |
| `Sales` | Completed sales transactions |

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

When a user logs in successfully:

1. The application connects to MongoDB
2. `PharmacyDB` is created if it does not exist
3. Collections are created when data is inserted
4. `DatabaseSeeder` inserts sample data if collections are empty

## Sample Seed Data

### Medicines

| Name | Category | Price | Quantity | Notes |
|------|----------|-------|----------|-------|
| Paracetamol | Analgesics | 5.50 | 100 | Standard stock |
| Amoxicillin | Antibiotics | 12.00 | 50 | Standard stock |
| Vitamin C | Supplements | 8.75 | 8 | Low stock example |

### Customers

| Name | Phone |
|------|-------|
| John Doe | 5550199 |
| Jane Smith | 5550144 |
| Robert Johnson | 5550177 |
| Emily Davis | 5550123 |

## Viewing Data with MongoDB Compass

1. Open MongoDB Compass
2. Connect to `mongodb://localhost:27017`
3. Open database `PharmacyDB`
4. Browse collections:
   - `Medicines`
   - `Customers`
   - `Sales`

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
5. Sample data will be re-seeded automatically

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

### Seed data does not appear

- Collections already contain documents
- Seeding only runs when a collection is empty
- Drop the database and log in again to re-seed

### Sales do not reduce stock

- Confirm the sale completed without validation errors
- Check the `Medicines` collection after a successful sale
- Review application logs in `%LOCALAPPDATA%\PharmacySystem\Logs\`
