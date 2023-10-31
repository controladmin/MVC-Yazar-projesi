using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // [Key] ifadesini kullanabilmek için ekledik
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        /* [Key] ifadesini kullanabilmek için EntityLayer katmanına NuGet sayfasından EntityFramework kütüphanesini ekledik*/
        [Key]
        public int ContentId { get; set; }
        [StringLength(1000)]
        public string ContentValue { get; set; }
        public DateTime? ContentDate { get; set; }
        public bool ContentStatus { get; set; }

        /* Content ile Heading tablosu arasında ilişki kuruyoruz*/
        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }

        /* Writer ile Content tabloları arasında ilişki kurma*/
        /* Writer yazar id null olabilir diye belirttik kesin olarak yazar id olsun şartını esnettik yoksa update-database dediğimizde hata verecekti*/
        public int? WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
