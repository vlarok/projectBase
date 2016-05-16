using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.Factories
{
    public class WebFactory
    {
        public AuthorDTO createBasicDTO(Author author)
        {
            return new AuthorDTO()
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
                Lastname = author.Lastname
               
            };
        }
    }
}
