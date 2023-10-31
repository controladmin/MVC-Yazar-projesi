using EntityLayer.Concrete; // Role sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRoleService
    {
        List<Role> GetRoles();
        void RoleAdd(Role role);

        /* Silme işlemi için gerekli değeri bulmak için yazılan kod id değerine göre sadece tek değer döndürür */
        Role GetById(int id);
        void RoleDelete(Role role);
        void RoleUpdate(Role role);
    }
}
