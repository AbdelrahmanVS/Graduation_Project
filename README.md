# Spark
## A Modern E-Commerce Shoes Store

Spark is a comprehensive e-commerce web application built with ASP.NET Core MVC, specializing in footwear sales. It provides a modern, responsive shopping experience with product management, user authentication, and advanced search capabilities.

## 🚀 Features

### User Features
- **User Registration & Authentication** - Secure user accounts with ASP.NET Core Identity
- **Product Browsing** - Browse shoes by categories: Boots, Oxfords, Sports, and Trending Products
- **Advanced Search** - Global search across all product categories
- **Product Details** - Detailed product views with multiple images
- **Responsive Design** - Mobile-friendly interface with Bootstrap

### Admin Features
- **Product Management** - Full CRUD operations for all product categories
- **Inventory Management** - Track stock levels and product availability
- **User Management** - Role-based access control (Admin/User roles)
- **Admin Dashboard** - Comprehensive product and user management

### E-commerce Features
- **Shopping Cart** - Add products to cart, manage quantities, and view totals
- **Payment Integration** - Secure payment processing via Paymob gateway
- **Order Management** - Complete checkout process with order tracking

## 🛠️ Technologies Used

### Backend
- **ASP.NET Core 9.0** - Web framework
- **Entity Framework Core** - ORM for database operations
- **SQL Server** - Primary database
- **ASP.NET Core Identity** - Authentication and authorization
- **Paymob Payment Gateway** - Secure payment processing
- **Microsoft.EntityFrameworkCore.Tools** - Database migrations

### Frontend
- **Razor Pages** - Server-side rendering
- **Bootstrap 5.3** - CSS framework for responsive design
- **HTML5 & CSS3** - Modern web standards
- **JavaScript & jQuery** - Client-side interactivity
- **Swiper.js** - Touch slider components

### Development Tools
- **.NET 9.0 SDK** - Development framework
- **Visual Studio** - IDE support
- **SQL Server Management Studio** - Database management

## 📁 Project Structure

```
ITIGraduation/
├── Controllers/          # MVC Controllers
│   ├── HomeController.cs # Main homepage and search
│   ├── Account.cs       # User authentication
│   ├── Products.cs      # Product management
│   ├── Boots.cs         # Boot category management
│   ├── Oxfords.cs       # Oxford shoes management
│   ├── Sports.cs        # Sports shoes management
│   └── TrendingSellings.cs # Trending products
├── Data/                # Database context and configurations
│   ├── ApplicationDbContext.cs # Identity context
│   ├── SparkContext.cs  # Main application context
│   └── Migrations/      # Database migrations
├── Models/              # Domain models
│   ├── AppUser.cs       # User identity model
│   ├── Boot.cs          # Boot product model
│   ├── Oxford.cs        # Oxford shoe model
│   ├── Sport.cs         # Sports shoe model
│   ├── TrendingSelling.cs # Trending product model
│   ├── Inventory.cs     # Inventory management
│   └── SearchResultVM.cs # Search result view model
├── ViewModels/          # Data transfer objects
│   ├── LoginVM.cs       # Login view model
│   ├── RegisterVM.cs    # Registration view model
│   └── Combied.cs       # Combined view models
├── Views/               # Razor view templates
│   ├── Home/           # Homepage views
│   ├── Account/        # Authentication views
│   ├── Products/       # Product management views
│   ├── Boots/          # Boot category views
│   ├── Oxfords/        # Oxford category views
│   ├── Sports/         # Sports category views
│   ├── TrendingSellings/ # Trending products views
│   └── Shared/         # Shared layout and components
└── wwwroot/            # Static files (CSS, JS, images)
```

## 🚀 Getting Started

### Prerequisites
- **.NET 9.0 SDK** or higher
- **SQL Server** or SQL Server Express LocalDB
- **Visual Studio 2022** or VS Code with C# extension

### Installation & Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/AbdelrahmanVS/Graduation_Project.git
   cd Graduation_Project/ITIGraduation
   ```

2. **Configure Database Connection & Payment Settings**
   - Update connection strings and Paymob configuration in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=.;Database=Spark;Initial Catalog=CustomIdentityDB;Integrated Security=True;TrustServerCertificate=True",
       "spark": "Data Source=.;Initial Catalog=Spark;Integrated Security=True;TrustServerCertificate=True"
     },
     "Paymob": {
       "API_Key": "your_paymob_api_key_here",
       "Iframe_ID": "your_iframe_id_here",
       "Integration_ID": "your_integration_id_here",
     }
   }
   ```

3. **Install Dependencies**
   ```bash
   dotnet restore
   ```

4. **Apply Database Migrations**
   ```bash
   dotnet ef database update --context ApplicationDbContext
   dotnet ef database update --context SparkContext
   ```

5. **Run the Application**
   ```bash
   dotnet run
   ```

6. **Access the Application**
   - Open your browser and navigate to `https://localhost:7xxx` or `http://localhost:5xxx`
   - Default admin account: `admin@example.com` / `Admin123!`

## 🗄️ Database Schema

The application uses two database contexts:
- **ApplicationDbContext** - Manages user authentication and authorization
- **SparkContext** - Manages product data, inventory, purchase history, and cart data

### Key Tables:
- **Users** - Customer information
- **Boots, Oxfords, Sports, Products, TrendingSellings** - Product categories
- **Inventory** - Stock management
- **UserBootPurchases, UserOxfordPurchases, UserSportPurchases** - Purchase history
- **Cart** - Shopping cart items
- **Orders** - Order management and payment tracking

## 🔐 User Roles

- **Admin** - Full access to product management, user management, and system configuration
- **User** - Can browse products, search, view details, add items to cart, and complete purchases

## 🔧 Configuration

### Paymob Payment Gateway Setup
1. Create a Paymob account at [paymob.com](https://paymob.com)
2. Obtain your API credentials from the Paymob dashboard
3. Add the following configuration to your `appsettings.json`:
   ```json
   "Paymob": {
     "API_Key": "your_paymob_api_key",
     "Iframe_ID": "your_iframe_id", 
     "Integration_ID": "your_integration_id",
   }
   ```

### Admin Account Setup
The application automatically creates an admin account on first run:
- **Email**: admin@example.com
- **Password**: Admin123!

### Identity Configuration
- Minimum password length: 8 characters
- Special characters: Not required
- Email confirmation: Disabled (for development)

## 📝 API Endpoints

### Public Endpoints
- `GET /` - Homepage with trending products
- `GET /Products` - Product catalog
- `GET /Boots` - Boot collection
- `GET /Oxfords` - Oxford shoes collection
- `GET /Sports` - Sports shoes collection
- `GET /Home/Search` - Global search
- `GET /Cart` - Shopping cart (authenticated users)
- `POST /Cart/Add` - Add item to cart
- `POST /Payment/Process` - Process payment via Paymob

### Admin Endpoints (Requires Admin Role)
- `POST /Products/Create` - Create new product
- `PUT /Products/Edit/{id}` - Update product
- `DELETE /Products/Delete/{id}` - Delete product
- Similar CRUD operations for all product categories

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Team

This project was developed as part of a graduation project at ITI (Information Technology Institute).
