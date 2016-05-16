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
    public class PublisherService
    {
        private DAL.Interfaces.IEFRepository<Publisher> _repo;
        private Factories.PublisherFactory _factory;
        public PublisherService(PublisherFactory factory, EFRepository<Publisher> repo)
        {
            this._repo = repo;
            this._factory = factory;
        }

        public List<PublisherDTO> AllDto()
        {
            return this._repo.All.Select(x => _factory.createBasicDTO(x)).ToList();
        }
        public List<Publisher> All()
        {
            return this._repo.All.ToList();
        }

        public void Add(Publisher publisher)
        {
            _repo.Add(publisher);
            _repo.SaveChanges();

        }

        public Publisher Find(int? id)
        {
            return _repo.GetById(id);
        }

        public void Update(Publisher publisher)
        {
            _repo.Update(publisher);
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

