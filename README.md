# Ambev.DeveloperEvaluation - tech2cloud

Ambev DeveloperEvaluation is a tech2cloud challenge project to evaluate design and development skills in C# backend development.

---

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

## Features

- User authentication
- User, cart, and product management
- RESTful API documented with Swagger
- Unit, integration, and functional tests


### Prerequisites

Before you begin, ensure you have the following installed:

* **[.NET SDK](https://dotnet.microsoft.com/download)**: .NET 8.0 or higher.
* **[Git](https://git-scm.com/downloads)**: for cloning the repository.
* **[Docker](https://docs.docker.com/get-started/get-docker/)**: for running the databases.
* **[Visual Code](https://code.visualstudio.com/)** or **[Visual Studio](https://visualstudio.microsoft.com/vs/)** for C# development (recomended).

### Installation

Follow these steps to download the project and its dependencies.

1. **Clone the repository:**
   
   ```bash
   git clone https://github.com/jsenaribeiro/tech2cloud.git
   cd tech2cloud
   ```

2. **Restore NuGet packages:**
   Go to to the `/src` project directory and run:
   
   ```bash
   dotnet restore
   ```

## Configuration

The environment configuration is located in path:  `src/Ambev.DeveloperEvaluation.WebApi/appsettings.json` .

### How to Run

Follow these steps to run the project in root directory.

### Running from the Command Line

1. **Up the databases:**
   
   ```bash
   docker compose --project-name tech2cloud up
   ```

2. **Run the application:**
   
   ```bash
   dotnet run --project src/Ambev.DeveloperEvaluation.WebApi
   ```
   
   It runs on `http://localhost:5119` with documentation on `https://localhost:5119/swagger` 

---

## How to Test

This section outlines how to run the project's tests.

### Running tests

The test projects are located in the `src/tests` directory. 

```bash
cd src
dotnet test
```

## Structure

The project is structured as follows:

```
root
  ├─ README.md
  ├─ src/
  │   ├── Ambev.DeveloperEvaluation.Common/
  │   ├── Ambev.DeveloperEvaluation.Application/
  │   ├── Ambev.DeveloperEvaluation.Domain/
  │   ├── Ambev.DeveloperEvaluation.IoC/
  │   ├── Ambev.DeveloperEvaluation.ORM/
  │   └── Ambev.DeveloperEvaluation.WebApi/
  └── tests/
      ├── Ambev.DeveloperEvaluation.Functional/
      ├── Ambev.DeveloperEvaluation.Integration/
      └── Ambev.DeveloperEvaluation.Unit/
```



## References

- [.NET Documentation](https://learn.microsoft.com/en-us/dotnet/)
- [Docker Documentation](https://docs.docker.com/)
- [Swagger Documentation](https://swagger.io/docs/)