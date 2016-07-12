using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ForTinkoff.DAL;

namespace ForTinkoff.Models
{
    public class LinksRepository : ILinksRepository
    {
        private readonly ShortLinksContext context;
        public LinksRepository()
        {
            context = new ShortLinksContext();
        }

        public void Add(Link item)
        {
            context.Links.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<Link> GetAll()
        {
            return context.Links;
        }

        public Link Find(int id)
        {
            return context.Links.FirstOrDefault(l => l.Id == id);
        }

        public Link Last()
        {
            return context.Links.OrderByDescending(l => l.Id).FirstOrDefault();
        }

        public Link Remove(int id)
        {
            var link = context.Links.Remove(context.Links.FirstOrDefault(l => l.Id == id));
            context.SaveChanges();
            return link;
        }

        public void Update(Link item)
        {
            var linku = context.Links.FirstOrDefault(l => l.Id == item.Id);

            if (linku != null)
            {
                context.Entry(linku).CurrentValues.SetValues(item);
                context.SaveChanges();
            }
        }
    }
}