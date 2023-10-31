using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // [Key] ifadesini kullanabilmek için ekledik
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        /* [Key] ifadesini kullanabilmek için EntityLayer katmanına NuGet sayfasından EntityFramework kütüphanesini ekledik*/
        [Key]
        public int CategoryId { get; set; }
        [StringLength(50,ErrorMessage ="En az 50 karakter girebilirsiniz!!!")]
        public string CategoryName { get; set; }
        [StringLength(500,ErrorMessage ="En az 500 karakter girebilirsiniz!!!")]
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }

        /*Category ve Heading tablosu ile ilişki kurma*/
        public ICollection<Heading> Headings { get; set; }
    }
}
