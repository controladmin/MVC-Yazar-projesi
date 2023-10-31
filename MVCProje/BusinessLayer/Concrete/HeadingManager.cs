using BusinessLayer.Abstract; // /HeadingService interface'ni kullanabilmek için ekledik
using DataAccessLayer.Abstract; // IHeadingDal interface'ni kullanabilmek için ekledik
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterId == id);
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDal.insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            _headingDal.delete(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.update(heading);
        }

        public void HedaingStatusChange(Heading heading)
        {
            if (heading.HeadingStatus == true)
            {
                heading.HeadingStatus = false;
                _headingDal.update(heading);
            }
            else if (heading.HeadingStatus == false)
            {
                heading.HeadingStatus = true;
                _headingDal.update(heading);
            }
        }
    }
}
