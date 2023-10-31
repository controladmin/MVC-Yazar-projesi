using BusinessLayer.Abstract; // IRoleService interface'ni kullanabilmek için ekledik
using DataAccessLayer.Abstract; // IRoleDal interface'ni kullanabilmek için ekledik
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public Role GetById(int id)
        {
            return _roleDal.Get(x => x.RoleId == id);
        }

        public List<Role> GetRoles()
        {
            return _roleDal.List();
        }

        public void RoleAdd(Role role)
        {
            _roleDal.insert(role);
        }

        public void RoleDelete(Role role)
        {
            _roleDal.delete(role);
        }

        public void RoleUpdate(Role role)
        {
            _roleDal.update(role);
        }
    }
}
