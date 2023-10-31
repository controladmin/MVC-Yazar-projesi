using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // [Key] ifadesini kullanabilmek için ekledik
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        /* [Key] ifadesini kullanabilmek için EntityLayer katmanına NuGet sayfasından EntityFramework kütüphanesini ekledik*/
        [Key]
        public int AboutId { get; set; }
        [StringLength(1000)]
        public string AboutDetails1 { get; set; }
        [StringLength(1000)]
        public string AboutDetails2 { get; set; }
 
        public string AboutImage { get; set; }
    
        public bool Status { get; set; }
    }
}
