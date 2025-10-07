# JokeApp 🤣  
A simple **.NET 8 Minimal API** project that demonstrates clean architecture, CQRS, and modern .NET development practices.

---

## 🧱 Tech Stack
- **.NET 8** — Minimal API  
- **Entity Framework Core** (SQLite)  
- **MediatR** — for CQRS and clean request handling  
- **FluentValidation** — for validation pipeline  
- **Dependency Injection** — built-in .NET DI  
- **SQLite** — lightweight local database

---

## 📂 Project Structure
```
JokeApp.sln
├── JokeApp.Api/           → Minimal API entry point
├── JokeApp.Application/   → CQRS handlers, validators, MediatR setup
├── JokeApp.Domain/        → Entities (e.g., Joke.cs)
├── JokeApp.Persistence/   → EF Core DbContext, migrations
```

---

## 🚀 Getting Started
### 1️⃣ Clone the repository
```bash
git clone https://github.com/amachad4/JokeApp.git
cd JokeApp
```

### 2️⃣ Apply migrations & create the database
```bash
dotnet ef database update --project JokeApp.Persistence --startup-project JokeApp.Api
```

### 3️⃣ Run the API
```bash
cd JokeApp.Api
dotnet run
```

### 4️⃣ Test it
Use your browser or Postman:
```
GET     http://localhost:5000/api/jokes
POST    http://localhost:5000/api/jokes
PUT     http://localhost:5000/api/jokes/{id}
DELETE  http://localhost:5000/api/jokes/{id}
```

---

## 🧠 Features
- CRUD endpoints for jokes  
- Implements **Clean Architecture** principles  
- Uses **CQRS pattern** via MediatR  
- Validation handled with **FluentValidation**  
- Demonstrates dependency injection and layered design  

---

## 🧰 Future Enhancements
- Add unit tests with xUnit / NUnit  
- Add Swagger / OpenAPI documentation  
- Dockerize the API for containerized deployment  

---

## 🧑‍💻 Author
**Andres Machado**  
[GitHub Repository → JokeApp](https://github.com/amachad4/JokeApp)  
Springfield, VA  
Active Public Trust  

---

## 📄 License
MIT License © 2025 Andres Machado
