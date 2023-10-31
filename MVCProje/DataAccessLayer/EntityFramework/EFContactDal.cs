using DataAccessLayer.Abstract; // IContactDal interface'ni kullanabilmek için ekledik
using DataAccessLayer.Concrete.Repositories; // GenericRepository sınıfını kullanabilmek için ekledik
using EntityLayer.Concrete; // Contact sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFContactDal : GenericRepository<Contact>, IContactDal
    {
    }
}
