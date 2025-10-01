# 🌍 JadooTravel - Çok Dilli (Localization) Kullanım Kılavuzu

## 📋 Genel Bakış

JadooTravel projesi artık **4 dil** desteğine sahip:
- 🇹🇷 **Türkçe** (tr) - Varsayılan
- 🇺🇸 **İngilizce** (en)
- 🇩🇪 **Almanca** (de)
- 🇫🇷 **Fransızca** (fr)

## 📁 Proje Yapısı

```
JadooTravel/
├── Resources/                          # Çeviri dosyaları
│   ├── SharedResource.cs              # Resource sınıfı
│   ├── SharedResource.tr.resx         # Türkçe çeviriler
│   ├── SharedResource.en.resx         # İngilizce çeviriler
│   ├── SharedResource.de.resx         # Almanca çeviriler
│   └── SharedResource.fr.resx         # Fransızca çeviriler
├── Controllers/
│   └── LanguageController.cs          # Dil değiştirme kontrolcüsü
├── Program.cs                          # Localization yapılandırması
└── Views/
    ├── _ViewImports.cshtml            # Global localizer injeksiyonu
    └── ...
```

## 🚀 Nasıl Kullanılır?

### 1. View'larda Localization Kullanımı

View'larda metinleri çevirmek için 2 yöntem var:

#### Yöntem 1: `SharedLocalizer` (Önerilen - Tüm projede aynı)
```cshtml
@SharedLocalizer["Home"]
@SharedLocalizer["Welcome"]
@SharedLocalizer["Subscribe"]
```

#### Yöntem 2: `Localizer` (View'e özel)
```cshtml
@Localizer["Home"]
@Localizer["Destinations"]
```

### 2. Controller'da Localization Kullanımı

```csharp
using Microsoft.Extensions.Localization;

public class MyController : Controller
{
    private readonly IStringLocalizer<SharedResource> _localizer;

    public MyController(IStringLocalizer<SharedResource> localizer)
    {
        _localizer = localizer;
    }

    public IActionResult Index()
    {
        var welcomeMessage = _localizer["Welcome"];
        ViewBag.Message = welcomeMessage;
        return View();
    }
}
```

### 3. Model Validation'da Localization

```csharp
using System.ComponentModel.DataAnnotations;

public class LoginDto
{
    [Required(ErrorMessage = "EmailRequired")]
    [EmailAddress(ErrorMessage = "EmailInvalid")]
    public string Email { get; set; }

    [Required(ErrorMessage = "PasswordRequired")]
    public string Password { get; set; }
}
```

## 🔧 Yeni Çeviri Ekleme

### Adım 1: Resource Dosyalarını Düzenle
Her 4 `.resx` dosyasına yeni key ekleyin:

**SharedResource.tr.resx:**
```xml
<data name="NewKey" xml:space="preserve">
    <value>Yeni Metin</value>
</data>
```

**SharedResource.en.resx:**
```xml
<data name="NewKey" xml:space="preserve">
    <value>New Text</value>
</data>
```

**SharedResource.de.resx:**
```xml
<data name="NewKey" xml:space="preserve">
    <value>Neuer Text</value>
</data>
```

**SharedResource.fr.resx:**
```xml
<data name="NewKey" xml:space="preserve">
    <value>Nouveau Texte</value>
</data>
```

### Adım 2: View'da Kullan
```cshtml
<h1>@SharedLocalizer["NewKey"]</h1>
```

## 🌐 Dil Değiştirme Nasıl Çalışır?

1. Kullanıcı navbar'daki dil menüsünden dil seçer
2. JavaScript `changeLanguage()` fonksiyonu tetiklenir
3. Gizli form `LanguageController.ChangeLanguage()` metoduna POST ister
4. Seçilen dil **Cookie'ye** kaydedilir (1 yıl geçerli)
5. Sayfa yenilenir ve yeni dilde açılır

### Cookie Detayları
- **Cookie Adı:** `JadooTravelLanguage`
- **Geçerlilik:** 1 yıl
- **Format:** `.AspNetCore.Culture=c=tr|uic=tr`

## 📝 Mevcut Çeviriler

### Navigasyon
- `Home` - Ana Sayfa / Home / Startseite / Accueil
- `Destinations` - Destinasyonlar / Destinations / Reiseziele / Destinations
- `Hotels` - Oteller / Hotels / Hotels / Hôtels
- `Flights` - Uçuşlar / Flights / Flüge / Vols
- `Bookings` - Rezervasyonlar / Bookings / Buchungen / Réservations
- `Login` - Giriş Yap / Login / Anmelden / Se Connecter
- `SignUp` - Kayıt Ol / Sign Up / Registrieren / S'inscrire
- `Language` - Dil / Language / Sprache / Langue

### Footer
- `Company` - Şirket / Company / Unternehmen / Entreprise
- `About` - Hakkımızda / About / Über Uns / À Propos
- `Careers` - Kariyer / Careers / Karriere / Carrières
- `Contact` - İletişim / Contact / Kontakt / Contact
- `More` - Daha Fazla / More / Mehr / Plus

### Diğer
- `Subscribe` - Abone Ol / Subscribe / Abonnieren / S'abonner
- `YourEmail` - E-posta adresiniz / Your email / Ihre E-Mail / Votre email
- `AllRightsReserved` - Tüm hakları saklıdır / All rights reserved / Alle Rechte vorbehalten / Tous droits réservés

*Tam liste için `Resources/*.resx` dosyalarına bakın.*

## 🔨 Yapılandırma

### Program.cs'de Yapılandırma
```csharp
// Localization servislerini ekle
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();

// Desteklenen dilleri tanımla
var supportedCultures = new[]
{
    new CultureInfo("tr"),
    new CultureInfo("en"),
    new CultureInfo("de"),
    new CultureInfo("fr")
};

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("tr");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    
    options.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider
    {
        CookieName = "JadooTravelLanguage"
    });
});

// Middleware'i ekle
app.UseRequestLocalization();
```

## 🎯 Varsayılan Dili Değiştirme

`Program.cs` dosyasında:
```csharp
options.DefaultRequestCulture = new RequestCulture("en"); // İngilizce varsayılan
```

## 🆕 Yeni Dil Ekleme

### 1. Resource Dosyası Oluştur
`Resources/SharedResource.es.resx` (İspanyolca için)

### 2. Program.cs'e Ekle
```csharp
var supportedCultures = new[]
{
    new CultureInfo("tr"),
    new CultureInfo("en"),
    new CultureInfo("de"),
    new CultureInfo("fr"),
    new CultureInfo("es") // İspanyolca ekle
};
```

### 3. LanguageController'ı Güncelle
```csharp
var supportedCultures = new[] { "tr", "en", "de", "fr", "es" };
```

### 4. Navbar'ı Güncelle
```cshtml
var languageNames = new Dictionary<string, string>
{
    { "tr", "Türkçe" },
    { "en", "English" },
    { "de", "Deutsch" },
    { "fr", "Français" },
    { "es", "Español" } // Ekle
};

var languageFlags = new Dictionary<string, string>
{
    { "tr", "🇹🇷" },
    { "en", "🇺🇸" },
    { "de", "🇩🇪" },
    { "fr", "🇫🇷" },
    { "es", "🇪🇸" } // Ekle
};
```

## 🐛 Sorun Giderme

### Çeviriler Görünmüyor
1. `.resx` dosyalarını kontrol edin - doğru key'i kullandığınızdan emin olun
2. Projeyi yeniden derleyin (Rebuild)
3. Tarayıcı cache'ini temizleyin

### Dil Değişmiyor
1. Cookie'leri kontrol edin (F12 > Application > Cookies)
2. `UseRequestLocalization()` middleware'inin doğru sırada olduğundan emin olun
3. LanguageController'ın çalıştığından emin olun (breakpoint koyun)

### Resource Dosyası Bulunamıyor
1. `ResourcesPath` yapılandırmasını kontrol edin
2. Namespace'lerin doğru olduğundan emin olun
3. `SharedResource.cs` sınıfının var olduğunu kontrol edin

## 💡 İpuçları

1. **Tutarlılık:** Tüm projede aynı key'leri kullanın
2. **Açıklayıcı İsimler:** Key'lere anlamlı isimler verin (`Btn_Submit` yerine `Submit`)
3. **Kategorizasyon:** Büyük projelerde resource dosyalarını kategorilere ayırın
4. **Test:** Her yeni çeviri eklediğinizde 4 dilde test edin
5. **Placeholder:** Dinamik içerik için placeholder kullanın:
   ```cshtml
   @String.Format(SharedLocalizer["WelcomeMessage"], userName)
   ```
   Resource'da:
   ```xml
   <data name="WelcomeMessage">
       <value>Hoş geldiniz {0}!</value>
   </data>
   ```

## 📞 Destek

Sorularınız için:
- GitHub Issues
- E-posta: [email]
- Dokümantasyon: [link]

---

**Hazırlayan:** AI Assistant  
**Tarih:** 2025-10-01  
**Versiyon:** 1.0

