using System.ComponentModel.DataAnnotations;

namespace DepremProje.Models
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public string KategoriAciklamasi { get; set; }

    }
}
