using System.ComponentModel.DataAnnotations;

namespace InternetProgramlamaFinal.Models
{
    public class Salonlar
    {
        [Key]
        public int SalonId { get; set; }
        public string SalonAdi { get; set; }
        public string SalonKonumu { get; set; }
        
    }
}