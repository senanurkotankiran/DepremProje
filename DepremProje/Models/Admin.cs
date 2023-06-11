using System.ComponentModel.DataAnnotations;

namespace DepremProje.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string Kullanici { get; set; }
        public string Sifre { get; set; }

    }
}
