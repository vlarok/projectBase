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
    public class WebService
    {
        private DAL.Interfaces.IWebRepository _repo;
        private Factories.WebFactory _factory;
        public WebService(WebFactory factory, WebRepository repo)
        {
            this._repo = repo;
            this._factory = factory;
        }

        public List<AuthorDTO> GetDTOAuthors()
        {
            return this._repo.AuthorsList.Select(x => _factory.createBasicDTO(x)).ToList();
        }
        public List<Author> GetAllAuthors()
        {
            return this._repo.AuthorsList.ToList();
        }
    }
}
