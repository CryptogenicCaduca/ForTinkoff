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
                    Jumps = 0
                },
                new Link()
                {
                    Id = 0,
                    Url ="https://visualstudiogallery.msdn.microsoft.com/51e11ccc-6334-4873-912d-bf5025eb115d?SRC=VSIDE",
                    ShortUrl = "http://localhost:9527/1",
                    Jumps = 0
                }
            };
            links.ForEach(l=>context.Links.Add(l));
            context.SaveChanges();
        }
    }
}