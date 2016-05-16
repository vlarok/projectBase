using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.Factories
{
    public class BookFactory
    {
        public BookDTO createBasicDTO(Book book)
        {
            return new BookDTO()
            {
                BookId = book.BookId,
                Title = book.Title
               
            };
        }
    }
}
