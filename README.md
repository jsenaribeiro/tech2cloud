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

### ## How to Run

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
   dotnet run --project backend/src/Ambev.DeveloperEvaluation.WebApi # Or your main project path
   ```
   
   This will typically start the application on `http://localhost:5119`. Check the console output for the exact URL. If The documentation is at`https://localhost:5119/swagger` 

---

## How to Test

This section outlines how to run the project's tests.

### Running Unit Tests

Unit tests are located in the `tests/YourProjectName.Tests` directory.

From the project root directory:

```bash
cd src
dotnet test solution
```



## Change logs

Some architectural and development consideration in current stage.

#### Evoluations

* create a shared IRepository
* create marker DDD interfaces (IEntity, IAggregate)
* added some implicity validation (price > 0, required, etc)
* abstract repository for basic CRUD

#### Fixings

* fix GetUserQuery to GetUserQuery (CQRS)

* extract audit fields to BaseEntity

* service locator pattern for DI (better testing)

* BastEntity marked as abstract

* missing mapper between GetUserResult -> GetUserResponse

* PaginatedList -> PageList -> DDD -> {  data: }  // AutoMapper not works with :List

* PageList (remove EfCore dependency to keep a isolated domain )

* change Id to integer

* fix delete API messages to string

## Futures

* change Domain to DDD module pattern (DDD namespace)
* maybe sort is best for filter, not _order, order could mean buy request
* centralize all message error as constants for reuse and tests

#### Issues

* double validator (GetUserRequestValidator + GetUserValidator)
* exposed password  field in the user response
  
  

#### Pendings

* Business rules: the business rules conver discounts on price, but there is no api to complete a sale, only a Shopping Cart with no API for payment, billing, etc.

* Sales events: for the same rease, there is no Sales api to apply the event states

* Unit tests: the test coverage is not complete
