using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForTinkoff.DAL;

namespace ForTinkoff.Controllers
{
    public class ShortUrlController : Controller
    {
        private readonly ShortLinksContext context = new ShortLinksContext();
        // GET: ShortUrl
        public ActionResult Index(string id)
        {
            var shortUrl = Request.Url.OriginalString;
            //DO NOT REPLACE WHERE, Because case sensitive comparison is needed.
            //This is case insensitive, because this is performed in SQL through Table
            var links = context.Links.Where(l => l.ShortUrl == shortUrl).ToArray();
            //This is case sensitive, because this is performed through Array
            var link = links.FirstOrDefault(l => l.ShortUrl == shortUrl);
            if (link == null)
                return new HttpNotFoundResult();
            link.Jumps++;
            context.SaveChanges();
            return new RedirectResult(link.Url);
        }
    }
}