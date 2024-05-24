using System.ComponentModel.DataAnnotations;

namespace UrunSatisApp.Models;

public class UrunModel
{
    [Required]
    public string Urun { get; set; }
    [Required]
    public string Fiyat { get; set; }
    
    [Required]
    public string OdenenTutar { get; set; }
    
    [Required]
    public int Adet { get; set; }
    
    public int Stok { get; set; }
}