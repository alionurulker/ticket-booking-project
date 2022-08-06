using seyahatbiletcim1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace seyahatbiletcim1.DAL
{
    public class BiletContext:DbContext
    {
        public BiletContext() : base("biletContext") { }//connectionString ile biletContext isimli veriTabanı oluşturmamızı sağlar.

        public DbSet<Ucak> Ucaklar1 { get; set; }

        public DbSet<Otel> Oteller { get; set; }

        public DbSet<TumUcakListesi> TumUcakListesi { get; set; }

        public DbSet<TumOtobusListesi> TumOtobusListesi { get; set; }

        public DbSet<Otobus> Otobuslar1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //tabloların sonuna s gelmesini engeller
        }
    }




}