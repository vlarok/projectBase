using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Factories;
using DAL.Repositories;
using Domain;

namespace BLL.Service
{
    public class BookService
    {
        private DAL.Interfaces.IEFRepository<Book> _repo;
        private Factories.BookFactory _factory;
        public BookService(BookFactory factory, EFRepository<Book> repo)
        {
            this._repo = repo;
            this._factory = factory;
        }

        public List<BookDTO> AllDto()
        {
            return this._repo.All.Select(x => _factory.createBasicDTO(x)).ToList();
        }
        public List<Book> All()
        {
            return this._repo.All.ToList();
        }

        public void Add(Book book)
        {
            _repo.Add(book);
            _repo.SaveChanges();

        }

        public Book Find(int? id)
        {
            return _repo.GetById(id);
        }

        public void Update(Book book)
        {
            _repo.Update(book);
            _repo.SaveChanges();
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.SaveChanges();
        }

        public void Dispose()
        {
            _repo.Dispose();
        }
    }
}

