using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // [Key] ifadesini kullanabilmek için ekledik
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        /* [Key] ifadesini kullanabilmek için EntityLayer katmanına NuGet sayfasından EntityFramework kütüphanesini ekledik*/
        [Key]
        public int WriterId { get; set; }
        [StringLength(50)]
        public string WriterName { get; set; }
        [StringLength(50)]
        public string WriterSurname { get; set; }
      
        public string WriterImage { get; set; }

        [StringLength(1000)]
        public string WriterAbout { get; set; }

        [StringLength(50)]
        public string WriterTitle { get; set; }

        [StringLength(100)]
        public string WriterMail { get; set; }
        [StringLength(250)]
        public string WriterPassword { get; set; }


        public bool WriterStatus { get; set; }
        /* Writer ve Heading tabloları arasında ilişki kurma*/
        public ICollection<Heading> Headings { get; set; }

        /* Writer ile Content tabloları arasında ilişki kurma*/
        public ICollection<Content> Contents { get; set; }
    }
}
