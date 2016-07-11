using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.Http.Results;
using ForTinkoff.Models;

namespace ForTinkoff.Controllers
{
    public class LinkController : ApiController
    {
        private ILinksRepository linkItems { get; set; }

        public LinkController()
        {
            linkItems = new LinksRepository();
        }

        public IEnumerable<Link> Get()
        {
            return linkItems.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var link = linkItems.Find(id);
            if (link == null)
                return NotFound();
            return Ok(link);
        }

        public IHttpActionResult Post([FromBody]Link link)
        {
            if (link == null)
                return BadRequest();
            linkItems.Add(link);
            return Ok();
        }

        public IHttpActionResult Put(int id, Link item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var link = linkItems.Find(id);
            if (link == null)
            {
                return NotFound();
            }

            linkItems.Update(item);
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var link = linkItems.Remove(id);
            if (link == null)
                return NotFound();
            else return Ok();
        }
    }
}
