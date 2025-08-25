# SmartTravel Authentication System

## Tổng quan
Hệ thống authentication cho SmartTravel sử dụng JWT tokens và password hashing với salt.

## Tính năng
- **Register**: Đăng ký tài khoản mới
- **Login**: Đăng nhập và nhận JWT token
- **Password Security**: Mã hóa password với SHA256 + Salt
- **JWT Authentication**: Token-based authentication

## API Endpoints

### 1. Register
```
POST /api/auth/register
Content-Type: application/json

{
    "name": "Tên người dùng",
    "email": "email@example.com",
    "password": "password123",
    "confirmPassword": "password123",
    "phoneNumber": "0123456789",
    "nationality": "Vietnamese",
    "preferredLanguage": "vi"
}
```

**Response thành công:**
```json
{
    "success": true,
    "message": "Registration successful",
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "user": {
        "id": 1,
        "name": "Tên người dùng",
        "email": "email@example.com",
        "phoneNumber": "0123456789",
        "nationality": "Vietnamese",
        "preferredLanguage": "vi",
        "createdAt": "2024-01-01T00:00:00Z",
        "lastLoginAt": null,
        "isActive": true
    }
}
```

### 2. Login
```
POST /api/auth/login
Content-Type: application/json

{
    "email": "email@example.com",
    "password": "password123"
}
```

**Response thành công:**
```json
{
    "success": true,
    "message": "Login successful",
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "user": {
        "id": 1,
        "name": "Tên người dùng",
        "email": "email@example.com",
        "phoneNumber": "0123456789",
        "nationality": "Vietnamese",
        "preferredLanguage": "vi",
        "createdAt": "2024-01-01T00:00:00Z",
        "lastLoginAt": "2024-01-01T12:00:00Z",
        "isActive": true
    }
}
```

## Cấu hình

### JWT Settings (appsettings.json)
```json
{
    "Jwt": {
        "Secret": "your-super-secret-key-here-make-it-at-least-32-characters-long",
        "Issuer": "SmartTravel",
        "Audience": "SmartTravelUsers"
    }
}
```

### Database Migration
Sau khi thêm các trường password, chạy migration:
```bash
cd SmartTravel.Infrastructure
dotnet ef migrations add AddPasswordFieldsToUser
dotnet ef database update
```

## Bảo mật

### Password Hashing
- Sử dụng SHA256 với salt ngẫu nhiên 32 bytes
- Salt được lưu riêng biệt cho mỗi user
- Password không bao giờ được lưu dưới dạng plain text

### JWT Token
- Token có thời hạn 7 ngày
- Chứa thông tin user ID, email, và name
- Được ký bằng HMAC-SHA256

### Validation
- Email phải unique
- Password tối thiểu 6 ký tự
- Email phải đúng format
- Confirm password phải khớp với password

## Sử dụng Token

Sau khi login/register thành công, sử dụng token trong header:
```
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

## Testing

Sử dụng file `auth-test.http` để test các API endpoints:
1. Register user mới
2. Login với user đã đăng ký
3. Test login với password sai
4. Test register với email đã tồn tại

## Lưu ý
- Đảm bảo thay đổi JWT Secret trong production
- Token có thời hạn 7 ngày, cần refresh khi hết hạn
- User có thể bị deactivate (IsActive = false)
- LastLoginAt được cập nhật mỗi lần login thành công
