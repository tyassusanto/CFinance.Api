# CFinance.Api

REST API **CFinance** dibuat dengan .NET (C#) untuk kebutuhan layanan backend finansial / accounting.

---

### Struktur Project
- **CFinance.Api** → Layer API (Controller, Middleware, Routing)
- **CFinance.Application** → Business Logic, DTO, Use Case
- **CFinance.Domain** → Entity & Interface Repository
- **CFinance.Infrastructure** → Database, EF Core, Implementasi Repository

---

##  Fitur Utama

- RESTful API
- Clean Architecture
- Dependency Injection
- Entity Framework Core
- Database Migration
- Swagger / OpenAPI

---

##  Teknologi

- .NET 8 (atau sesuai versi project)
- C#
- Entity Framework Core
- SQL Server (default)
- Swagger

---

##  Requirement

Pastikan environment kamu sudah memiliki:

- .NET SDK (sesuai versi project)
- SQL Server / Database engine
- Visual Studio / VS Code
- EF Core CLI

--- 

## Daftar Role: 
1. Admin
2. Finance
3. Staff

---

## Daftar Endpoint API

### Admin
| Method | Endpoint | Deskripsi |
| :--- | :--- | :--- |
| POST | `/api/admin/createUser` | Membuat akun user baru |

### Auth
| Method | Endpoint | Deskripsi |
| :--- | :--- | :--- |
| POST | `/api/auth/login` | Login User dan Generate Token |

### Finance
| Method | Endpoint | Deskripsi |
| :--- | :--- | :--- |
| POST | `/api/finance/budget` | Menentukan budget staff |
| GET | `/api/finance/reimbursments` | List reimbursement |
| PUT | `/api/finance/reimbursments/{id}/approve` | Approve reimbursement |
| PUT | `/api/finance/reimbursments/{id}/reject` | Reject reimbursement |

### Staff
| Method | Endpoint | Deskripsi |
| :--- | :--- | :--- |
| POST | `/api/staff/reimbursment` | Submit reimbursement |


--- 
Install EF Core CLI jika belum ada:

```bash
dotnet tool install --global dotnet-ef
```

Clone repository dari GitHub:
```bash 
git clone https://github.com/tyassusanto/CFinance.Api.git
```
Masuk ke folder project:
```bash
cd CFinance.Api
```
Restore dependency:
```bash
dotnet restore
```
Edit file appsettings.json di project CFinance.Api:
```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=CFinanceDb;User Id=sa;Password=YourPassword;"
}
```
Sesuaikan Server, Database, User Id, dan Password dengan environment kamu.

## Migrasi
Untuk melakukan migrasi bisa di lihat pada root folder dan jalankan perintah migrasi dalam file Migration.txt

## Jalankan Aplikasi :
dotnet run --project CFinance.Api

## Testing : 
Untuk testing dapat menggunakan user yg sudah di sediakan: 
- admin@cfinance.local
- finance@cfinance.local
- staff@cfinance.local
password  : Admin123!

finance mendapatkan balance awal sebesar 10.000.000 dan untuk menentukan budget tidak boleh melebihi 40%
