﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Comment
    {
        public int CommentId { get; set; }

        [MaxLength(128)]
        public string CommentText { get; set; }


        public int? AuthorId { get; set; }
        public int? BookId { get; set; }

        public virtual Author Author { get; set; }

        public virtual Book Book { get; set; }
    }
}
