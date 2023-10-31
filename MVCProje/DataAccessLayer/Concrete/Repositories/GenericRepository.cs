using DataAccessLayer.Abstract; // IRepository interface'ni kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Data.Entity; // DbSet ifadesini kullanabilmek için ekledik
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context context = new Context();
        DbSet<T> _object;
        public GenericRepository()
        {
          /*  Constructor yapıcı metodu ile _object ifadesine gelen sınıfın atamasını yapıyoruz */
            _object = context.Set<T>();
        }
        public void delete(T t)
        {

            var DeleteEntity = context.Entry(t);
            DeleteEntity.State = EntityState.Deleted;
            context.SaveChanges();

            /* Yukarıdaki kodu kullanınca bu koda gerek kalmıyor*/
            //_object.Remove(t);
            //context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            /* SingleOrDefault bir dizi yada listede sadece bir değer geriye döndürmek için kullanılır*/
            return _object.SingleOrDefault(filter);
        }

        public void insert(T t)
        {
            var AddEntity = context.Entry(t);
            AddEntity.State = EntityState.Added;
            context.SaveChanges();

            /* Yukarıdaki kodu kullanınca bu koda gerek kalmıyor*/
            //_object.Add(t);
            //context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filtreleme)
        {
            return _object.Where(filtreleme).ToList();
        }

        public void update(T t)
        {
            /* bu iki kodu yazmaz isek update işlemini yapmıyor sadece  context.SaveChanges(); ile update olmuyor*/
            var UpdateEntity = context.Entry(t);
            UpdateEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
