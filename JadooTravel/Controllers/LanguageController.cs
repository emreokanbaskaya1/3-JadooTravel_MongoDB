using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class LanguageController : Controller
    {
        /// <summary>
        /// Dil değiştirme işlemini gerçekleştirir
        /// </summary>
        /// <param name="culture">Seçilen dil kodu (tr, en, de, fr)</param>
        /// <param name="returnUrl">Geri dönülecek sayfa URL'i</param>
        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            // Geçerli dil kodlarını kontrol et
            var supportedCultures = new[] { "tr", "en", "de", "fr" };
            if (!supportedCultures.Contains(culture))
            {
                culture = "tr"; // Geçersizse varsayılan dile dön
            }

            // Cookie'ye dil bilgisini kaydet
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions 
                { 
                    Expires = DateTimeOffset.UtcNow.AddYears(1), // 1 yıl geçerli
                    IsEssential = true,
                    Path = "/"
                }
            );

            // Geri dönülecek URL varsa oraya, yoksa ana sayfaya yönlendir
            return LocalRedirect(returnUrl ?? "/");
        }

        /// <summary>
        /// GET isteği ile de dil değiştirebilmek için (opsiyonel)
        /// </summary>
        [HttpGet]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            return ChangeLanguage(culture, returnUrl);
        }
    }
}

