using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ForTinkoff.Models;


namespace ForTinkoff.DAL
{

    public class ShortLinksContext: DbContext
    {
        public ShortLinksContext() : base("ShortLinksContext") 
        {
        } 
         
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}