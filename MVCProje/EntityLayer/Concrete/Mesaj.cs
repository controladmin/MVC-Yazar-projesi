using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // [Key] ifadesini kullanabilmek için ekledik
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Mesaj
    {
        [Key]
        public int MesajId { get; set; }
        [StringLength(50)]
        public string GondericiMail { get; set; }
        [StringLength(50)]
        public string AliciMail { get; set; }
        [StringLength(100)]
        public string Konu { get; set; }
        [StringLength(1000)]
        public string MesajKonusu { get; set; }
        public DateTime? MesajTarihi { get; set; }
    }
}
