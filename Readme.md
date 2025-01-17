# **Steps Leaderboard API**

A company-wide steps leaderboard application for teams of employees. The API allows teams to track their step counts, compare with other teams, and manage team members' step counters.

---

## **Features**
- Create and manage teams.
- Add and remove step counters for team members.
- Increment step counts for individual counters.
- View total steps for a team.
- List all teams with their respective step counts.
- In-memory storage (data resets on app restart).

---

## **Technologies**
- **Framework**: .NET 8
- **Language**: C#
- **API Design**: RESTful
- **Storage**: In-memory (no persistent storage)
- **Documentation**: Swagger/OpenAPI

---

## **Getting Started**

### **Prerequisites**
1. [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet)
2. Any IDE supporting .NET (e.g., Visual Studio, Visual Studio Code)

### **Installation**

1. Restore dependencies:
   ```bash
   dotnet restore
   ```

2. Run the application:
   ```bash
   dotnet run
   ```

---

## **API Documentation**

### **Base URL**
```plaintext
http://localhost:5000/api
```


## **In-Memory Storage**
This project uses an in-memory database to store teams and counters during runtime. All data will be lost when the application restarts.

---


## **Swagger Documentation**
Swagger UI is available at:
```plaintext
http://localhost:5000/swagger
```
