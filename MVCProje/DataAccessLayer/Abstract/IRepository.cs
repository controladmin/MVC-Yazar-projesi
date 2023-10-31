using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; // Expression sınıfını kullanabilmek için ekliyoruz
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IRepository<T>
    {
        /* 
            bu şekilde tasarım daha esnek bir kullanım sunar T yerine istediğimiz class değerini gönderip işlem yapabiliriz
            bu sebeple her class için ayrı ayrı interface tanımlamamıza gerek kalmayacaktır
            bu interface'İ genel olarak tanımlayıp diğer sınıf interface'leri miras alacaktır
         */
        List<T> List();
        void insert(T t);
        void update(T t);
        void delete(T t);

        /* Silenecek değeri bulacağız */
        T Get(Expression<Func<T, bool>> filter);

        /* şartlı filtreleme yapmak için kullanılan metot bizim verdiğimiz şarta göre listeleme yapacak*/
        List<T> List(Expression<Func<T, bool>>filtreleme);
    }
}
