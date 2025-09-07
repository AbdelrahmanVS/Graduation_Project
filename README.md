# ITI Graduation Project - Spark Shoes E-commerce Platform

![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Razor%20Pages-0066CC)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-5C2D91)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927)

## 📖 Project Overview

**Spark** is a comprehensive e-commerce platform specializing in footwear sales, developed as a graduation project for ITI (Information Technology Institute). The application provides a modern, responsive web interface for browsing, searching, and purchasing various types of shoes including sports shoes, boots, oxfords, and trending products.

---

## ✨ Key Features

### 🛍️ E-commerce Functionality
- **Product Catalog**: Browse multiple categories of footwear
  - Sports shoes
  - Boots
  - Oxford shoes
  - Trending/Featured products
- **Shopping Cart**: Add, update, and remove items with real-time calculations
- **Secure Checkout**: Integrated payment processing with Paymob payment gateway
- **Search & Filter**: Advanced product search across all categories
- **Product Management**: CRUD operations for administrators

### 🔐 Authentication & Authorization
- **User Registration/Login**: Custom identity system using ASP.NET Core Identity
- **Role-based Access Control**: 
  - Admin users can manage products
  - Regular users can browse and purchase
- **Session Management**: Persistent shopping cart across sessions

### 📱 User Experience
- **Responsive Design**: Mobile-first responsive layout
- **Interactive UI**: Dynamic cart updates without page refresh
- **Modern Frontend**: Bootstrap-based responsive design
- **Product Gallery**: Multiple product images with lightbox view

### 💳 Payment Integration
- **Paymob Payment Gateway**: Secure online payment processing
- **Multiple Payment Options**: Credit cards, debit cards
- **Order Management**: Track purchases and payment status
- **Secure Transactions**: SSL encryption and secure payment handling

---

## 🏗️ Technical Architecture

### Backend Stack
- **Framework**: ASP.NET Core 9.0 (Razor Pages)
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: ASP.NET Core Identity
- **ORM**: Entity Framework Core 9.0
- **Payment**: Paymob payment gateway integration

### Frontend Stack
- **Razor Pages**: Server-side rendering with C#
- **Bootstrap**: Responsive CSS framework
- **JavaScript**: Interactive cart functionality
- **AJAX**: Asynchronous operations for cart management

### Database Design
- **Dual Context Architecture**:
  - `ApplicationDbContext`: User authentication and identity
  - `SparkContext`: E-commerce data (products, cart, orders)

#### Key Entities
- **Products**: `Product`, `Sport`, `Boot`, `Oxford`, `TrendingSelling`
- **User Management**: `AppUser`, `User`
- **Shopping**: `CartItemEntity`, `CartItem`
- **Orders**: `UserBootPurchase`, `UserSportPurchase`, `UserOxfordPurchase`
- **Inventory**: `Inventory` (stock management)

---

## 🚀 Getting Started

### Prerequisites
- .NET 9.0 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or VS Code

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/AbdelrahmanVS/Graduation_Project
   cd ITIGraduation
   ```

2. **Configure Database Connection**
   Update `appsettings.json` with your SQL Server connection strings:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=.;Database=CustomIdentityDB;Integrated Security=True;TrustServerCertificate=True",
       "spark": "Data Source=.;Initial Catalog=Spark;Integrated Security=True;TrustServerCertificate=True"
     }
   }
   ```

3. **Configure Paymob Settings**
   Add your Paymob credentials to `appsettings.json`:
   ```json
   {
     "Paymob": {
       "ApiKey": "your-paymob-api-key",
       "IntegrationId": "your-integration-id",
       "IframeId": "your-iframe-id"
     }
   }
   ```

4. **Install Dependencies**
   ```bash
   dotnet restore
   ```

5. **Run Database Migrations**
   ```bash
   dotnet ef database update --context ApplicationDbContext
   dotnet ef database update --context SparkContext
   ```

6. **Run the Application**
   ```bash
   dotnet run
   ```

7. **Access the Application**
   Navigate to `https://localhost:5001` or `http://localhost:5000`

### Default Admin Account
- **Email**: `admin@example.com`
- **Password**: `Admin123!`

---

## 📁 Project Structure

```
ITIGraduation/
├── Controllers/           # MVC Controllers
│   ├── HomeController.cs     # Main site navigation
│   ├── CartController.cs     # Shopping cart management
│   ├── PaymentController.cs  # Payment processing
│   ├── ProductsController.cs # Product CRUD operations
│   ├── SportsController.cs   # Sports shoes management
│   ├── BootsController.cs    # Boots management
│   └── OxfordsController.cs  # Oxford shoes management
├── Models/               # Data models and view models
│   ├── Product.cs           # Product entities
│   ├── AppUser.cs           # User identity model
│   ├── CartItem.cs          # Shopping cart models
│   └── PaymobModels.cs      # Payment gateway models
├── Data/                 # Database contexts
│   ├── ApplicationDbContext.cs # Identity context
│   └── SparkContext.cs         # E-commerce context
├── Services/             # Business logic services
│   └── PaymobService.cs     # Payment gateway service
├── Views/                # Razor views
│   ├── Home/               # Home page views
│   ├── Cart/               # Shopping cart views
│   ├── Products/           # Product management views
│   └── Shared/             # Shared layouts and partials
├── wwwroot/              # Static files (CSS, JS, images)
├── Migrations/           # Database migrations
└── Program.cs            # Application startup
```

---

## 🔧 Configuration

### Database Configuration
The application uses two separate database contexts:
- **Identity Database**: User authentication and roles
- **Spark Database**: Product catalog and e-commerce data

### Payment Gateway Setup
To enable payment functionality:
1. Register with Paymob payment gateway
2. Obtain API keys and integration IDs
3. Update `appsettings.json` with your credentials

### Environment Settings
- **Development**: Uses local SQL Server and detailed error pages
- **Production**: Implements proper error handling and security headers

---

## 🛡️ Security Features

- **Input Validation**: Model validation and anti-forgery tokens
- **Authentication**: Secure user login/registration
- **Authorization**: Role-based access control
- **SQL Injection Protection**: Entity Framework parameterized queries
- **HTTPS**: Enforced SSL/TLS encryption
- **Session Security**: Secure session management

---

## 🎯 API Endpoints

### Cart Management (AJAX)
- `POST /Cart/AddToCart` - Add item to cart
- `POST /Cart/UpdateQuantity` - Update item quantity
- `POST /Cart/Remove` - Remove item from cart

### Payment Processing
- `GET /Payment/Index` - Payment form
- `POST /Payment/CreatePayment` - Process payment
- `GET /Payment/Success` - Payment success callback
- `POST /api/paymob/callback` - Paymob webhook

---

## 🧪 Testing

### Manual Testing Checklist
- [ ] User registration and login
- [ ] Product browsing and search
- [ ] Add to cart functionality
- [ ] Cart operations (update, remove)
- [ ] Checkout process
- [ ] Payment integration
- [ ] Admin product management

---

## 📦 Dependencies

### NuGet Packages
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore** (9.0.8)
- **Microsoft.EntityFrameworkCore.SqlServer** (9.0.8)
- **Microsoft.EntityFrameworkCore.Tools** (9.0.8)
- **Microsoft.VisualStudio.Web.CodeGeneration.Design** (9.0.0)
- **Newtonsoft.Json** (for payment processing)

---

## 🚧 Future Enhancements

- [ ] Order tracking and history
- [ ] Product reviews and ratings
- [ ] Wishlist functionality
- [ ] Email notifications
- [ ] Advanced inventory management
- [ ] Multi-language support
- [ ] Social media integration
- [ ] Analytics dashboard

---

## 🤝 Contributing

This is an educational project developed as part of ITI graduation requirements. Contributions and suggestions are welcome for learning purposes.

---

## 📄 License

This project is developed for educational purposes as part of ITI graduation requirements.
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

**MIT License Summary:**
- ✅ Commercial use
- ✅ Modification  
- ✅ Distribution
- ✅ Private use
- ❌ Liability
- ❌ Warranty

This project was developed for educational purposes as part of ITI graduation requirements.

---

## 👥 Team

**ITI Graduation Project Team**

### Team Members
- **Ahmed Mohamed Taha**
- **Ahmed Saad Saad Mhesin**
- **Mohamed Salah Shaban**
- **Abdoelrahman Ebrahim Mahmoud**
- **Yossef Hady Atef**
- **Mohamed Suliman Mohamed**
- **Mohamed Anter Ahmed**

### Project Details
- **Project Type**: E-commerce Platform
- **Institution**: Information Technology Institute (ITI)
- **Technology Stack**: ASP.NET Core 9.0, Entity Framework Core, SQL Server
- **Project Name**: Spark Shoes E-commerce Platform


---
> ❤️ Star this repo if you find it useful or want to follow development!
