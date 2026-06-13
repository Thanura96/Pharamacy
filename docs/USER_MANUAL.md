# User Manual

## 1. Getting Started

### Login

1. Launch the Pharmacy Management System
2. Enter username: `Admin`
3. Enter password: `admin123`
4. Click **Login**

If MongoDB is unavailable, the system opens in offline mode and database features will not work.

### Dashboard

After login, the dashboard provides access to:

- Medicines
- Customers
- Sales
- Reports
- Exit

Use the left navigation menu to open each module.

---

## 2. Medicine Management

Open **Medicines** from the dashboard.

### Add a Medicine

1. Enter medicine name
2. Enter category
3. Enter price (must be greater than zero)
4. Enter quantity (must be greater than zero)
5. Select a future expiry date
6. Click **Add**

### Update a Medicine

1. Select a medicine from the grid
2. Edit the fields
3. Click **Update**
4. Confirm the changes in the success message

### Delete a Medicine

1. Select a medicine from the grid
2. Click **Delete**
3. Confirm the deletion in the dialog

### Search Medicines

1. Enter a medicine name in the search box
2. Click **Search**
3. Click **View All** to restore the full list

### Clear Form

Click **Clear** to reset all input fields.

---

## 3. Customer Management

Open **Customers** from the dashboard.

### Add a Customer

1. Enter customer name
2. Enter phone number
3. Click **Add Customer**

### Search Customers

1. Enter a customer name in the search box
2. Click **Search Customer**
3. Click **View Customers** to restore the full list

### Clear Form

Click **Clear** to reset the customer form.

---

## 4. Sales Management

Open **Sales** from the dashboard.

### Process a Sale

1. Select a medicine from the dropdown
2. Review the displayed unit price
3. Enter customer name
4. Enter sale quantity
5. Click **Calculate Total** to verify the amount
6. Click **Complete Sale**
7. Confirm the transaction in the dialog

### Rules

- Total = Price × Quantity
- Quantity must be greater than zero
- Sales are blocked if stock is insufficient
- Expired medicines cannot be sold
- Stock is reduced automatically after a successful sale

### Sales History

Completed sales appear in the grid on the right side of the Sales form.

---

## 5. Reports

Open **Reports** from the dashboard.

### Available Tabs

| Tab | Description |
|-----|-------------|
| Available Medicines | In-stock, non-expired medicines |
| Low Stock Medicines | Medicines with quantity below 10 |
| Expired Medicines | Medicines past expiry date |
| Sales History | All recorded sales |

Click **Refresh** to reload all report data.

---

## 6. Validation and Error Messages

The system validates user input before saving data.

Common validation messages:

- Required fields cannot be empty
- Price and quantity must be valid positive numbers
- Expiry date must be in the future for new medicine entries
- Phone numbers must be valid
- Sales are rejected when stock is insufficient

Errors are shown using:

- Inline field indicators (`ErrorProvider`)
- Warning and error dialog boxes
- Confirmation dialogs for destructive actions

---

## 7. Logging

The application records important events to a log file:

```text
%LOCALAPPDATA%\PharmacySystem\Logs\pharmacy_YYYYMMDD.log
```

Logged events include:

- Application startup
- Successful login
- CRUD operations
- Sales transactions
- Errors and exceptions

---

## 8. Exiting the Application

1. Click **Exit** on the dashboard
2. Confirm that you want to close the application

---

## 9. Recommended Workflow

1. Review available medicines in **Reports**
2. Add or update medicines as needed
3. Register customers before processing sales
4. Complete sales through the **Sales** module
5. Monitor low stock and expired medicines in **Reports**

---

## 10. Support Notes

If database operations fail:

1. Ensure MongoDB is running
2. Restart the application
3. Check the log file for error details
4. Refer to the [Database Setup Guide](DATABASE_SETUP.md)
