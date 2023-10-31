using BusinessLayer.Abstract; // IWriterLoginService interface'ni kullanabilmek için ekledik
using DataAccessLayer.Abstract; // IWreiterDal interface'ni kullanabilmek için ekledik
using EntityLayer.Concrete; // Writer sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterLoginManager : IWriterLoginService
    {

        IWriterDal _writerdal;

        public WriterLoginManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }

        public Writer GetWriter(string userName, string userPassword)
        {
            return _writerdal.Get(x => x.WriterMail == userName && x.WriterPassword == userPassword);
        }
    }
}
