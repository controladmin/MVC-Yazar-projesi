using BusinessLayer.Abstract; // IContactService interface'ni kullanabilmek için ekledik
using DataAccessLayer.Abstract; // IContactDal interface'ni kullanabilmek için ekledik
using EntityLayer.Concrete; // COntact sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void ContactAdd(Contact contact)
        {
            _contactDal.insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _contactDal.delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _contactDal.update(contact);
        }

        public Contact GetById(int id)
        {
          return  _contactDal.Get(x => x.ContactId == id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }
    }
}
