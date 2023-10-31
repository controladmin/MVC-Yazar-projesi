using EntityLayer.Concrete; // Mesaj sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMesajService
    {
        List<Mesaj> GetListGelenMesajlar(string p);
        List<Mesaj> GetListGonderilenMesajlar(string p);

        List<Mesaj> GetListSearch(string search);
        void MesajAdd(Mesaj mesaj);

        /* Silme işlemi için gerekli değeri bulmak için yazılan kod id değerine göre sadece tek değer döndürür */
        Mesaj GetById(int id);
        void MesajDelete(Mesaj Mesaj);
        void MesajUpdate(Mesaj mesaj);
    }
}
