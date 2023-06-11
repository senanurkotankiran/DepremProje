using System.ComponentModel.DataAnnotations;

namespace DepremProje.Models
{
    public class Talep
    {

        [Key]
        public int TalepId { get; set; }
        public string KisiTC { get; set; }
        public string KisiAdi { get; set; }
        public string KisiSoyadi { get; set; }
        public string KisiDogumTarihi { get; set; }

        public int SehirId { get; set; }
        public virtual Sehir Sehir { get; set; }


        public int IlceId { get; set; }
        public virtual Ilce Ilce { get; set; }

        public string TalepAcikAdresi { get; set; }

        public int MalzemeId { get; set; }
        public virtual Malzeme Malzeme { get; set; }
        public bool Status { get; set; }

    }
}

