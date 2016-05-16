using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BLL.DTO
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }
        [MaxLength(128)]

        public string FirstName { get; set; }
        [MaxLength(128)]

        public string Lastname { get; set; }

        public virtual List<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();


        public string FirstLastname => FirstName + ", " + Lastname;

    }
}
