using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BLL.DTO
{
    public class AuthorBookDTO
    {
        public int AuthorBookId { get; set; }


        public int AuthorId { get; set; }
        public int BookId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }

    }
}
