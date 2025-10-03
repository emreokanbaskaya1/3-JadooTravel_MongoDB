# 🌍 JadooTravel - Seyahat Rezervasyon Platformu

JadooTravel, modern bir ASP.NET Core MVC tabanlı seyahat rezervasyon yönetim sistemidir. MongoDB veritabanı kullanarak gezilecek yerler, rezervasyonlar ve müşteri yorumlarını yönetmenizi sağlar. Ayrıca OpenAI entegrasyonu ile yapay zeka destekli seyahat önerileri sunar.

## 📋 İçindekiler
- [Özellikler](#-özellikler)
- [Teknolojiler](#-teknolojiler)
- [Mimari](#-mimari)
- [Kurulum](#-kurulum)
- [Yapılandırma](#-yapılandırma)
- [Kullanım](#-kullanım)
- [Proje Yapısı](#-proje-yapısı)
- [Ekran Görüntüleri](#-ekran-görüntüleri)
- [Güvenlik Notları](#-güvenlik-notları)
- [Lisans](#-lisans)

## ✨ Özellikler

### 🎯 Ana Özellikler
- **Kategori Yönetimi**: Seyahat kategorilerini oluşturma, düzenleme ve silme
- **Destinasyon Yönetimi**: Seyahat destinasyonlarını görsellerle birlikte yönetme
- **Rezervasyon Sistemi**: Müşteri rezervasyonlarını takip etme
- **Özellik Yönetimi**: Platform özelliklerini tanımlama
- **Müşteri Yorumları**: Testimonial (müşteri görüşleri) yönetimi
- **Seyahat Planları**: Trip Plan oluşturma ve yönetme
- **AI Destekli Öneriler**: OpenAI entegrasyonu ile şehir bazlı seyahat önerileri
- **Dashboard**: Yönetim paneli
- **Çok Dilli Destek**: i18n altyapısı mevcut

### 🔧 Teknik Özellikler
- Repository & Service Pattern mimarisi
- DTO (Data Transfer Object) kullanımı
- AutoMapper ile nesne eşleştirme
- ViewComponent yapısı ile modüler görünüm bileşenleri
- MongoDB ile NoSQL veritabanı
- Responsive ve modern UI

## 🛠 Teknolojiler

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

## 🏗 Mimari

Proje, katmanlı mimari ve Repository/Service pattern kullanılarak geliştirilmiştir:

```
JadooTravel/
├── Controllers/          # HTTP isteklerini karşılayan controller'lar
├── Services/            # İş mantığı katmanı (Business Logic Layer)
├── Entities/            # MongoDB entity modelleri
├── Dtos/               # Data Transfer Objects
├── Settings/           # Uygulama ayarları (Database, vb.)
├── Mapping/            # AutoMapper profilleri
├── ViewComponents/     # Yeniden kullanılabilir view bileşenleri
├── Views/              # Razor view dosyaları
└── wwwroot/            # Statik dosyalar (CSS, JS, images)
```

### Servis Yapısı
Her varlık için interface ve implementation çifti:
- `ICategoryService` / `CategoryService`
- `IDestinationService` / `DestinationService`
- `IFeatureService` / `FeatureService`
- `IReservationService` / `ReservationService`
- `ITestimonialService` / `TestimonialService`
- `ITripPlanService` / `TripPlanService`

## 🚀 Kurulum

### Gereksinimler
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [MongoDB](https://www.mongodb.com/try/download/community) (v3.5 veya üzeri)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) veya [Visual Studio Code](https://code.visualstudio.com/)
- OpenAI API Key (AI özellikleri için)

### Adım 1: Projeyi Klonlayın
```bash
git clone <repository-url>
cd "3)JadooTravel"
```

### Adım 2: MongoDB'yi Başlatın
MongoDB servisinin çalıştığından emin olun:
```bash
# Windows
net start MongoDB

# macOS/Linux
sudo systemctl start mongod
```

### Adım 3: Bağımlılıkları Yükleyin
```bash
cd JadooTravel
dotnet restore
```

### Adım 4: Projeyi Derleyin
```bash
dotnet build
```

### Adım 5: Uygulamayı Çalıştırın
```bash
dotnet run
```

Uygulama varsayılan olarak `https://localhost:5001` adresinde çalışacaktır.

## ⚙ Yapılandırma

### appsettings.json
`JadooTravel/appsettings.json` dosyasını düzenleyin:

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

### MongoDB Koleksiyonları
Uygulama ilk çalıştırıldığında otomatik olarak gerekli koleksiyonları oluşturacaktır:
- Categories
- Destinations
- Features
- TripPlans
- Reservations
- Testimonials

## 📖 Kullanım

### Ana Sayfa
- Anasayfa: `http://localhost:5001/`
- Dashboard: `http://localhost:5001/Dashboard`

### Yönetim Paneli
1. **Kategori Yönetimi**: `/Category/CategoryList`
2. **Destinasyon Yönetimi**: `/Destination/DestinationList`
3. **Rezervasyon Yönetimi**: `/Reservation/ReservationList`
4. **Özellik Yönetimi**: `/Feature/FeatureList`
5. **Yorum Yönetimi**: `/Testimonial/TestimonialList`
6. **Seyahat Planları**: `/TripPlan/TripPlanList`

### AI Seyahat Önerileri
`/Ai/Index` sayfasından bir şehir adı girerek OpenAI destekli seyahat önerileri alabilirsiniz.

## 📁 Proje Yapısı

### Controllers
- **DefaultController**: Ana sayfa yönetimi
- **DashboardController**: Yönetim paneli
- **CategoryController**: Kategori CRUD işlemleri
- **DestinationController**: Destinasyon CRUD işlemleri
- **ReservationController**: Rezervasyon CRUD işlemleri
- **FeatureController**: Özellik CRUD işlemleri
- **TestimonialController**: Yorum CRUD işlemleri
- **TripPlanController**: Seyahat planı CRUD işlemleri
- **AIController**: OpenAI entegrasyonu

### Entity Modelleri

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
- `_DefaultBookingStepsComponentPartial`: Rezervasyon adımları
- `_DefaultCategoryComponentPartial`: Kategori listesi
- `_DefaultDestinationComponentPartial`: Destinasyon kartları
- `_DefaultFeatureComponentPartial`: Özellikler bölümü
- `_DefaultHeadComponentPartial`: Sayfa başlığı
- `_DefaultNavbarComponentPartial`: Navigasyon menüsü
- `_DefaultTestimonialComponentPartial`: Müşteri yorumları

## 🖼 Ekran Görüntüleri

Proje modern ve responsive bir kullanıcı arayüzüne sahiptir. Spike Bootstrap teması kullanılmıştır.

## 🔒 Güvenlik Notları

⚠️ **ÖNEMLİ**: Bu proje eğitim amaçlıdır. Production ortamında kullanmadan önce:

1. **API Anahtarlarını Gizleyin**: 
   - `appsettings.json` dosyasındaki OpenAI API anahtarını environment variable'a taşıyın
   - API anahtarlarını asla GitHub'a yüklemeyin
   
2. **Environment Variables Kullanın**:
   ```bash
   # Örnek
   export OpenAI__ApiKey="your-api-key"
   ```

3. **appsettings.json'ı .gitignore'a Ekleyin**:
   ```
   appsettings.json
   appsettings.Development.json
   ```

4. **Güvenli Bağlantı**: MongoDB connection string'ini güvenceye alın

## 🤝 Katkıda Bulunma

1. Fork edin
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some AmazingFeature'`)
4. Branch'inizi push edin (`git push origin feature/AmazingFeature`)
5. Pull Request oluşturun

## 📝 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için [LICENSE.txt](LICENSE.txt) dosyasına bakın.

**Copyright (c) 2025 Emre Okan Baskaya**

## 👨‍💻 Geliştirici

**Emre Okan Baskaya**

---

## 🎓 Bootcamp Projesi

Bu proje, C# Bootcamp programının 3. projesidir ve aşağıdaki konuları kapsamaktadır:
- ASP.NET Core MVC
- MongoDB ile NoSQL veritabanı işlemleri
- Repository & Service Pattern
- AutoMapper kullanımı
- OpenAI API entegrasyonu
- Modern web tasarımı
- ViewComponent kullanımı

---

**⭐ Bu projeyi faydalı bulduysan, yıldız vermeyi unutma!**