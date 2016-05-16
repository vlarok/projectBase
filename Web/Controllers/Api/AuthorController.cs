using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTO;
using BLL.Service;
using DAL;

namespace Web.Controllers.Api
{
    public class AuthorController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private BLL.Service.AuthorService _service;

        public AuthorController(AuthorService service)
        {
            _service = service;
        }

        // GET: api/Product
        public List<AuthorDTO> GetAuthors()
        {
            return _service.AllDto();
        }
    }
}
