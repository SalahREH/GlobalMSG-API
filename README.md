# GlobalMSG Backend

This is the backend for an instant messaging application developed in C#.

## Requirements

- [Visual Studio](https://visualstudio.microsoft.com/) (Recommended latest version)
- [.NET Core SDK](https://dotnet.microsoft.com/download) (Recommended version 5.0 or higher)
- [SQL Server](https://www.microsoft.com/sql-server)

## Configuration

1. Clone this repository on your local machine.

   ```bash
   git clone https://github.com/yourusername/repo-name.git
   ```

2. Open the project in Visual Studio.

3. Configure the database connection string in `appsettings.json` with your SQL Server instance details.

    ``` json
    "ConnectionStrings": {
      "CRUDCS": "Server=localhost;Database=YourDatabaseName;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
    ```

3. Ensure that the database specified in the connection string exists. If not, run migrations to create it.

    ```bash
    dotnet ef database update
    ```

## Execution

1. Build and run the application from Visual Studio.

2. The application will be available at `https://localhost:5001` by default. You can change the port in `launchSettings.json` if needed.

## Swagger Enabled

To explore and test the available APIs simply run the project and use the Swagger UI.

The available APIs include:
- POST `/api/accounts` - Creates a new user.
- POST `/api/auth/login` - Authenticates a user.
- POST `/api/auth/refreshtoken` - Refreshes expired access tokens.
- GET `/api/protected` - Protected controller for testing role-based authorization.

## Features

<!-- - User registration and authentication.
- Real-time messaging using SignalR. -->
- CRUD webservice api for messaging. (On the future it will be websocket api)
- Message history.

## Technologies Used

- ASP.NET Core for backend development.
<!-- - SignalR for real-time communication. -->
- Entity Framework Core for database access.
