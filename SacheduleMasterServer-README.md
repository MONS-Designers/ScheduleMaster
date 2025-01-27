# SacheduleMasterServer

## Overview
This project is built using .NET Core 8 and follows a layered architecture consisting of Controllers, Services, Repositories, and Entities (including DTOs). It also includes Swagger for API documentation.

## Project Structure
- **Controllers**: Contains the API controllers that handle incoming requests and return responses.
- **Services**: Contains the business logic and service layer that interacts with repositories.
- **Repositories**: Contains the data access layer that communicates with the database and entity models and Data Transfer Objects used throughout the application.

## Getting Started

### Prerequisites
- .NET Core 8 SDK
- Any code editor or IDE (e.g., Visual Studio, Visual Studio Code)

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/MONS-Designers/ScheduleMaster.git
   ```
2. Navigate to the project directory:
   ```bash
   cd ScheduleMaster/server
   ```
3. Restore the dependencies:
   ```bash
   dotnet restore
   ```

### Running the Application
To run the application, use the following command:
```bash
dotnet run
```
The application will be available.

### Swagger
Swagger is included for API documentation. Once the application is running, you can access the Swagger UI (if you don't see it) by adding the next text to the browser's URL:
```
/swagger
```

## Contributing
Contributions are welcome! Please open an issue or submit a pull request for any enhancements or bug fixes.
