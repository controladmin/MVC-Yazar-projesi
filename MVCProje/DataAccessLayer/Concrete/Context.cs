using EntityLayer.Concrete; // About Sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Data.Entity; // DbContext sınıfını kullanabilmek için ekledik
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        /* Burada Database bağlantısı ve database bazlı işlemler yapılmakta*/
        /* DataAccessLayer katmanına sağ click add reference diyerek EntityLayer katmanını reference olarak ekliyoruz*/
        /* Buradaki propertileri sqle tablo olarak yansıtacak*/
        public DbSet<About> Abouts{get;set;}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Mesaj> Mesajs { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
