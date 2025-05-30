# Ambev.DeveloperEvaluation - tech2cloud

Ambev DeveloperEvaluation is a tech2cloud challenge project to evaluate design and development skills in C# backend development.

---

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

Before you begin, ensure you have the following installed:

* **[.NET SDK](https://dotnet.microsoft.com/download)**: This project requires .NET 8.0). You can download it from the official .NET website.
* **[Visual Studio Code](https://code.visualstudio.com/)** or **[Visual Studio](https://visualstudio.microsoft.com/vs/)** (Recommended IDEs for C# development).
* **[Git](https://git-scm.com/downloads)**: For cloning the repository.

### Installation

1. **Clone the repository:**
   
   ```bash
   git clone https://github.com/jsenaribeiro/tech2cloud.git
   cd tech2cloud
   ```

2. **Restore NuGet packages:**
   Navigate to the project root directory (where the `.sln` file is located) and run:
   
   ```bash
   dotnet restore
   ```


### How to Run

Follow these steps to run the project.

### Running from the Command Line

From the project root directory (where the `.sln` file is located):

1. **Go to root folder:**
   
   ```bash
   cd backend/src
   ```

2. **Run the databases:**
   
   ```bash
   docker compose --project-name tech2cloud up
   ```

3. **Run the application:**
   
   ```bash
   dotnet run --project ./Ambev.DeveloperEvaluation.WebApi
   ```
   
   This will typically start the application on `http://localhost:5119`. Check the console output for the exact URL. If The documentation is at`https://localhost:5119/swagger` 

---

## How to Test

This section outlines how to run the project's tests.

### Running tests

The test projects are located in the `backend/src/tests` directory. 

```bash
cd backend/src
dotnet test
```


## Structure

The project is structured as follows:

```
root
  ├─ README.md
  ├─ frontend/
  └─ backend/
       ├─ src/
       |   ├── Ambev.DeveloperEvaluation.Common/
       |   ├── Ambev.DeveloperEvaluation.Application/
       |   ├── Ambev.DeveloperEvaluation.Domain/
       |   ├── Ambev.DeveloperEvaluation.IoC/
       |   ├── Ambev.DeveloperEvaluation.ORM/
       |   └── Ambev.DeveloperEvaluation.WebApi/
       └── tests/
           ├── Ambev.DeveloperEvaluation.Functional/
           ├── Ambev.DeveloperEvaluation.Integration/
           └── Ambev.DeveloperEvaluation.Unit/
```


