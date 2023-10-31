using DataAccessLayer.Abstract; // ICategoryDal interface'ni kullanabilmek için ekledik
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity; // DBSet<> ifadesini kullanabilmek için ekledik
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context context = new Context();
        DbSet<Category> _object; /* Category sınıfına ait verileri tutuyor*/

        /* Buradaki işlemleri her tablo için bu şekilde yapmayacağız daha generic hale getireceğiz bu şekilde yapılabilir ama zahmetlidir generic olmaz
         bunun yerine GenericRepository kullanacağız
         */
        public void delete(Category _category)
        {
            _object.Remove(_category);
            context.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {

            throw new NotImplementedException();
        }

        public void insert(Category _category)
        {
            _object.Add(_category);
            context.SaveChanges();
        }

        public List<Category> List()
        {
            return _object.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> filtreleme)
        {
            return _object.Where(filtreleme).ToList();
        }

        public void update(Category _category)
        {
            context.SaveChanges();
        }
    }
}
