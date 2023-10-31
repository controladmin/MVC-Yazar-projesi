using EntityLayer.Concrete; // Contact sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        void ContactAdd(Contact contact);

        /* Silme işlemi için gerekli değeri bulmak için yazılan kod id değerine göre sadece tek değer döndürür */
        Contact GetById(int id);
        void ContactDelete(Contact contact);
        void ContactUpdate(Contact contact);
    }
}
