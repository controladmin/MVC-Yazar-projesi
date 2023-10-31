using EntityLayer.Concrete; // Category sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        void CategoryAdd(Category category);

        /* Silme işlemi için gerekli değeri bulmak için yazılan kod id değerine göre sadece tek değer döndürür */
        Category GetById(int id);
        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);
    }
}
