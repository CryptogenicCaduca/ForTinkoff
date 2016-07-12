using System.Collections.Generic;

namespace ForTinkoff.Models
{
    public interface ILinksRepository
    {
        void Add(Link item);
        IEnumerable<Link> GetAll();
        Link Find(int id);
        Link Last();
        Link Remove(int id);
        void Update(Link item);
    }
}