using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ForTinkoff.Models;

namespace ForTinkoff.DAL
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ShortLinksContext>
    {
        protected override void Seed(ShortLinksContext context)
        {
            var links = new List<Link>()
            {
                new Link()
                {
                    Id = 0,
                    Url =
                        "https://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application",
                    ShortUrl = "http://localhost:9527/0",
                    InitDateTime = new DateTime(1997, 9, 23, 20, 33, 25),
                    Jumps = 0
                },
                new Link()
                {
                    Id = 0,
                    Url =
                        "https://visualstudiogallery.msdn.microsoft.com/51e11ccc-6334-4873-912d-bf5025eb115d?SRC=VSIDE",
                    ShortUrl = "http://localhost:9527/1",
                    InitDateTime = new DateTime(1996, 12, 1, 14, 10, 56),
                    Jumps = 13
                },
                new Link()
                {
                    Id = 0,
                    Url =
                        "https://docs.asp.net/en/latest/tutorials/first-web-api.html",
                    ShortUrl = "http://localhost:9527/2",
                    InitDateTime = new DateTime(1996, 12, 1, 14, 10, 56),
                    Jumps = 3
                }
            };
            links.ForEach(l=>context.Links.Add(l));
            context.SaveChanges();
        }
    }
}