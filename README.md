# 🚀 Hotel Booking API (.NET 10)

![.NET](https://img.shields.io/badge/.NET-10.0-blueviolet)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET-Core-blue)
![EF Core](https://img.shields.io/badge/Entity%20Framework-Core-green)
![JWT](https://img.shields.io/badge/Auth-JWT-orange)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-red)

A secure and scalable **Hotel Booking REST API** built with **ASP.NET Core (.NET 10)**, **Entity Framework Core**, **SQL Server**, and **JWT Authentication**.

This project demonstrates a clean backend architecture with authentication, hotel management, room management, and booking operations. Users can register, log in, browse hotels and rooms, and create bookings securely.

---

# ✨ Features

* 🔐 User Registration & Login
* 🔑 JWT Authentication & Authorization
* 🏨 Hotel Management (CRUD)
* 🚪 Room Management (CRUD)
* 📅 Booking Management
* 👤 User-based bookings
* ⚠️ Global Exception Handling
* 📄 Swagger API Documentation
* 🧱 Repository Pattern
* 🧠 Service Layer Architecture
* 🗄️ Entity Framework Core & SQL Server

---

# 🛠️ Tech Stack

* ASP.NET Core Web API (.NET 10)
* Entity Framework Core
* SQL Server
* JWT Bearer Authentication
* Swagger / OpenAPI
* C#
* Repository Pattern
* Service Layer Architecture

---

# 🏗️ Project Structure

```text
HotelBookingAPI
│
├── Controllers
│   ├── AuthController.cs
│   ├── HotelsController.cs
│   ├── RoomsController.cs
│   └── BookingsController.cs
│
├── Data
│   └── ApplicationDbContext.cs
│
├── DTOs
│   ├── LoginDto.cs
│   ├── RegisterDto.cs
│   ├── CreateHotelDto.cs
│   ├── CreateRoomDto.cs
│   └── CreateBookingDto.cs
│
├── Models
│   ├── User.cs
│   ├── Hotel.cs
│   ├── Room.cs
│   └── Booking.cs
│
├── Repositories
│   ├── IUserRepository.cs
│   ├── UserRepository.cs
│   ├── IHotelRepository.cs
│   ├── HotelRepository.cs
│   ├── IRoomRepository.cs
│   ├── RoomRepository.cs
│   ├── IBookingRepository.cs
│   └── BookingRepository.cs
│
├── Services
│   ├── IJwtService.cs
│   ├── JwtService.cs
│   ├── IUserService.cs
│   ├── UserService.cs
│   ├── IHotelService.cs
│   ├── HotelService.cs
│   ├── IRoomService.cs
│   ├── RoomService.cs
│   ├── IBookingService.cs
│   └── BookingService.cs
│
├── Middlewares
│
├── Migrations
│
├── Program.cs
├── appsettings.json
└── launchSettings.json
```

---

# 🗄️ Database Entities

## User

```text
Id
Username
PasswordHash
```

## Hotel

```text
Id
Name
Location
Description
```

## Room

```text
Id
RoomNumber
Type
PricePerNight
IsAvailable
HotelId
```

## Booking

```text
Id
CheckIn
CheckOut
UserId
RoomId
CreatedAt
```

---

# 🔐 Authentication

This API uses JWT Bearer Token Authentication.

## Register User

```http
POST /api/Auth/register
```

Example:

```json
{
  "username": "admin",
  "password": "1234"
}
```

## Login User

```http
POST /api/Auth/login
```

Example Response:

```json
{
  "token": "your_jwt_token_here"
}
```

---

# 📌 API Endpoints

## 🔑 Authentication

```http
POST /api/Auth/register
POST /api/Auth/login
```

## 🏨 Hotels

```http
GET    /api/Hotels
GET    /api/Hotels/{id}
POST   /api/Hotels
PUT    /api/Hotels/{id}
DELETE /api/Hotels/{id}
```

## 🚪 Rooms

```http
GET    /api/Rooms
GET    /api/Rooms/{id}
POST   /api/Rooms
PUT    /api/Rooms/{id}
DELETE /api/Rooms/{id}
```

## 📅 Bookings

```http
GET    /api/Bookings
GET    /api/Bookings/{id}
POST   /api/Bookings
DELETE /api/Bookings/{id}
```

---

# ⚙️ Setup & Run

## Clone Repository

```bash
git clone https://github.com/your-username/HotelBookingAPI.git
```

## Restore Packages

```bash
dotnet restore
```

## Apply Migrations

```bash
dotnet ef database update
```

## Run Application

```bash
dotnet run
```

---

# 📸 Swagger UI

After running the project, open:

```text
https://localhost:7275/swagger
```

---

# 🧠 Architecture Overview

This project follows a layered architecture:

```text
Controllers
     ↓
Services
     ↓
Repositories
     ↓
Entity Framework Core
     ↓
SQL Server
```

### Responsibilities

* Controllers → Handle HTTP requests
* Services → Business logic
* Repositories → Data access layer
* DTOs → Data transfer objects
* EF Core → Database operations
* JWT → Authentication & Authorization

---

# 👨‍💻 Author

Developed by Sebine Isgenderova

---

# 📌 Notes

* JWT Authentication is required for protected endpoints.
* SQL Server must be configured before running the application.
* Built with ASP.NET Core (.NET 10).
* Implements Repository Pattern and Service Layer Architecture.
* Designed for learning real-world backend development concepts.
