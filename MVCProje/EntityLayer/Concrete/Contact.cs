using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // [Key] ifadesini kullanabilmek için ekledik
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        /* [Key] ifadesini kullanabilmek için EntityLayer katmanına NuGet sayfasından EntityFramework kütüphanesini ekledik*/
        [Key]
        public int ContactId { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string UserMail { get; set; }
        [StringLength(100)]
        public string Subject { get; set; }
        [StringLength(1000)]
        public string Message { get; set; }
        public DateTime? ContactDate { get; set; }
    }
}
