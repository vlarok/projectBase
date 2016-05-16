using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BLL.DTO
{
    public class BookDTO
    {
        public int BookId { get; set; }

        [MaxLength(128)]
        public string Title { get; set; }

        public virtual Publisher Publisher { get; set; }

        public virtual List<AuthorBook> BookAuthors { get; set; } = new List<AuthorBook>();

        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
        public int PublisherId
        {
            get; set;
        }

    }
}
