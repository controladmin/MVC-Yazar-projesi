using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // [Key] ifadesini kullanabilmek için ekledik
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [StringLength(50)]
        public string AdminUserName { get; set; }
        [StringLength(250)]
        public string AdminPassword { get; set; }
        public string AdminImage { get; set; }

        [StringLength(100)]
        public string AdminMail { get; set; }
        public bool AdminStatus { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
