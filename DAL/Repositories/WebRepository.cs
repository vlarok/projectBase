using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class WebRepository:IWebRepository
    {
        private ApplicationDbContext _ctx;

        public WebRepository(ApplicationDbContext ctx)
        {
            this._ctx = ctx;
        }
        public List<Author> AuthorsList
        {
            get
            {
                return _ctx.Authors.ToList();
            }
        }
    }
}
