using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.Factories
{
    public class CommentFactory
    {
        public CommentDTO createBasicDTO(Comment comment)
        {
            return new CommentDTO()
            {
                BookId = comment.BookId,
                AuthorId = comment.AuthorId,
                CommentText = comment.CommentText
               
            };
        }
    }
}
