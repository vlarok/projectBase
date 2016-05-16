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
    public class AuhtorBookService
    {
        private DAL.Interfaces.IEFRepository<AuthorBook> _repo;
        private Factories.AuthorBookFactory _factory;
        public AuhtorBookService(AuthorBookFactory factory, EFRepository<AuthorBook> repo)
        {
            this._repo = repo;
            this._factory = factory;
        }

        public List<AuthorBookDTO> AllDto()
        {
            return this._repo.All.Select(x => _factory.createBasicDTO(x)).ToList();
        }
        public List<AuthorBook> All()
        {
            return this._repo.All.ToList();
        }

        public void Add(AuthorBook authorBook)
        {
            _repo.Add(authorBook);
            _repo.SaveChanges();

        }

        public AuthorBook Find(int? id)
        {
            return _repo.GetById(id);
        }

        public void Update(AuthorBook authorBook)
        {
            _repo.Update(authorBook);
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

