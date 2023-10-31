using BusinessLayer.Abstract; // IAboutSerivice interface'ni kullanabilmek için ekledik
using DataAccessLayer.Abstract; // IAboutDal interface'ni kullanabilmek için ekledik
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AboutAdd(About about)
        {
            _aboutDal.insert(about);
        }

        public void AboutDelete(About about)
        {
            _aboutDal.delete(about);
        }

        public void AboutUpdate(About about)
        {
            _aboutDal.update(about);
        }

        public About GetById(int id)
        {
            return _aboutDal.Get(x => x.AboutId == id);
        }

        public List<About> GetList()
        {
            return _aboutDal.List();
        }

        public void AboutStatusChange(About about)
        {
            if (about.Status == true)
            {
                about.Status = false;
                _aboutDal.update(about);
            }
            else if (about.Status == false)
            {
                about.Status = true;
                _aboutDal.update(about);
            }
        }
    }
}
