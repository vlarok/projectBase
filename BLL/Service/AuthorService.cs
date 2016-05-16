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
    public class AuthorService
    {
        private DAL.Interfaces.IEFRepository<Author> _repo;
        private Factories.AuthorFactory _factory;
        public AuthorService(AuthorFactory factory, EFRepository<Author> repo)
        {
            this._repo = repo;
            this._factory = factory;
        }

        public List<AuthorDTO> AllDto()
        {
            return this._repo.All.Select(x => _factory.createBasicDTO(x)).ToList();
        }
        public List<Author> All()
        {
            return this._repo.All.ToList();
        }

        public void Add(Author author)
        {
            _repo.Add(author);
            _repo.SaveChanges();

        }

        public Author Find(int? id)
        {
            return _repo.GetById(id);
        }

        public void Update(Author author)
        {
            _repo.Update(author);
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

