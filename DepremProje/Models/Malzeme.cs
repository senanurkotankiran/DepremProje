using System.ComponentModel.DataAnnotations;

namespace DepremProje.Models
{
    public class Malzeme
    {
        [Key]
        public int MalzemeId { get; set; }
        public string MalzemeAdi { get; set; }
        public string MalzemeAciklamasi { get; set; }
        public string MalzemeStokAdedi { get; set; }

        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}
