using BusinessLayer.Abstract; // IWriterService interface'ni kullanabilmek için ekledik
using DataAccessLayer.Abstract; // IWriterDal interface'ni kullanabilmek için ekledik
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x=>x.WriterId==id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public void WriterAdd(Writer writer)
        {
            _writerDal.insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.update(writer);
        }
    }
}
