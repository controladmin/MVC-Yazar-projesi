using EntityLayer.Concrete; // About sınıfını kullanabilmek içine ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();
        void AboutAdd(About about);

        /* Silme işlemi için gerekli değeri bulmak için yazılan kod id değerine göre sadece tek değer döndürür */
        About GetById(int id);
        void AboutDelete(About about);
        void AboutUpdate(About about);

        void AboutStatusChange(About about);
    }
}
