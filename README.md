# Todo Tracker API

A RESTful API built with ASP.NET Web API to manage todo tasks across multiple boards. Designed to demonstrate proficiency in backend development, dependency injection, and API design.

## Project Overview

This API allows users to:
- Create and manage multiple task boards
- Perform CRUD operations on todos within boards
- Track task completion status
- Get incomplete tasks for specific boards

## Features

✅ **Multi-Board Support**  
Create separate boards for different projects or categories

🔧 **CRUD Operations**  
- **Boards**: Create, rename, and delete boards
- **Tasks**: Create, update, and delete todos
- **Status Tracking**: Mark tasks as done/undone

🔍 **Task Filtering**  
- Get all todos for a board
- Filter undone tasks for specific boards

## Technologies Used

- **Framework**: ASP.NET Core Web API
- **Dependency Injection**: Constructor injection for services
- **HTTP Standards**: Proper status codes and response formats
- **Documentation**: Swagger/OpenAPI

## API Endpoints

### Board Endpoints
| Method | Path | Description | Parameters |
|--------|------|-------------|------------|
| GET | `/Board/GetAll` | Get all boards | - |
| GET | `/Board/Get` | Get board details | `Id` (Guid), `IncludeTodos` (bool) |
| GET | `/Board/GetUndone` | Get incomplete tasks | `boardId` (Guid) |
| POST | `/Board/Create` | Create new board | `Title` (string) in body |
| PUT | `/Board/Rename` | Update board title | `Id` (Guid), `Title` (string) in body |
| DELETE | `/Board/Delete` | Delete board | `boardId` (Guid) |

### Todo Endpoints
| Method | Path | Description | Parameters |
|--------|------|-------------|------------|
| GET | `/Todo/Get` | Get todo item | `todoId` (Guid) |
| POST | `/Todo/Create` | Create new todo | `BoardId` (Guid), `Title` (string) in body |
| PUT | `/Todo/UpdateTitle` | Update todo title | `Id` (Guid), `Title` (string) in body |
| PUT | `/Todo/UpdateStatus` | Update completion status | `Id` (Guid), `IsDone` (bool) in body |
| DELETE | `/Todo/Delete` | Delete todo | `todoId` (Guid) |

## Example Requests

### Board Operations

**1. Get All Boards**
```http
GET /Board/GetAll
```

**Response**:
```json
[
  {
    "id": "a1b2c3d4-5678-90ef-ghij-klmnopqrstuv",
    "title": "Work Tasks"
  },
  {
    "id": "b2c3d4e5-6789-01fg-hijk-lmnopqrstuvw",
    "title": "Personal Projects"
  }
]
```

**2. Create New Board**
```http
POST /Board/Create
Content-Type: application/json

{
  "title": "Shopping List"
}
```

**Response**:
```json
{
  "id": "c3d4e5f6-7890-12gh-ijkl-mnopqrstuvwx",
  "title": "Shopping List"
}
```

**3. Get Board Details (with Todos)**
```http
GET /Board/Get?id=c3d4e5f6-7890-12gh-ijkl-mnopqrstuvwx&includeTodos=true
```

**Response**:
```json
{
  "id": "c3d4e5f6-7890-12gh-ijkl-mnopqrstuvwx",
  "title": "Shopping List",
  "todos": [
    {
      "id": "d4e5f6g7-8901-23hi-jklm-nopqrstuvwxy",
      "title": "Buy milk",
      "isDone": false
    }
  ]
}
```

### Todo Operations

**1. Create New Todo**
```http
POST /Todo/Create
Content-Type: application/json

{
  "boardId": "c3d4e5f6-7890-12gh-ijkl-mnopqrstuvwx",
  "title": "Buy eggs"
}
```

**Response**:
```json
{
  "id": "e5f6g7h8-9012-34ij-klmn-opqrstuvwxyz1",
  "title": "Buy eggs",
  "isDone": false,
  "boardId": "c3d4e5f6-7890-12gh-ijkl-mnopqrstuvwx"
}
```

**2. Update Todo Title**
```http
PUT /Todo/UpdateTitle
Content-Type: application/json

{
  "id": "e5f6g7h8-9012-34ij-klmn-opqrstuvwxyz1",
  "title": "Buy organic eggs"
}
```

**Response**:
```json
{
  "id": "fa821b02-fbcd-46ab-a8a5-bf3e0f5c224e",
  "title": "Buy organic eggs",
  "isDone": false,
  "boardId": "c3d4e5f6-7890-12gh-ijkl-mnopqrstuvwx"
}
```

**3. Mark Todo as Complete**
```http
PUT /Todo/UpdateStatus
Content-Type: application/json

{
  "id": "9f54db21-f8ec-4c0a-8b5e-8b3b95acce7a",
  "isDone": true
}
```

**Response**:
```json
{
  "id": "9f54db21-f8ec-4c0a-8b5e-8b3b95acce7a",
  "title": "Buy organic eggs",
  "isDone": true,
  "boardId": "c3d4e5f6-7890-12gh-ijkl-mnopqrstuvwx"
}
```

**4. Get Incomplete Tasks**
```http
GET /Board/GetUndone?boardId=9f54db21-f8ec-4c0a-8b5e-8b3b95acce7a
```

**Response**:
```json
[
  {
    "id": "9f54db21-f8ec-4c0a-8b5e-8b3b95acce7a",
    "title": "Buy milk",
    "isDone": false
  }
]
```

**5. Delete Board**
```http
DELETE /Board/Delete?boardId=c3d4e5f6-7890-12gh-ijkl-mnopqrstuvwx
```

**Response**:
```json
{
  "success": true,
  "statusCode": 200
}
```

## Request/Response Patterns
- All endpoints return HTTP 200 OK on success
- GUID parameters must be in proper UUID format
- Update operations return the modified entity
- Delete operations return success confirmation
- Error responses follow standard Problem Details format

## Setup & Installation

1. Clone repository:
```bash
git clone https://github.com/yourusername/todo-tracker-api.git
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Start application:
```bash
dotnet run
```

Access Swagger documentation at: `https://localhost:5001/swagger`
