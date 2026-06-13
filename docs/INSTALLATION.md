# Installation Guide

## Prerequisites

Install the following before running the Pharmacy Management System:

1. **Windows 10 or later**
2. **Visual Studio 2015+** with:
   - .NET desktop development workload
   - .NET Framework 4.6 targeting pack
3. **MongoDB Community Server** 4.x or later
4. **NuGet Package Manager** (included with Visual Studio)

## Step 1: Clone or Download the Project

```text
Pharamacy/
├── PharmacySystem.sln
├── PharmacySystem/
├── PharmacySystem.Tests/
└── docs/
```

## Step 2: Restore NuGet Packages

1. Open `PharmacySystem.sln` in Visual Studio
2. Right-click the solution
3. Select **Restore NuGet Packages**

Required packages are restored automatically from `packages.config`.

## Step 3: Configure MongoDB Connection

The default connection string is defined in `PharmacySystem/App.config`:

```xml
<connectionStrings>
  <add name="MongoDb" connectionString="mongodb://localhost:27017" />
</connectionStrings>
```

Change this only if MongoDB runs on a different host or port.

## Step 4: Start MongoDB

Ensure the MongoDB service is running before launching the application.

On Windows, MongoDB is usually available as a service after installation.

## Step 5: Build the Solution

1. Set the solution configuration to **Debug** or **Release**
2. Select **Build → Build Solution**
3. Confirm there are no compile errors

## Step 6: Run the Application

1. Set `PharmacySystem` as the startup project
2. Press **F5** or click **Start**
3. Login with:
   - Username: `Admin`
   - Password: `admin123`

## Step 7: Run Unit Tests (Optional)

1. Open **Test → Test Explorer**
2. Click **Run All**
3. Verify all tests pass

## Troubleshooting

### MongoDB connection warning on login

- Confirm MongoDB is installed and running
- Verify the connection string in `App.config`
- Check that port `27017` is not blocked by a firewall

### NuGet restore failures

- Ensure you have internet access
- Re-run **Restore NuGet Packages**
- Delete the `packages` folder and restore again if needed

### Build errors in Visual Studio

- Confirm .NET Framework 4.6 is installed
- Rebuild the solution after restoring packages

## Deployment

To distribute the application:

1. Build in **Release** mode
2. Copy the contents of `PharmacySystem/bin/Release/`
3. Ensure MongoDB is available on the target machine
4. Include `App.config` with the correct MongoDB connection string
