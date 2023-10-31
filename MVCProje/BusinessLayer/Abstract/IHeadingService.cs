using EntityLayer.Concrete; // Heading sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter(int id);
        void HeadingAdd(Heading heading);
        void HeadingDelete(Heading heading);
        void HeadingUpdate(Heading heading);
        void HedaingStatusChange(Heading heading);
        /* id değerine göre sadece tek bir değer döndürür*/
        Heading GetByID(int id);
    }
}
