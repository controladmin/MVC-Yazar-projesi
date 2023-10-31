
using DataAccessLayer.Abstract; // IWriterDal interface'ni kullanabilmek için ekledik
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity; // DbSet ifadesini kullanabilmek için ekledik
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class WriterRepository : IWriterDal
    {
        Context context = new Context();
        DbSet<Writer> _object; /* Category sınıfına ait verileri tutuyor*/

        /* Buradaki işlemleri her tablo için bu şekilde yapmayacağız daha generic hale getireceğiz bu şekilde yapılabilir ama zahmetlidir generic olmaz
         bunun yerine GenericRepository kullanacağız
         */
        public void delete(Writer t)
        {
            _object.Remove(t);
            context.SaveChanges();
        }

        public Writer Get(Expression<Func<Writer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void insert(Writer t)
        {
            _object.Add(t);
            context.SaveChanges();
        }

        public List<Writer> List()
        {
            return _object.ToList();
        }

        public List<Writer> List(Expression<Func<Writer, bool>> filtreleme)
        {
            return _object.Where(filtreleme).ToList();
        }

        public void update(Writer t)
        {
            context.SaveChanges();
        }
    }
}
