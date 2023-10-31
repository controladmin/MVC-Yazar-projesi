using EntityLayer.Concrete; // Admin sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();
        void AdminAdd(Admin admin);

        /* Silme işlemi için gerekli değeri bulmak için yazılan kod id değerine göre sadece tek değer döndürür */
        Admin GetById(int id);
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);

        void adminStatusChange(Admin admin);
    }
}
