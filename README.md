# 📝 TodoApp - ASP.NET Core MVC

This is a simple **Todo Management** web application built with:

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core (EF Core)
- SQL Server LocalDB
- Razor Views + Bootstrap 5

## 🚀 Features

- Create, edit, and delete todo tasks
- Filter tasks by status (Pending, InProgress, Completed)
- Set due dates and priority levels
- Mark tasks as completed
- Clean Bootstrap UI with Razor pages

## 🛠️ Tech Stack

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- SQL Server (LocalDB or your own connection)
- Razor + Bootstrap 5

## 🔧 Setup Instructions

### 1. Clone the Project

```bash
git clone https://github.com/RemonNakhla/TodoList.git
cd TodoApp
```

### 2. Create the Database

```bash
Add-Migration Init
Update-Database
```

Ensure `DefaultConnection` in `appsettings.json` points to your SQL Server instance.

### 3. Run the Project


Then open your browser to: [https://localhost:5001](https://localhost:5001)

## 💾 Sample Database Configuration

**appsettings.json**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TodoDb;Trusted_Connection=True;"
  }
}
```

## 📂 Project Structure

- `Models/` - Todo model and enums
- `Data/` - EF Core DbContext
- `Controllers/` - TodosController
- `Views/Todos/` - Razor views (Index, Create, Edit, Delete)
- `Program.cs` - App configuration and routing

## 📄 License

MIT - Free to use and modify.
