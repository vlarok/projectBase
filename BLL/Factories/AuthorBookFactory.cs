using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.Factories
{
    public class AuthorBookFactory
    {
        public AuthorBookDTO createBasicDTO(AuthorBook authorbook)
        {
            return new AuthorBookDTO()
            {
                AuthorId = authorbook.AuthorId,
                BookId = authorbook.BookId
               
            };
        }
    }
}
