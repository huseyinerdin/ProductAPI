# Product API

This project is a simple Product CRUD API developed using .NET 8, PostgreSQL, and Entity Framework Core.

## 🚀 Technologies Used
- .NET 8 Web API
- Entity Framework Core
- PostgreSQL
- Swagger
- Layered Architecture (API – Application – Domain – Infrastructure)
- Global Exception Middleware

## 📂 Project Structure
```
📂 ProductAPI
├── ProductAPI.API            🟦 Controllers, Program.cs, Middleware
├── ProductAPI.Application    🟩 DTOs, Services
├── ProductAPI.Domain         🟨 Entities
└── ProductAPI.Infrastructure 🟫 DbContext, Repositories
```
## ⚙️ Setup
1. Clone the repository:
```bash
git clone <repo-url>
cd ProductAPI
```

2. Configure PostgreSQL connection in ./ProductAPI.API/appsettings.json:
```bash
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=ProductAPIDb;Username=postgres;Password=yourPassword"
}
```
3. Run the project:
```bash
dotnet run --project ./ProductAPI.API
```
## Swagger UI:
```bash
http://localhost:5010/swagger
```
## 📌 API Endpoints
```plaintext
POST /api/products → Add a new product

GET /api/products → Get all products

GET /api/products/{id} → Get product by ID

DELETE /api/products/{id} → Delete a product
```

## 📝 License
This project is licensed under the MIT License.