using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // [Key] ifadesini kullanabilmek için ekledik
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        /* [Key] ifadesini kullanabilmek için EntityLayer katmanına NuGet sayfasından EntityFramework kütüphanesini ekledik*/
        [Key]
        public int HeadingId { get; set; }
        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime? HeadingDate { get; set; }
        public bool HeadingStatus { get; set; }

        /* Category ve Heading tabloları arasında ilişki kuruyoruz*/
        /* ilişkili tablodaki aynı isim ile vermek zorundayız CategoryId isminde property oluşturuyoruz*/
        public int CategoryId { get; set; }
        /* Category tablosu ile ilişkili olduğunu belirtiyoruz*/
        public virtual Category Category { get; set; }


        /* Heading ile Content tablosu arasında ilişki kuruyoruz*/
        public ICollection<Content> Contents { get; set; }

        /*Heading ile Writer tablosu arasında ilişki Kurma*/
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

    }
}
