using BusinessLayer.Abstract; // ICategoryService interface'ni kullanabilmek için ekledik
using DataAccessLayer.Abstract; // ICategoryDal interface'ni kullanabilmek için ekledik
using DataAccessLayer.Concrete.Repositories; // GenericRepository sınıfını kullanabilmek için ekledik
using EntityLayer.Concrete; // Category sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.delete(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x=>x.CategoryId==id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.update(category);
        }







        /* Bu yöntemde kullanılabilir fakat mimariye daha düzgün uyması için ICategoryService diye interface tanımlayıp ondan miras aldıracağız
           aşağıdaki yazılan kodları
         */
        //GenericRepository<Category> repository = new GenericRepository<Category>();
        //public List<Category> GetAllBL()
        //{
        //    return repository.List();
        //}
        //public void CategoryAddBL(Category category)
        //{
        //    if(category.CategoryName==""|| category.CategoryName.Length<=3 ||category.CategoryDescription=="" || category.CategoryName.Length>=51)
        //    {
        //        // Hata mesajı gelecek
        //    }
        //    else
        //    {
        //        repository.insert(category);
        //    }
        //}

    }
}
