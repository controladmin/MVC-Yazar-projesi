using BusinessLayer.Abstract; // IImageService interface'ni kullanabilmek için ekledik
using DataAccessLayer.Abstract; // ImageDal interface'ni kullanabilmek için ekledik
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public List<Image> GetList()
        {
           return _imageDal.List();
        }
    }
}
