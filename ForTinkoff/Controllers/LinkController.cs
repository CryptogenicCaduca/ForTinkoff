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
        [HttpGet]
        public IEnumerable<Link> Get()
        {
            return linkItems.GetAll();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var link = linkItems.Find(id);
            if (link == null)
                return NotFound();
            return Ok(link);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]string url)
        {
            Uri uriResult;
            bool created = Uri.TryCreate(url, UriKind.Absolute, out uriResult);
            if (!created)
                return BadRequest("Incorrect url");

            var link = linkItems.Last() + 1;
            link.Url = url;
            linkItems.Add(link);
            return Ok(link.ShortUrl);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Link item)
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

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var link = linkItems.Remove(id);
            if (link == null)
                return NotFound();
            else return Ok();
        }
    }
}
