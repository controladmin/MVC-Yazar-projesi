using EntityLayer.Concrete; // Writer sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IWriterDal:IRepository<Writer>
    {

        //CRUD işlemleri tanımlanacak
        /* Writer listesi dönecek bize*/

        /* 
         Bu şekilde her tablo için ayrı ayrı interface ve repository oluşturmak zoraki bir iştir ve mimariye aykırı bir işlemdir bu şekilde yapılabilir
         fakat ilerleyen süreçlerde ilaveler olduğunda tek tek uğraşmak gerekecektir bunların yerine alacak IRepository interface'ni oluşturuyoruz
         */


        /* aşağıdaki ifadeleri tek tek oluşturmamıza gerek kalmadı her tablo için IRepositoryden miras alacak*/
        //List<Writer> List();
        //void insert(Writer _writer);
        //void update(Writer _writer);
        //void delete(Writer _writer);
    }
}
