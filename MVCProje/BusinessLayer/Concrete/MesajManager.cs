using BusinessLayer.Abstract; // IMesajService interface'ni kullanabilmek için ekledik
using DataAccessLayer.Abstract; // IMesajDal interface'ni kullanabilmek için ekledik
using EntityLayer.Concrete; // Mesaj sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MesajManager : IMesajService
    {
        IMesajDal _mesajDal;

        public MesajManager(IMesajDal mesajDal)
        {
            _mesajDal = mesajDal;
        }

        public Mesaj GetById(int id)
        {
            return _mesajDal.Get(x => x.MesajId == id);
        }

        public List<Mesaj> GetListGelenMesajlar(string p)
        {
            return _mesajDal.List(x=>x.AliciMail==p);
        }

        public List<Mesaj> GetListGonderilenMesajlar(string p)
        {
            return _mesajDal.List(x=>x.GondericiMail==p);
        }

        public List<Mesaj> GetListSearch(string search)
        {
            return _mesajDal.List(x => x.MesajKonusu.Contains(search));
        }

        public void MesajAdd(Mesaj mesaj)
        {
            _mesajDal.insert(mesaj);
        }

        public void MesajDelete(Mesaj Mesaj)
        {
            _mesajDal.delete(Mesaj);
        }

        public void MesajUpdate(Mesaj mesaj)
        {
            _mesajDal.update(mesaj);
        }
    }
}
