using BusinessLayer.Abstract; // IAdminService interface'ni kullanabilmek için ekledik
using DataAccessLayer.Abstract; // ıAdminDal interface'ni kullanabilmek için ekledik
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {

        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(Admin admin)
        {
            _adminDal.insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDal.delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.update(admin);
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x => x.AdminId == id);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }

        public void adminStatusChange(Admin admin)
        {
            if (admin.AdminStatus == true)
            {
                admin.AdminStatus = false;
                _adminDal.update(admin);
            }
            else if (admin.AdminStatus == false)
            {
                admin.AdminStatus = true;
                _adminDal.update(admin);
            }
        }
    }
    
}
