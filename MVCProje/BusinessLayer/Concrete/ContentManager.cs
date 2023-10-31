using BusinessLayer.Abstract; // IContentService interface'ni kullanabilmek için ekledik
using DataAccessLayer.Abstract;  // IContentDal interface'ni kullanabilmek için ekledik
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            _contentDal.insert(content);
        }

        public void ContentDelete(Content content)
        {
            _contentDal.delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDal.update(content);
        }

        public Content GetById(int id)
        {
           return _contentDal.Get(x => x.ContentId == id);
        }

        public List<Content> GetList()
        {
            return _contentDal.List();
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDal.List(x => x.HeadingId == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterId == id);
        }

        public List<Content> GetListSearch(string search)
        {
            return _contentDal.List(x => x.ContentValue.Contains(search));
        }
    }
}
