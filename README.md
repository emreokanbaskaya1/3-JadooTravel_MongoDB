# 🌍 JadooTravel - Travel Reservation Platform

JadooTravel is a modern ASP.NET Core MVC-based travel reservation management system. It allows you to manage destinations, reservations, and customer reviews using MongoDB database. It also offers AI-powered travel recommendations with OpenAI integration.

## 📋 Table of Contents
- [Features](#-features)
- [Technologies](#-technologies)
- [Architecture](#-architecture)
- [Installation](#-installation)
- [Configuration](#-configuration)
- [Usage](#-usage)
- [Project Structure](#-project-structure)
- [Project Video](#-project-video)
- [License](#-license)

## ✨ Features

### 🎯 Main Features
- **Category Management**: Create, edit, and delete travel categories
- **Destination Management**: Manage travel destinations with visuals
- **Reservation System**: Track customer reservations
- **Feature Management**: Define platform features
- **Customer Reviews**: Testimonial (customer feedback) management
- **Trip Plans**: Create and manage trip plans
- **AI-Powered Recommendations**: City-based travel recommendations with OpenAI integration
- **Dashboard**: Admin panel
- **Multi-Language Support**: i18n infrastructure available

### 🔧 Technical Features
- Repository & Service Pattern architecture
- DTO (Data Transfer Object) usage
- Object mapping with AutoMapper
- Modular view components with ViewComponent structure
- NoSQL database with MongoDB
- Responsive and modern UI

## 🛠 Technologies

### Backend
- **Framework**: ASP.NET Core 9.0 MVC
- **Database**: MongoDB 3.5.0
- **ORM**: MongoDB.Driver
- **Mapping**: AutoMapper 13.0.1
- **AI Integration**: OpenAI-DotNet 8.8.1
- **Language**: C# (.NET 9.0)

### Frontend
- **UI Framework**: Bootstrap (Spike Bootstrap 1.0.0)
- **CSS**: Custom CSS + SCSS
- **JavaScript**: Vanilla JS + i18n.js
- **Icons & Images**: SVG, PNG

### Development Tools
- Microsoft.VisualStudio.Web.CodeGeneration.Design 9.0.0

## 🏗 Architecture

The project is developed using layered architecture and Repository/Service pattern:

```
JadooTravel/
├── Controllers/          # Controllers handling HTTP requests
├── Services/            # Business Logic Layer
├── Entities/            # MongoDB entity models
├── Dtos/               # Data Transfer Objects
├── Settings/           # Application settings (Database, etc.)
├── Mapping/            # AutoMapper profiles
├── ViewComponents/     # Reusable view components
├── Views/              # Razor view files
└── wwwroot/            # Static files (CSS, JS, images)
```

### Service Structure
Interface and implementation pair for each entity:
- `ICategoryService` / `CategoryService`
- `IDestinationService` / `DestinationService`
- `IFeatureService` / `FeatureService`
- `IReservationService` / `ReservationService`
- `ITestimonialService` / `TestimonialService`
- `ITripPlanService` / `TripPlanService`

## 🚀 Installation

### Requirements
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [MongoDB](https://www.mongodb.com/try/download/community) (v3.5 or higher)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- OpenAI API Key (for AI features)

### Step 1: Clone the Project
```bash
git clone <repository-url>
cd "3)JadooTravel"
```

### Step 2: Start MongoDB
Make sure MongoDB service is running:
```bash
# Windows
net start MongoDB

# macOS/Linux
sudo systemctl start mongod
```

### Step 3: Install Dependencies
```bash
cd JadooTravel
dotnet restore
```

### Step 4: Build the Project
```bash
dotnet build
```

### Step 5: Run the Application
```bash
dotnet run
```

The application will run on `https://localhost:5001` by default.

## ⚙ Configuration

### appsettings.json
Edit the `JadooTravel/appsettings.json` file:

```json
{
  "DatabaseSettingsKey": {
    "ConnectionString": "mongodb://localhost:27017",
    "Database": "JadooTravelDb",
    "CategoryCollectionName": "Categories",
    "DestinationCollectionName": "Destinations",
    "FeatureCollectionName": "Features",
    "TripPlanCollectionName": "TripPlans",
    "ReservationCollectionName": "Reservations",
    "TestimonialCollectionName": "Testimonials"
  },
  "OpenAI": {
    "ApiKey": "your-openai-api-key-here"
  }
}
```

### MongoDB Collections
The application will automatically create the required collections on first run:
- Categories
- Destinations
- Features
- TripPlans
- Reservations
- Testimonials

## 📖 Usage

### Home Page
- Homepage: `http://localhost:5001/`
- Dashboard: `http://localhost:5001/Dashboard`

### Admin Panel
1. **Category Management**: `/Category/CategoryList`
2. **Destination Management**: `/Destination/DestinationList`
3. **Reservation Management**: `/Reservation/ReservationList`
4. **Feature Management**: `/Feature/FeatureList`
5. **Review Management**: `/Testimonial/TestimonialList`
6. **Trip Plans**: `/TripPlan/TripPlanList`

### AI Travel Recommendations
You can get OpenAI-powered travel recommendations by entering a city name from the `/Ai/Index` page.

## 📁 Project Structure

### Controllers
- **DefaultController**: Homepage management
- **DashboardController**: Admin panel
- **CategoryController**: Category CRUD operations
- **DestinationController**: Destination CRUD operations
- **ReservationController**: Reservation CRUD operations
- **FeatureController**: Feature CRUD operations
- **TestimonialController**: Review CRUD operations
- **TripPlanController**: Trip plan CRUD operations
- **AIController**: OpenAI integration

### Entity Models

#### Category
```csharp
- CategoryId: string (ObjectId)
- CategoryName: string
- Description: string
- IconUrl: string
- Status: bool
```

#### Destination
```csharp
- DestinationId: string (ObjectId)
- CityCountry: string
- ImageUrl: string
- Price: decimal
- DayNight: string
- Capacity: int
- Description: string
```

#### Reservation
```csharp
- ReservationId: string (ObjectId)
- FullName: string
- Telephone: string
- Email: string
- Notes: string
- ReservationDate: DateTime
```

### ViewComponents
- `_DefaultBookingStepsComponentPartial`: Reservation steps
- `_DefaultCategoryComponentPartial`: Category list
- `_DefaultDestinationComponentPartial`: Destination cards
- `_DefaultFeatureComponentPartial`: Features section
- `_DefaultHeadComponentPartial`: Page header
- `_DefaultNavbarComponentPartial`: Navigation menu
- `_DefaultTestimonialComponentPartial`: Customer reviews

## 🖼 Project Video

The project has a modern and responsive user interface. The Spike Bootstrap theme is used.


https://github.com/user-attachments/assets/1bfa4e17-cbb3-4500-921d-f588f783159f


## 🔒 Security Notes

⚠️ **IMPORTANT**: This project is for educational purposes. Before using in production:

1. **Hide API Keys**: 
   - Move the OpenAI API key from `appsettings.json` to environment variables
   - Never upload API keys to GitHub
   
2. **Use Environment Variables**:
   ```bash
   # Example
   export OpenAI__ApiKey="your-api-key"
   ```

3. **Add appsettings.json to .gitignore**:
   ```
   appsettings.json
   appsettings.Development.json
   ```

4. **Secure Connection**: Secure your MongoDB connection string

## 🤝 Contributing

1. Fork the project
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License. See the [LICENSE.txt](LICENSE.txt) file for details.

**Copyright (c) 2025 Emre Okan Baskaya**

## 👨‍💻 Developer

**Emre Okan Baskaya**

---

## 🎓 Bootcamp Project

This is the 3rd project of the C# Bootcamp program and covers the following topics:
- ASP.NET Core MVC
- NoSQL database operations with MongoDB
- Repository & Service Pattern
- AutoMapper usage
- OpenAI API integration
- Modern web design
- ViewComponent usage

---

**⭐ If you found this project useful, don't forget to star it!**

