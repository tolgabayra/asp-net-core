using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetProgramlamaFinal.Models
{
    public class Etkinlikler
    {
        [Key]
        public int EtkinlikId { get; set; }
        public string EtkinlikAdi { get; set; }
        public DateTime EtkinlikZamani { get; set; }
        public int? SalonId { get; set; }
        
        [ForeignKey("SalonId")]
        public Salonlar Salonlars { get; set; }
        
    }
}