using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetProgramlamaFinal.Models
{
    public class Uyeler
    {
        [Key]
        public int UyeId { get; set; }
        public string UyeAdi { get; set; }
        public string UyeSoyadi { get; set; }
        public string UyeTelefon { get; set; }
        
        public int? KursId { get; set; }

        public int? EgitmenId { get; set; }

        [ForeignKey("KursId")]

        public Kurslar Kurslars { get; set; }
        [ForeignKey("EgitmenId")]

        public Egitmenler Egitmenlers { get; set; }

    }
}