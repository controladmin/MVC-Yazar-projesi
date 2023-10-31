using DataAccessLayer.Abstract; // IHeading interface'ni kullanabilmek için ekledik
using DataAccessLayer.Concrete.Repositories; // GenericRepositery sınıfını kullanabilmek için ekledik
using EntityLayer.Concrete; // Heading sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFHeadingDal: GenericRepository<Heading>, IHeadingDal
    {
    }
}
