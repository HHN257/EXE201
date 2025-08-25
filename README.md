# SmartTravel - Smart Travel Guide for Vietnam

Ứng dụng hướng dẫn du lịch thông minh dành cho người nước ngoài đến Việt Nam, giúp họ khám phá, di chuyển, ăn uống, lưu trú và trải nghiệm Việt Nam một cách dễ dàng và an toàn.

## Tính năng chính

- **Đặt phòng khách sạn**: Traveloka, Klook, Agoda
- **Di chuyển nội thành**: BusMap, Grab, Be, XanhSM
- **Đặt vé xe đường dài**: Phương Trang, Limousine
- **Ăn uống**: GrabFood, ShopeeFood, BeFood
- **Vui chơi – giải trí**: CGV, Lotte Cinema, trung tâm thương mại
- **Quy đổi tiền tệ**: Hỗ trợ VND, USD, EUR, JPY, KRW, GBP
- **Hướng dẫn viên du lịch**: Tìm kiếm và đánh giá hướng dẫn viên

## Cấu trúc Database

### Entities đã tạo:

1. **User** - Quản lý thông tin người dùng
2. **Category** - Phân loại dịch vụ (Accommodation, Transportation, Food & Dining, etc.)
3. **Service** - Các dịch vụ cụ thể (Grab, Traveloka, etc.)
4. **ServiceReview** - Đánh giá dịch vụ
5. **Booking** - Đặt chỗ dịch vụ
6. **UserPreference** - Sở thích người dùng
7. **CurrencyRate** - Tỷ giá tiền tệ
8. **TourGuide** - Hướng dẫn viên du lịch
9. **TourGuideReview** - Đánh giá hướng dẫn viên

## Setup Database

### 1. Cài đặt SQL Server
- Cài đặt SQL Server Express hoặc SQL Server Developer Edition
- Tạo database: `SmartTravelDb`

### 2. Cấu hình Connection String
Cập nhật file `SmartTravel.WebAPI/appsettings.json`:
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=MAIN-PC\\SQLEXPRESS;Database=SmartTravelDb;Uid=sa;Pwd=123456;TrustServerCertificate=True;"
}
```

### 3. Tạo Migration và Database
```bash
# Từ thư mục SmartTravel.WebAPI
dotnet ef migrations add InitialCreate --project ../SmartTravel.Infrastructure

# Tạo database
dotnet ef database update
```

### 4. Seed Data
Database sẽ được tạo với dữ liệu mẫu:
- 5 Categories: Accommodation, Transportation, Food & Dining, Entertainment, Long Distance Travel
- 14 Services: Grab, Traveloka, Klook, etc.
- 5 Currency Rates: VND to USD, EUR, JPY, KRW, GBP

## Cấu trúc Project

```
SmartTravel/
├── SmartTravel.Domain/          # Domain layer
│   └── Entities/               # Domain entities
├── SmartTravel.Application/     # Application layer
│   ├── DTOs/                  # Data Transfer Objects
│   ├── Interfaces/             # Repository interfaces
│   ├── Mappings/              # AutoMapper profiles
│   └── Services/              # Business logic services
├── SmartTravel.Infrastructure/ # Infrastructure layer
│   ├── Data/                  # DbContext và Repositories
│   ├── Repositories/          # Repository implementations
│   └── Services/              # External services
└── SmartTravel.WebAPI/        # Presentation layer
    └── Controllers/           # API Controllers
```

## Công nghệ sử dụng

- **.NET 8.0**
- **Entity Framework Core 8.0**
- **SQL Server**
- **Clean Architecture**
- **Repository Pattern**

## Lệnh EF Core hữu ích

```bash
# Tạo migration mới
dotnet ef migrations add MigrationName --project ../SmartTravel.Infrastructure

# Cập nhật database
dotnet ef database update

# Xóa migration cuối
dotnet ef migrations remove --project ../SmartTravel.Infrastructure

# Tạo script SQL
dotnet ef migrations script --project ../SmartTravel.Infrastructure

# Xem danh sách migrations
dotnet ef migrations list --project ../SmartTravel.Infrastructure
```

## Chạy ứng dụng

```bash
# Từ thư mục SmartTravel.WebAPI
dotnet run
```

API sẽ chạy tại: https://localhost:7000 (hoặc port được cấu hình)

## API Endpoints (sẽ được implement)

- `GET /api/categories` - Lấy danh sách categories
- `GET /api/services` - Lấy danh sách services
- `GET /api/services/{id}` - Lấy chi tiết service
- `POST /api/bookings` - Tạo booking mới
- `GET /api/currency-rates` - Lấy tỷ giá tiền tệ
- `GET /api/tour-guides` - Lấy danh sách hướng dẫn viên
- `POST /api/users` - Đăng ký user mới
- `GET /api/users/{id}/preferences` - Lấy preferences của user
