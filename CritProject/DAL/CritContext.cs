using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CritProject.Models;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace CritProject.DAL
{
    public class CritContext: DbContext
    {
        public CritContext(): base("CritDatabase")
        {
            Database.SetInitializer(new CritDBInitializer<CritContext>());
        }

        public DbSet<GameModels> Games { get; set; }

        public DbSet<ReviewModels> Reviews { get; set; }

        public DbSet<CriticModels> Critics { get; set; }

        public DbSet<CommentModels> Comments { get; set; }

        public DbSet<ProducerModels> Producers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        
        }
    }
}