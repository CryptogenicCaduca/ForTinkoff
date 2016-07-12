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
            var link =context.Links.FirstOrDefault(l => l.ShortUrl == shortUrl);
            if (link == null)
                return new HttpNotFoundResult();
            link.Jumps++;
            context.SaveChanges();
            return new RedirectResult(link.Url);
        }
    }
}