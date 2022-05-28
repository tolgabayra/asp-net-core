using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetProgramlamaFinal.Models
{
    public class Egitmenler
    {
        [Key]
        public int EgitmenId { get; set; }
        public string EgitmenAdi { get; set; }
        public string EgitmenFoto { get; set; }
        public int? KursId { get; set; }
        [ForeignKey("KursId")]

        
        public Kurslar Kurslars { get; set; }
    }
}