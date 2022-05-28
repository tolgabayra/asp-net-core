using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetProgramlamaFinal.Models
{
    public class Kurslar
    {
        
        [Key]
        public int KursId { get; set; }
        public string KursAdi { get; set; }
        public string KursAciklama { get; set; }
        public string KursFotografi { get; set; }
        public string KursSeanslari { get; set; }
        public double KursFiyati { get; set; }
        
        
        public int? SalonId { get; set; }
        [ForeignKey("SalonId")]

        public int? EgitmenId { get; set; }
        [ForeignKey("EgitmenId")]

        public IList<Uyeler> Uyelers { get; set; }
        public IList<Egitmenler> Egitmenlers { get; set; }

        public Salonlar Salonlars { get; set; }
    }
}