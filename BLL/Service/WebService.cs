using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.Service
{
    public class WebService
    {
        private DAL.Interfaces.IWebRepository _repo;
        private Factories.AuthorFactory _factory;
        public WebService()
        {
            this._repo = new DAL.Repositories.WebRepository(new DAL.ApplicationDbContext());
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
