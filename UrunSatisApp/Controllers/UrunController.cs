using Microsoft.AspNetCore.Mvc;
using UrunSatisApp.Models;

namespace UrunSatisApp.Controllers;

public class UrunController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Index(UrunModel model)
    {
        if (model != null && !string.IsNullOrEmpty(model.OdenenTutar) && !string.IsNullOrEmpty(model.Fiyat))
        {
            decimal fiyat;
            decimal odenenTutar;
            int adet = model.Adet;

            bool FiyatValid = decimal.TryParse(model.Fiyat, out fiyat);
            bool OdenenTutarValid = decimal.TryParse(model.OdenenTutar, out odenenTutar);

            if (FiyatValid && OdenenTutarValid && adet > 0)
            {
                decimal toplamFiyat = fiyat * adet;

                if (odenenTutar >= toplamFiyat)
                {
                    decimal paraUstu = odenenTutar - toplamFiyat;
                    if (paraUstu > 0)
                    {
                        
                        ViewData["Ödeme"] = $"Ödeme Başarılı. Para üstü: {paraUstu}";
                    }
                    else
                    {
                        ViewData["Ödeme"] = "Ödeme Başarılı";
                    }
                    return View();
                }
                else
                {
                    ViewData["Ödeme"] = $"Ödenen tutar yetersiz! Gerekli tutar: {toplamFiyat}";
                    return View("Index", model);
                }
            }
            else
            {
                ViewData["Ödeme"] = "Geçersiz tutar veya adet girdiniz!";
                return View("Index", model);
            }
        }
        else
        {
            ViewData["Ödeme"] = "Lütfen tüm alanları doldurun!";
            return View("Index", model);
        }
    }
}