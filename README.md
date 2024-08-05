# Asp.Net Todo List Web API

Welcome! This application is built using ASP.NET Core and demonstrates fundamental CRUD (Create, Read, Update, Delete) operations on a Todo List. The project is designed to showcase RESTful API practices, and modern web development techniques.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Technologies Used](#technologies-used)
- [Contact](#contact)

## Overview

This project is a simple Todo List API that supports operations such as retrieving all tasks, adding new tasks, updating existing tasks, and deleting tasks. It follows best practices for RESTful APIs and aims to provide a clean and maintainable codebase.

## Features

- **GET**: Retrieve a list of all tasks.
- **POST**: Add a new task to the Todo List.
- **PUT**: Update an existing task.
- **DELETE**: Remove a task from the Todo List.
- Error handling for invalid requests and operations.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or any other configured database)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/Lipinicki/Todo_List.git
   ```

2. **Set up the database:**

   Update the connection string in `appsettings.json` with your database credentials.

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=your_server;Database=ToDoListDb;User Id=your_user;Password=your_password;"
   }
   ```

3. **Apply migrations:**

   Run the following command to create the database and apply migrations:

   ```bash
   dotnet ef database update
   ```

### Running the Application

Run the application using the .NET CLI or your preferred IDE:

```bash
dotnet run
```

The API will be available at `https://localhost:5208` (or another port if configured differently).

## API Endpoints

- **GET /tasks**: Retrieve all tasks.
- **POST /tasks**: Create a new task.
- **PUT /tasks/{id}**: Update an existing task.
- **DELETE /tasks/{id}**: Delete a task.

### Sample Requests

#### POST /tasks

```json
{
    "title": "Finish Project Documentation",
    "description": "Complete the documentation for the new feature implementation by Friday.",
    "completed": false
}
```

#### PUT /tasks/{id}

```json
{
    "title": "Prepare Presentation",
    "description": "Create slides for the upcoming client meeting presentation.",
    "completed": true
}
```

## Technologies Used

- **ASP.NET Core 8**
- **Entity Framework Core**
- **SQL Server (LocalDB)**
- **Swagger** (for API documentation)

## Contact

If you have any questions or would like to discuss the project further, feel free to reach out via [LinkedIn](https://www.linkedin.com/in/agostinhofelipe) or [email](mailto:agostinhofelipeneto@outlook.com).

---

Thank you for checking out my project! I'm excited to share my work with you and look forward to any feedback you may have.
