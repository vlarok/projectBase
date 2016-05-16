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
    public class CommentService
    {
        private DAL.Interfaces.IEFRepository<Comment> _repo;
        private Factories.CommentFactory _factory;
        public CommentService(CommentFactory factory, EFRepository<Comment> repo)
        {
            this._repo = repo;
            this._factory = factory;
        }

        public List<CommentDTO> AllDto()
        {
            return this._repo.All.Select(x => _factory.createBasicDTO(x)).ToList();
        }
        public List<Comment> All()
        {
            return this._repo.All.ToList();
        }

        public void Add(Comment comment)
        {
            _repo.Add(comment);
            _repo.SaveChanges();

        }

        public Comment Find(int? id)
        {
            return _repo.GetById(id);
        }

        public void Update(Comment comment)
        {
            _repo.Update(comment);
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

