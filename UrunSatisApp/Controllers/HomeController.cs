using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UrunSatisApp.Models;

namespace UrunSatisApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var urunler = new List<UrunModel>();
        using StreamReader reader = new StreamReader("AppData/Urun.txt");
        var urunlerTxt = reader.ReadToEnd();
        if (!string.IsNullOrEmpty(urunlerTxt)){
            var urunListesi = urunlerTxt.Split('\n');
            foreach (var urunSatir in urunListesi)
            {
                var urun = urunSatir.Split('|');
                urunler.Add(
                    new UrunModel()
                    {
                        Urun = urun[0], Fiyat = urun[1]
                    }
                    
                );
            }
        }
        return View(urunler);
    }

    
}