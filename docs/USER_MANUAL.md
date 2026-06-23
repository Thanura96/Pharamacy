# SmartMed Pharmacy — User Manual

## Table of Contents

1. [Getting Started](#1-getting-started)
2. [Admin Portal](#2-admin-portal)
3. [Customer Portal](#3-customer-portal)
4. [Validation and Error Messages](#4-validation-and-error-messages)
5. [Export Features](#5-export-features)
6. [Logging](#6-logging)
7. [Exiting the Application](#7-exiting-the-application)
8. [Recommended Workflows](#8-recommended-workflows)
9. [Support Notes](#9-support-notes)

---

## 1. Getting Started

### Login

1. Launch **SmartMed Pharmacy**
2. Select a role: **Admin** or **Customer**
3. Enter username and password
4. Click **Login**

#### Admin credentials

| Field | Value |
|-------|-------|
| Username | `admin` |
| Password | `admin123` |

#### Sample customer credentials

| Username | Password |
|----------|----------|
| `johndoe` | `pass123` |
| `janesmith` | `pass123` |
| `robertj` | `pass123` |
| `emilyd` | `pass123` |

### Registration (Customers only)

1. Select **Customer** on the login screen
2. Click **Register**
3. Complete the registration form (full name, address, email, phone, username, password)
4. Click **Register** to save

Registration requires an active MongoDB connection.

### Offline mode

If MongoDB is unavailable at startup:

- The admin dashboard opens with an offline warning; database-dependent modules will not work
- Customer login and registration are blocked until the database is available

---

## 2. Admin Portal

After admin login, the **SmartMed Pharmacy Admin Dashboard** opens with summary cards and expiry alerts.

### Navigation

```
AdminDashboardForm
├── Medicines        → MedicineForm
├── Customers        → CustomerForm
├── Sales            → SalesForm
├── Orders           → OrderManagementForm
├── Reports          → ReportsForm
└── Exit             → closes application
```

Use the left sidebar to open each module. Child forms open in separate windows.

### Dashboard summary

The dashboard displays:

| Card | Description |
|------|-------------|
| Total Sales | Combined revenue from customer orders and counter sales |
| Total Medicines | Count of medicines in inventory |
| Low Stock | Medicines below the low-stock threshold (10 units) |
| Active Orders | Orders with status Pending or Ready For Pickup |

**Expiry alerts** list medicines expiring within 30 days and medicines already expired.

Click **Refresh** on the dashboard to reload summary data.

---

### 2.1 Medicine Management

Open **Medicines** from the sidebar.

#### Add a medicine

1. Enter medicine name and category
2. Enter price (must be greater than zero)
3. Enter quantity (zero or greater)
4. Select a future expiry date
5. Enter discount percentage (0–100)
6. Enter **dosage** and **supplier** (required)
7. Check **Requires Prescription** if applicable
8. Click **Add**

#### Update a medicine

1. Select a medicine from the grid
2. Edit the fields
3. Click **Update**

#### Delete a medicine

1. Select a medicine from the grid
2. Click **Delete**
3. Confirm the deletion

#### Search medicines

1. Enter a search term (name or category)
2. Click **Search**
3. Click **View All** to restore the full list

---

### 2.2 Customer Management

Open **Customers** from the sidebar.

#### Add a customer

1. Enter customer name, phone, address, and email
2. Enter username and password (for customer portal login)
3. Click **Add Customer**

#### Update a customer

1. Select a customer from the grid
2. Edit the fields (username and password are not changed on update)
3. Click **Update Customer**

#### Search customers

1. Enter a name, phone, or email fragment
2. Click **Search Customer**
3. Click **View Customers** to restore the full list

---

### 2.3 Sales Management (Counter Sales)

Open **Sales** from the sidebar.

This module records **in-store counter sales** (stored in the `Sales` collection). It is separate from customer online orders.

#### Process a sale

1. Select a medicine from the dropdown (only available, non-expired stock is shown)
2. Review the displayed unit price
3. Enter customer name
4. Enter sale quantity
5. Click **Calculate Total** to verify the amount
6. Click **Complete Sale**
7. Confirm the transaction

#### Rules

- Total = Price × Quantity
- Quantity must be greater than zero
- Sales are blocked if stock is insufficient
- Expired medicines cannot be sold
- Stock is reduced automatically after a successful sale

Completed sales appear in the sales history grid on the form.

---

### 2.4 Order Management

Open **Orders** from the sidebar.

Manage **customer online orders** placed through the customer portal.

#### View orders

The grid shows order ID, customer name, date, total, discount, status, and whether a prescription was uploaded.

#### Update order status

1. Select an order from the grid
2. Choose a status: **Pending**, **Ready For Pickup**, or **Delivered**
3. Click **Update Status**

#### View prescription

1. Select an order that includes a prescription
2. Click **View Prescription** to see the file path

Click **Refresh** to reload the order list.

---

### 2.5 Reports

Open **Reports** from the sidebar.

#### Tabs

| Tab | Description |
|-----|-------------|
| **Sales Report** | Total order count, total revenue, and sales grouped by date (orders and legacy counter sales) |
| **Stock Report** | Current stock levels and low-stock medicines |
| **Customer Order History** | Per-customer order counts, total spent, and last order date |

#### Export (Customer Order History tab)

On the **Customer Order History** tab:

- Click **Export PDF** to save order history as a PDF file
- Click **Export Excel** to save order history as an Excel-compatible `.xls` file

Exported fields: Order Number, Date, Medicines, Total, Status.

Click **Refresh All** to reload all report tabs.

---

## 3. Customer Portal

After customer login, the **SmartMed Pharmacy Customer Portal** opens with a sidebar menu.

### Navigation

```
CustomerDashboardForm
├── Search Medicines   → SearchMedicineForm
├── My Cart            → MyCartForm
├── My Orders          → MyOrdersForm
├── Profile            → CustomerProfileForm
└── Logout             → returns to LoginForm
```

---

### 3.1 Search Medicines

1. Enter optional filters: name, category, min/max price
2. Choose a sort option
3. Click **Search**
4. Select a medicine, set quantity, and click **Add to Cart**

Only in-stock, non-expired medicines appear in search results.

---

### 3.2 My Cart

Review items in your cart and complete checkout.

#### Cart actions

- **Update Quantity** — change quantity for the selected item
- **Remove** — remove the selected item
- **Browse** — upload a prescription file (PDF, JPG, or PNG) when required

#### Checkout

1. Review total and applied discounts
2. Upload a prescription if any cart item requires one
3. Click **Checkout**
4. Confirm the order

On success, stock is reduced and the order is saved with status **Pending**.

#### Prescription rules

- Amoxicillin and other medicines marked as prescription-required cannot be checked out without an uploaded prescription
- The system validates stock availability before placing the order

---

### 3.3 My Orders

View your order history and track status.

1. Select an order to see details (items, total, discount, prescription path)
2. Click **Refresh** to reload orders
3. Click **Export PDF** or **Export Excel** to export your order history

---

### 3.4 Profile

View your account details: full name, email, phone, address, and username.

---

## 4. Validation and Error Messages

The system validates input before saving data or completing transactions.

### Medicine validation

- Name and category required
- Price must be greater than zero
- Stock cannot be negative
- Expiry date must be in the future
- Dosage and supplier required
- Discount must be between 0 and 100

### Customer validation

- Name, phone, address, email, username, and password required
- Email and phone must be valid formats
- Username must be unique

### Order validation (customer checkout)

- Cart cannot be empty
- Sufficient stock for each item
- Prescription required when any cart medicine requires one

### Sale validation (admin counter sales)

- Customer name and quantity required
- Stock must be sufficient
- Expired medicines cannot be sold

Errors are shown through inline field indicators (`ErrorProvider`), warning dialogs, and confirmation prompts for destructive actions.

---

## 5. Export Features

Order history can be exported to PDF or Excel.

| Location | Scope |
|----------|-------|
| **My Orders** (customer) | Current customer's orders |
| **Reports → Customer Order History** (admin) | All customer orders |

Export columns: Order Number, Date, Medicines, Total, Status.

---

## 6. Logging

The application records events to a daily log file:

```text
%LOCALAPPDATA%\PharmacySystem\Logs\pharmacy_YYYYMMDD.log
```

Logged events include:

- Application startup
- Successful and failed login attempts
- CRUD operations
- Sales and order transactions
- Export actions
- Errors and unhandled exceptions

---

## 7. Exiting the Application

### Admin

1. Click **Exit** on the admin dashboard sidebar
2. Confirm that you want to close the application

### Customer

1. Click **Logout** on the customer dashboard sidebar
2. Confirm logout
3. The login screen reopens

---

## 8. Recommended Workflows

### Admin daily workflow

1. Review dashboard summary and expiry alerts
2. Check **Reports** for low stock and sales trends
3. Add or update medicines as needed
4. Process in-store sales through **Sales**
5. Update customer order statuses in **Orders**
6. Export customer order history from **Reports** when needed

### Customer workflow

1. **Search Medicines** and add items to cart
2. Upload a prescription if required
3. Complete **Checkout** in My Cart
4. Track order status in **My Orders**
5. Export order history for your records

---

## 9. Support Notes

If database operations fail:

1. Ensure MongoDB is running
2. Restart the application
3. Check the log file for error details
4. Refer to the [Database Setup Guide](DATABASE_SETUP.md)

For installation issues, see the [Installation Guide](INSTALLATION.md).

For architecture and project overview, see the [README](../README.md).
