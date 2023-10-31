using EntityLayer.Concrete; // Content sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListSearch(string search);
        List<Content> GetListByWriter(int id);
        void ContentAdd(Content content);

        /* Silme işlemi için gerekli değeri bulmak için yazılan kod sadece tek bir değer döndürüyür */
        Content GetById(int id);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);

        /* id değerine göre bütün listeyi döndürecek */
        List<Content> GetListByHeadingId(int id);
    }
}
